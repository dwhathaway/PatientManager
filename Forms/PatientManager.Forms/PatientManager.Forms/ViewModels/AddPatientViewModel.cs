
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Common;
using Xamarin.Forms;

namespace PatientManager.Forms.ViewModels
{
    public class AddPatientViewModel : BaseViewModel
	{
		public INavigation Navigation { get; set; }

		bool createUser = false;

		public AddPatientViewModel() : this(null)
		{
		}

		public AddPatientViewModel(Patient patient)
		{
			Patient = patient;

			if (patient == null)
			{
				Title = "Add Patient";
				Patient = new Patient();
				createUser = true;
			}
			else
			{
				Title = "Edit Patient";
			}
		}

		public ICloudService CloudService => ServiceLocator.Get<ICloudService>();
		public IPlatform PlatformProvider => DependencyService.Get<IPlatform>();

		Patient patient;
		public Patient Patient
		{
			get {
				return patient; 
			}
			set
			{
				SetProperty(ref patient, value, "Patient");
			}
		}

		Command savePatientCmd;
		public Command SavePatientCommand => savePatientCmd ?? (savePatientCmd = new Command(async () => await ExecuteSavePatientCommand()));

		async Task ExecuteSavePatientCommand()
		{
			if (IsBusy)
				return;
			
			IsBusy = true;

			try
			{
				var table = await CloudService.GetTableAsync<Patient>();
				await table.UpsertItemAsync(Patient);
				if (createUser)
				{
					//await table.CreateItemAsync(Patient);
				}
				else
				{
				}
				await CloudService.SyncOfflineCacheAsync();
				Navigation.PopAsync(true);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[Save Patient] Error = {ex.Message}");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
