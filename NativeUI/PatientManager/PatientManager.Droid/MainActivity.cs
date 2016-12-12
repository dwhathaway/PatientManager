using System;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using System.Collections.Generic;

using PatientManager.Common;
using System.IO;
using System.Threading.Tasks;

namespace PatientManager.Droid
{
	[Activity (Label = "PatientManager.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ActionBarActivity
    {
        ListView _patientsListView;
        AzureCloudService _patientService;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);

            // Get our button from the layout resource,
            // and attach an event to it
            _patientsListView = FindViewById<ListView>(Resource.Id.patientsListView);

            refreshData();
        }

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.menu, menu);
			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case (Resource.Id.add_patient):
					Console.WriteLine("Adding new patient");
					addPatient();
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}

		async void addPatient()
		{
			await editPatient(null);
		}

		async Task<bool> editPatient(Patient patient)
		{
			
			return true;	
		}

        async void refreshData()
		{
			//Step 2: Refresh Data method
            SQLitePCL.Batteries.Init();

            var path = "syncstore.db";

            path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), path);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            _patientService = new AzureCloudService(); //path

			var table = await _patientService.GetTableAsync<Patient>();
			IEnumerable<Patient> patients = await table.ReadAllItemsAsync();

            var patientsAdapter = new PatientsAdapter(this, patients.ToList<Patient>());

            _patientsListView.Adapter = patientsAdapter;
            patientsAdapter.NotifyDataSetChanged();
        }
	}

	//Step 1: Create Patients Adapter
    public class PatientsAdapter : BaseAdapter<Patient>
    {
        List<Patient> items;
        Activity context;

        public PatientsAdapter(Activity context, List<Patient> items) : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Patient this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].FullName.ToString();
            return view;
        }
    }
}


