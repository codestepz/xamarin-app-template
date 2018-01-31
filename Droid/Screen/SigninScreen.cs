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

namespace XamarinTemplate.Droid.Screen {
    
    [Activity(Label = "SigninScreen")]
    public class SigninScreen : BaseScreen {

        protected ProgressDialog progress;

        protected override void OnCreate(Bundle savedInstanceState) {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Signin);

            // Username & Password
            TextView username = FindViewById<TextView>(Resource.Id.SigninUsername);
            TextView password = FindViewById<TextView>(Resource.Id.SigninPassword);

            // autofucus = false
            username.Focusable = false;
            password.Focusable = false;

            // ปุ่มเข้าสู่ระบบ
            Button BtnSignin = FindViewById<Button>(Resource.Id.BtnSignin);
            BtnSignin.Click += async (sender, e) => {

                // แสดง Loading
                progress = new ProgressDialog(this);
                progress.Indeterminate = true;
                progress.SetProgressStyle(ProgressDialogStyle.Spinner);
                progress.SetMessage("Loading... Please wait...");
                progress.Show();

                // พบข้อมูล
                if (!string.IsNullOrWhiteSpace(username.Text) && !string.IsNullOrWhiteSpace(password.Text)) {

                    // Create a new Signin  
                    var dateParams = new ParamsSchema {
                        Controller = "login",
                        Action = "verify",
                        Data = api.toString(new SigninSchema {
                            username = username.Text,
                            password = password.Text,
                        })
                    };

                    // handling the answer
                    var result = await api.POSTAsync(dateParams);

                    // พบข้อมูล
                    if (!string.IsNullOrWhiteSpace(result)) {

                        // Console
                        Console.WriteLine(result);

                        // Hide
                        progress.Dismiss();


                        // Alert
                        this.OpenAlert("แจ้งเตือน", "เข้าสู่ระบบสำเร็จแล้ว !");

                    } else {

                        // Hide
                        progress.Dismiss();

                        // Alert
                        this.OpenAlert("แจ้งเตือน", "ไม่พบข้อมูล กรุณาตรวจสอบข้อมูลอีกครั้ง !");

                    }

                } else {

                    // Hide
                    progress.Dismiss();

                    // Alert
                    this.OpenAlert("แจ้งเตือน", "ข้อมูลไม่ครบถ้วน กรุณาตรวจสอบข้อมูลอีกครั้ง !");

                }

            };

        }

    }

}