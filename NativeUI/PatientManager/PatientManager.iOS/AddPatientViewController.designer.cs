// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PatientManager.iOS
{
    [Register ("AddPatientViewController")]
    partial class AddPatientViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSave { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtBloodPressure { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtBloodType { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtFirstName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtHeight { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLastName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtWeight { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnSave != null) {
                btnSave.Dispose ();
                btnSave = null;
            }

            if (txtBloodPressure != null) {
                txtBloodPressure.Dispose ();
                txtBloodPressure = null;
            }

            if (txtBloodType != null) {
                txtBloodType.Dispose ();
                txtBloodType = null;
            }

            if (txtFirstName != null) {
                txtFirstName.Dispose ();
                txtFirstName = null;
            }

            if (txtHeight != null) {
                txtHeight.Dispose ();
                txtHeight = null;
            }

            if (txtLastName != null) {
                txtLastName.Dispose ();
                txtLastName = null;
            }

            if (txtWeight != null) {
                txtWeight.Dispose ();
                txtWeight = null;
            }
        }
    }
}