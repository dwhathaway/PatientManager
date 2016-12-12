using Foundation;
using PatientManager.Common;
using System;
using UIKit;

namespace PatientManager.iOS
{
    public partial class AddPatientViewController : UIViewController
    {
		Patient _patient;

		public void SetDetailItem(Patient patient)
		{
			if (_patient != patient)
			{
				_patient = patient;

				// Update the view
				ConfigureView();
			}
		}

		void ConfigureView()
		{
			// Update the user interface for the detail item
			if (IsViewLoaded && _patient != null)
			{
				//Step 1: Apply values from existing patient to fields

			}
		}

        public AddPatientViewController (IntPtr handle) : base (handle)
        {
			
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			ConfigureView();

			//Step 4: (Optional) Apply ResignFirstResponder to fields

			//Step 3: Apply "Save" behavior to btnSave
        }

        private async void BtnSave_TouchUpInside(object sender, EventArgs e)
        {
			if (_patient == null)
				_patient = new Patient();

			//Step 1: Get values form user input to save to service


			var table = await AppDelegate.CloudService.GetTableAsync<Patient>();

			if (!String.IsNullOrEmpty(_patient.Id))
			{
				await table.UpdateItemAsync(_patient);
			}
			else {
				await table.CreateItemAsync(_patient);
			}

            NavigationController.PopToRootViewController(true);
        }

		void HandleEditingDidEnd(object sender, EventArgs e)
		{
			//do what you need to do with the value of the textfield here
		}

		public class CatchEnterDelegate : UITextFieldDelegate
		{
			public override bool ShouldReturn(UITextField textField)
			{
				textField.ResignFirstResponder();
				return true;
			}
		}
    }
}