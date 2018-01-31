using System;
using UIKit;

namespace XamarinTemplate.iOS {
    
    public partial class MainScreen : BaseScreen {

        public MainScreen (IntPtr handle) : base(handle) { }

        public override void ViewDidLoad () {
            
            base.ViewDidLoad();

            // Background
            View.AddSubview(this.ViewWallpaper());

            // Layout
            MainContentLayout.Frame = this.SetFrameFullScreen(View, 0, 0, 0, 0);

            // Title
            MainTitle.Frame = this.SetFrameCenter(MainContentLayout, 200, 40);
            MainContentLayout.AddSubview(MainTitle);

        }

        public override void DidReceiveMemoryWarning () {
            base.DidReceiveMemoryWarning();
        }

    }

}