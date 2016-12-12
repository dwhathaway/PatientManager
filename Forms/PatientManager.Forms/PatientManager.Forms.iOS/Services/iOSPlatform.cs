using System;
using PatientManager.Common;
using PatientManager.Forms.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(iOSPlatform))]
namespace PatientManager.Forms.iOS.Services
{
	public class iOSPlatform : IPlatform
	{
		public string GetSyncStore()
		{
			return "syncstore.db";
		}
	}
}
