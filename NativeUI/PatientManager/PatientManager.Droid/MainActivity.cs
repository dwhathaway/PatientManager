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
        }
	}

	//Step 1: Create Patients Adapter
}


