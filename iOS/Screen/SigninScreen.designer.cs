// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XamarinTemplate.iOS
{
    [Register ("SigninScreen")]
    partial class SigninScreen
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SigninButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView SigninContentLayout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        XamarinTemplate.iOS.InputBorder SigninPassword { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SigninTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        XamarinTemplate.iOS.InputBorder SigninUsername { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (SigninButton != null) {
                SigninButton.Dispose ();
                SigninButton = null;
            }

            if (SigninContentLayout != null) {
                SigninContentLayout.Dispose ();
                SigninContentLayout = null;
            }

            if (SigninPassword != null) {
                SigninPassword.Dispose ();
                SigninPassword = null;
            }

            if (SigninTitle != null) {
                SigninTitle.Dispose ();
                SigninTitle = null;
            }

            if (SigninUsername != null) {
                SigninUsername.Dispose ();
                SigninUsername = null;
            }
        }
    }
}