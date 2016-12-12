using Microsoft.Azure.Mobile.Server;

namespace PatientManager.Backend.DataObjects
{
    public class Patient : EntityData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public string BloodType { get; set; }

        public string BloodPressure { get; set; }
    }
}