// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace XamarinTemplate.iOS
{
    [Register ("MainScreen")]
    partial class MainScreen
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView MainContentLayout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MainTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MainContentLayout != null) {
                MainContentLayout.Dispose ();
                MainContentLayout = null;
            }

            if (MainTitle != null) {
                MainTitle.Dispose ();
                MainTitle = null;
            }
        }
    }
}