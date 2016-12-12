using PatientManager.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using PatientManager.Forms.Pages;
using PatientManager.Forms.ViewModels;

namespace PatientManager.Forms
{
    public partial class PatientsPage : ContentPage
    {
        public PatientsPage()
        {
            InitializeComponent();

			PatientListViewModel patientsViewModel = new PatientListViewModel();

			//Step 1: Demonstrate configuring bindings in code
			patientsList.SetBinding(ListView.ItemsSourceProperty, "Items");
			patientsList.BindingContext = patientsViewModel;

			//Step 2: Add Toolbar Item to add new patients
			ToolbarItem addPatient = new ToolbarItem() { Icon = "ic_add_white_48dp.png", Text = "Add Patient" };

			addPatient.Clicked += async (object sender, EventArgs e) =>
			{
				await Navigation.PushAsync(new AddPatientPage());
			};

			this.ToolbarItems.Add(addPatient);

			//Step 3: Add support for selecting an item from the list
			patientsList.ItemSelected += async (object sender, SelectedItemChangedEventArgs e) =>
			{
				Patient patient = e.SelectedItem as Patient;
				await Navigation.PushAsync(new AddPatientPage(patient));
			};
        }
    }
}