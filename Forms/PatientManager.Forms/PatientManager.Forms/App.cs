using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PatientManager.Common;
using Xamarin.Forms;

namespace PatientManager.Forms
{
    public class App : Application
    {
        public App()
        {
            ServiceLocator.Add<ICloudService, AzureCloudService>();

            // The root page of your application
            MainPage = new NavigationPage(new PatientsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}