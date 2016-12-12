using Foundation;
using System;
using UIKit;
using System.Linq;

using PatientManager.Common;
using System.Collections.Generic;

namespace PatientManager.iOS
{
    public partial class PatientsViewController : UITableViewController
    {
        List<Patient> _patient = new List<Patient>();

        public PatientsViewController (IntPtr handle) : base (handle)
        {
            Title = "Patients";
        }

        void AddNewItem(object sender, EventArgs args)
        {
            this.PerformSegue("showDetail", this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.LeftBarButtonItem = EditButtonItem;

            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
            NavigationItem.RightBarButtonItem = addButton;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            refreshData();
        }

        private async void refreshData()
        {
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;

			//Step 2: Sync data from service

            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "showDetail")
            {
                var indexPath = TableView.IndexPathForSelectedRow;

				//Step 3: Pass existing user to Detail view
            }
        }

		//Step 1: Create PatientsDataSource
    }
}