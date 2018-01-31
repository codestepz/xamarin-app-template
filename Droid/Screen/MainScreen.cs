using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using XamarinTemplate;
using XamarinTemplate.Schemas;

namespace XamarinTemplate.Droid {
    
    [Activity(Label = "XamarinTemplate", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainScreen : BaseScreen  {

        protected override void OnCreate (Bundle savedInstanceState) {
            
            base.OnCreate(savedInstanceState);

            // Set Layout
            SetContentView(Resource.Layout.Main);

        }

    }

}