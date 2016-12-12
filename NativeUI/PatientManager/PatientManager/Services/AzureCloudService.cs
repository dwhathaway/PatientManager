using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace PatientManager.Common
{
    public class AzureCloudService : ICloudService
    {
        /// <summary>
        /// The Client reference to the Azure Mobile App
        /// </summary>
        private MobileServiceClient Client { get; set; }

		/// <summary>
		/// Reference to the platform-specific code
		/// </summary>
		IPlatform PlatformProvider { get; set; }

        public AzureCloudService()
        {
            //Create our client
            Client = new MobileServiceClient("https://patientmanagerbackend20161004105214.azurewebsites.net/");

			//PlatformProvider = DependencyService.Get<IPlatform>();
			//if (PlatformProvider == null)
			//{
			//	throw new InvalidOperationException("No Platform Provider");
			//}
        }

		#region Offline Sync
        async Task InitializeAsync()
		{
			// Short circuit - local database is already initialized
			if (Client.SyncContext.IsInitialized)
			{
				Debug.WriteLine("InitializeAsync: Short Circuit");
				return;
			}

			// Create a reference to the local sqlite store
			Debug.WriteLine("InitializeAsync: Initializing store");
			var store = new MobileServiceSQLiteStore("tasklist.db");

			// Define the database schema
			Debug.WriteLine("InitializeAsync: Defining Datastore");
			store.DefineTable<Patient>();

			// Actually create the store and update the schema
			Debug.WriteLine("InitializeAsync: Initializing SyncContext");
			await Client.SyncContext.InitializeAsync(store);

			// Do the sync
			Debug.WriteLine("InitializeAsync: Syncing Offline Cache");
			await SyncOfflineCacheAsync();
		}

		public async Task SyncOfflineCacheAsync()
		{
			Debug.WriteLine("SyncOfflineCacheAsync: Initializing...");
			await InitializeAsync();

			// Push the Operations Queue to the mobile backend
			Debug.WriteLine("SyncOfflineCacheAsync: Pushing Changes");
			await Client.SyncContext.PushAsync();

			// Pull each sync table
			Debug.WriteLine("SyncOfflineCacheAsync: Pulling Patients table");
			var patientsTable = await GetTableAsync<Patient>(); 
			await patientsTable.PullAsync();
		}

		#endregion

		#region ICloudService Interface

		/// <summary>
		/// Returns a link to the specific table.
		/// </summary>
		/// <typeparam name="T">The model</typeparam>
		/// <returns>The table reference</returns>
		public async Task<ICloudTable<T>> GetTableAsync<T>() where T : TableData
		{
			await InitializeAsync();
			return new AzureCloudTable<T>(Client);
		}

		#endregion
	}
}
