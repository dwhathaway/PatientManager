using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace PatientManager.Common
{
	public interface IPlatform
	{
		string GetSyncStore();
	}
}