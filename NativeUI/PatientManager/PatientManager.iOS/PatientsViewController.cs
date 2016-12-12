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
        PatientsDataSource _patientsDataSource;

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
			var table = await AppDelegate.CloudService.GetTableAsync<Patient>();
			IEnumerable<Patient> patients = await table.ReadAllItemsAsync();

            TableView.Source = _patientsDataSource = new PatientsDataSource(this, patients.ToList<Patient>());
            TableView.ReloadData();

            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "showDetail")
            {
                var indexPath = TableView.IndexPathForSelectedRow;

				//Step 3: Pass existing user to Detail view
                var item = indexPath == null ? new Patient() : _patientsDataSource.Objects[indexPath.Row];

               ((AddPatientViewController)segue.DestinationViewController).SetDetailItem(item);
            }
        }

		//Step 1: Create PatientsDataSource
        class PatientsDataSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("DataSourceCell");

            List<Patient> objects = new List<Patient>();

            PatientsViewController controller;

            public PatientsDataSource(PatientsViewController controller, List<Patient> groceries)
            {
                this.controller = controller;
                this.objects = groceries;
            }

            public IList<Patient> Objects
            {
                get { return objects; }
            }

            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return objects.Count;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = (UITableViewCell)tableView.DequeueReusableCell(CellIdentifier, indexPath);

                cell.TextLabel.Text = objects[indexPath.Row].FullName.ToString();

                return cell;
            }

            public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
            {
                return true;
            }
            
            public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
            {
                if (editingStyle == UITableViewCellEditingStyle.Delete)
                {
                    // Delete the row from the data source.
                    controller.TableView.BeginUpdates();

                    var patient = objects[indexPath.Row];
                    objects.RemoveAt(indexPath.Row);

					deletePatient(patient);

                    controller.TableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);

                    controller.TableView.EndUpdates();
                }
                else if (editingStyle == UITableViewCellEditingStyle.Insert)
                {
                    // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
                }
            }

			async void deletePatient(Patient patient)
			{
				var table = await AppDelegate.CloudService.GetTableAsync<Patient>();
				await table.DeleteItemAsync(patient);
			}
        }
    }
}