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
        }
    }
}