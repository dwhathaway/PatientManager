using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using PatientManager.Common;
using Xamarin.Forms;

namespace PatientManager.Forms
{
	public class PatientListViewModel : BaseViewModel
	{
		public PatientListViewModel()
		{
			RefreshCommand = new Command(async () => await refresh());

			// Execute the refresh command
			RefreshCommand.Execute(null);
		}

		public ICloudService CloudService => ServiceLocator.Get<ICloudService>();
		public IPlatform PlatformProvider => DependencyService.Get<IPlatform>();

		public ICommand RefreshCommand { get; }

		ObservableCollection<Patient> _items = new ObservableCollection<Patient>();

		public ObservableCollection<Patient> Items
		{
			get
			{
				return _items;
			}
			set
			{
				SetProperty(ref _items, value, "Items");
			}
		}

		async Task refresh()
		{
			if (IsBusy)
				return;
			IsBusy = true;

			try
			{
				await CloudService.SyncOfflineCacheAsync();
				var table = await CloudService.GetTableAsync<Patient>();
				var list = await table.ReadAllItemsAsync();
				Items.Clear();
				foreach (Patient p in list)
				{
					Items.Add(p);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[PatientsList] Error loading patients: {ex.Message}");
				//await Application.Current.MainPage.DisplayAlert("Items Not Loaded", ex.Message, "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
