using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using XamarinTemplate;
using XamarinTemplate.Schemas;

namespace XamarinTemplate.Droid {
    
    [Activity(Theme = "@style/Custom.Theme.ActionBar", Label = "XamarinTemplate", Icon = "@mipmap/icon")]
    public class BaseScreen : Activity {

        protected RestService api = new RestService();

        protected ISharedPreferences session;
        protected bool AuthenticatedStatus = false;

        protected String UserPreferences = "auth";
        protected String SESSION_EMAIL, SESSION_PASSWORD;

        protected override void OnCreate (Bundle savedInstanceState) {
            
            base.OnCreate(savedInstanceState);

            // Set Layout
            SetContentView(Resource.Layout.Main);

            // Hidden Navigation
            int uiOptions = (int) Window.DecorView.SystemUiVisibility;
            uiOptions |= (int) SystemUiFlags.HideNavigation;
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility) uiOptions;

            // Session
            session = GetSharedPreferences(UserPreferences, FileCreationMode.Private);

        }

        // ======================================================================
        // Font
        // ======================================================================

        protected Typeface FontPrompt () { return Typeface.CreateFromAsset(Assets, "Prompt-Regular.ttf"); }
        protected Typeface FontKanit () { return Typeface.CreateFromAsset(Assets, "Kanit-Regular.ttf"); }
        protected Typeface FontChatthai () { return Typeface.CreateFromAsset(Assets, "CSChatthai-Regular.ttf"); }

        // ======================================================================
        // Color
        // ======================================================================

        public string colorGreen = "3EA867";
        public string colorBlack = "2F2F2F";
        public string colorGray = "B2B0B0";
        public string colorGrayBold = "787878";
        public string colorWhite = "FFFFFF";
        public string colorBlue = "2280F9";

        // ======================================================================
        // Authentication
        // ======================================================================

        protected bool AuthenticationStatus () {

            try {

                // Get Data Storage
                ISharedPreferences preference = GetSharedPreferences(UserPreferences, FileCreationMode.Private);

                // return
                return (!string.IsNullOrWhiteSpace(preference.GetString("storage", null))) ? true : false;

            } catch (Exception ex) {

                // Console
                Console.WriteLine(ex.ToString());

                // Return
                return false;

            }

        }

        // ======================================================================
        // Response
        // ======================================================================

        protected ResponseSchema GetResponse () {

            try {

                // Get Data Storage
                ISharedPreferences preference = GetSharedPreferences(UserPreferences, FileCreationMode.Private);

                // Return Response
                return (!string.IsNullOrWhiteSpace(preference.GetString("storage", null))) ? api.toObject(preference.GetString("storage", null)) : null;

            } catch (Exception ex) {

                // Console
                Console.WriteLine(ex.ToString());

                // Return Data
                return null;

            }

        }

        protected void UpdateResponse (ResponseSchema dataResponse) {

            try {

                // Updated Session
                ISharedPreferencesEditor session_editor = session.Edit();

                // Update Data
                session_editor.PutString("storage", api.toString(dataResponse));
                session_editor.Commit();

            } catch (Exception ex) {

                // Console
                Console.WriteLine(ex.ToString());

            }

        }

        protected void ClearResponse () {

            try {

                // Updated Session
                ISharedPreferencesEditor session_editor = session.Edit();

                // Update Data
                session_editor.PutString("storage", null);
                session_editor.Commit();

            } catch (Exception ex) {

                // Console
                Console.WriteLine(ex.ToString());

            }

        }

        // ======================================================================
        // Custom
        // ======================================================================

        protected void OpenAlert (string titleAlert, string textAlert) {
            Console.WriteLine(titleAlert);
            Toast.MakeText(ApplicationContext, textAlert, ToastLength.Long).Show();
        }

        protected int toDp (float pixelValue) {
            return (int)((pixelValue) / Resources.DisplayMetrics.Density);
        }

        protected int toPixel (float dpValue) {
            return (int) TypedValue.ApplyDimension(ComplexUnitType.Dip, dpValue, Resources.DisplayMetrics);
        }

        protected void CleareCache () {

            try {

                var cachePath = System.IO.Path.GetTempPath();

                // If exist, delete the cache directory and everything in it recursivly
                if (System.IO.Directory.Exists(cachePath))
                    System.IO.Directory.Delete(cachePath, true);

                // If not exist, restore just the directory that was deleted
                if (!System.IO.Directory.Exists(cachePath))
                    System.IO.Directory.CreateDirectory(cachePath);

            } catch (Exception ex) {

                // Console
                Console.WriteLine(ex.ToString());

            }

        }

    }

}