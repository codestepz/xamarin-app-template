using System;
using CoreGraphics;
using UIKit;

using XamarinTemplate;
using XamarinTemplate.Schemas;

namespace XamarinTemplate.iOS {
    
    public partial class BaseScreen : UIViewController {

        protected RestService api = new RestService();

        public BaseScreen (IntPtr handle) : base(handle) { }

        public override void DidReceiveMemoryWarning () {
            base.DidReceiveMemoryWarning();
        }

        // ======================================================================
        // Font
        // ======================================================================

        protected UIFont FontPrompt() { return UIFont.FromName("Prompt-Regular", 16f); }
        protected UIFont FontKanit() { return UIFont.FromName("Kanit-Regular", 16f); }
        protected UIFont FontChatthai() { return UIFont.FromName("CSChatthai-Regular", 16f); }

        // ======================================================================
        // Color
        // ======================================================================

        public string colorGreen = "3EA867";
        public string colorBlack = "2F2F2F";
        public string colorGray = "B2B0B0";
        public string colorGrayBold = "787878";
        public string colorWhite = "FFFFFF";
        public string colorBlue = "2280F9";

        public UIColor getHexToColor (string BorderColor) {

            float red, green, blue;

            red = Convert.ToInt32(BorderColor.Substring(0, 2), 16) / 255f;
            green = Convert.ToInt32(BorderColor.Substring(2, 2), 16) / 255f;
            blue = Convert.ToInt32(BorderColor.Substring(4, 2), 16) / 255f;

            return UIColor.FromRGBA(red, green, blue, 1.0f);

        }

        // ======================================================================
        // Background
        // ======================================================================

        public UIImageView ViewWallpaper () {
            UIImageView viewBackground = new UIImageView(UIImage.FromBundle("Wallpaper"));
            viewBackground.Frame = new CGRect(0, 0, View.Frame.Width, View.Frame.Height);
            return viewBackground;
        }

        // ======================================================================
        // Authentication
        // ======================================================================

        protected bool AuthenticationStatus () {

            try {

                // Create an instance of our AppDelegate
                var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

                // Return Data
                return appDelegate.AuthenticatedStatus;

            } catch (Exception ex) {

                // Console
                Console.WriteLine(ex.ToString());

                // Return Data
                return false;

            }

        }

        // ======================================================================
        // Response
        // ======================================================================

        protected ResponseSchema GetResponse() {

            try {

                // Create an instance of our AppDelegate
                AppDelegate appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

                // Response
                return api.toObject(appDelegate.Storage);

            } catch (Exception ex) {

                // Console
                Console.WriteLine(ex.ToString());

                // Return Data
                return null;

            }

        }

        protected void UpdateResponse (ResponseSchema dataResponse) {

            try {

                // Create an instance of our AppDelegate
                AppDelegate appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

                // Update Data
                appDelegate.Storage = api.toString(dataResponse);

            } catch (Exception ex) {

                // Console
                Console.WriteLine(ex.ToString());

            }

        }

        protected void ClearRespons () {

            // Create an instance of our AppDelegate
            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
            appDelegate.Storage = null;

        }

        // ======================================================================
        // Frame Layput
        // ======================================================================

        public CGRect SetFrameFullScreen (UIView view, float marginTop, float marginRight, float marginBottom, float marginLeft) {
            return new CGRect(marginLeft, marginTop, view.Frame.Width - (marginLeft + marginRight), view.Frame.Height - (marginTop + marginBottom));
        }

        public CGRect SetFrameCenter (UIView view, float widthSize, float heightSize) {
            return new CGRect(((view.Frame.Width - widthSize) / 2), ((view.Frame.Height - heightSize) / 2), widthSize, heightSize);
        }

        public CGRect SetFrameCenterHorizontal (UIView view, float marginTop, float widthSize, float heightSize) {
            return new CGRect(((view.Frame.Width - widthSize) / 2), marginTop, widthSize, heightSize);
        }

        public CGRect getFrameCenterVertical (UIView view, float marginLeft, float widthSize, float heightSize) {
            return new CGRect(marginLeft, ((view.Frame.Height - heightSize) / 2), widthSize, heightSize);
        }

        // ======================================================================
        // Custom
        // ======================================================================

        protected void OpenAlert (string titleAlert, string textAlert) {
            var alert = UIAlertController.Create(titleAlert, textAlert, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
            PresentViewController(alert, animated: true, completionHandler: null);
        }

    }

}