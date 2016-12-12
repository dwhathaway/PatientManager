using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Common;
using PatientManager.Forms.ViewModels;
using Xamarin.Forms;

namespace PatientManager.Forms.Pages
{
    public partial class AddPatientPage : ContentPage
    {
		public AddPatientPage() : this(null)
		{
		}

        public AddPatientPage(Patient patient)
        {
            InitializeComponent();

			this.BindingContext = new AddPatientViewModel(patient) { Navigation = Navigation };
        }
    }
}
