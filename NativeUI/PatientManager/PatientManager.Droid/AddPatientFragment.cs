
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace PatientManager.Droid
{
	public class AddPatientFragment : Fragment
	{
		EditText firstName, lastName, height, weight, bloodPressure;
		Button saveButton;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			var view = inflater.Inflate(Resource.Layout.AddPatient, container, false);

			firstName = view.FindViewById<EditText>(Resource.Id.firstName);
			lastName = view.FindViewById<EditText>(Resource.Id.lastName);
			height = view.FindViewById<EditText>(Resource.Id.height);
			weight = view.FindViewById<EditText>(Resource.Id.weight);
			bloodPressure = view.FindViewById<EditText>(Resource.Id.bloodPressure);

			saveButton = view.FindViewById<Button>(Resource.Id.submit);

			return base.OnCreateView(inflater, container, savedInstanceState);
		}
	}
}
