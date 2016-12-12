using System;
using System.IO;
using PatientManager.Common;
using PatientManager.Forms.Droid.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DroidPlatform))]
namespace PatientManager.Forms.Droid.Services
{
	public class DroidPlatform : IPlatform
	{
		public DroidPlatform()
		{
		}

		public string GetSyncStore()
		{
			var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "syncstore.db");

			if (!File.Exists(path))
			{
				File.Create(path).Dispose();
			}

			return path;
		}
	}
}
