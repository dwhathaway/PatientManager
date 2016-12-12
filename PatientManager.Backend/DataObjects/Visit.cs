using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManager.Backend.DataObjects
{
    public class Visit : EntityData
    {
        DateTime VisitDate { get; set; }
    }
}