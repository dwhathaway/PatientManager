using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace PatientManager.Common
{
	public interface ICloudService
	{
		Task<ICloudTable<T>> GetTableAsync<T>() where T : TableData;

		//Task<MobileServiceUser> LoginAsync();

		//Task LogoutAsync();

		//Task<AppServiceIdentity> GetIdentityAsync();

		Task SyncOfflineCacheAsync();
	}
}
