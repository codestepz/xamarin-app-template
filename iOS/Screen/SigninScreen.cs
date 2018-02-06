using System;
using UIKit;

using XamarinTemplate;
using XamarinTemplate.Schemas;
using XamarinTemplate.Controls;

namespace XamarinTemplate.iOS {
    
    public partial class SigninScreen : BaseScreen {
        
        public SigninScreen (IntPtr handle) : base(handle) { }

        public override void ViewDidLoad () {
            
            base.ViewDidLoad();

            try {

                // Background
                View.AddSubview(this.ViewWallpaper());

                // Content
                this.CreateContent();

                // Username & Password
                string username = SigninUsername.Text.Trim();
                string password = SigninPassword.Text.Trim();

                // ปุ่มเข้าสู่ระบบ
                SigninButton.TouchUpInside += async delegate {

                    // portrait bounds
                    var bounds = UIScreen.MainScreen.Bounds;

                    // แสดง Loading
                    LoadingOverlay loadPop = new LoadingOverlay(bounds);
                    View.Add(loadPop);

                    // พบข้อมูล
                    if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password)) {

                        // Create a new Signin  
                        var dateParams = new ParamsSchema {
                            Controller = "login",
                            Action = "verify",
                            Data = api.toString(new SigninSchema {
                                username = username,
                                password = password
                            })
                        };

                        // handling the answer
                        string result = await api.POSTAsync(dateParams);

                        // พบข้อมูล
                        if (!String.IsNullOrEmpty(result)) {

                            // Console
                            Console.WriteLine(result);

                            // Create an instance of our AppDelegate
                            var appDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;

                            appDelegate.AuthenticatedStatus = true;
                            appDelegate.Storage = result;

                            // ซ่อน Loading
                            loadPop.Hide();

                            // แสดง Alert
                            OpenAlert("แจ้งเตือน", "เข้าสู่ระบบสำเร็จแล้ว !");

                        } else {

                            // ซ่อน Loading
                            loadPop.Hide();

                            // แสดง Alert
                            OpenAlert("แจ้งเตือน", "ไม่พบข้อมูล กรุณาตรวจสอบข้อมูลอีกครั้ง !");

                        }

                    } else {

                        // ซ่อน Loading
                        loadPop.Hide();

                        // แสดง Alert
                        OpenAlert("แจ้งเตือน", "ข้อมูลไม่ครบถ้วน กรุณาตรวจสอบข้อมูลอีกครั้ง !");

                    }

                };

            } catch (Exception ex) {

                // Console
                Console.WriteLine(ex.ToString());

                // แสดง Alert
                OpenAlert("แจ้งเตือน", "ระบบไม่สามารถเชื่อมต่อ Service ได้");

            }

        }

        public override void DidReceiveMemoryWarning () {
            base.DidReceiveMemoryWarning();
        }

        private void CreateContent () {

            try {

                // Margin Top
                float marginTop = (((float)View.Frame.Height - 240) / 2);

                // Layout
                SigninContentLayout.Frame = this.SetFrameFullScreen(View, 0, 0, 0, 0);

                // Title
                SigninTitle.Frame = this.SetFrameCenterHorizontal(SigninContentLayout, marginTop, 300, 40);
                SigninContentLayout.AddSubview(SigninTitle);

                marginTop += (40 + 30); // 40 Height, 30 MarginBottom

                // Username
                SigninUsername.Frame = this.SetFrameCenterHorizontal(SigninContentLayout, marginTop, 300, 40);
                SigninContentLayout.AddSubview(SigninUsername);

                marginTop += (40 + 10); // 40 Height, 10 MarginBottom

                // Password
                SigninPassword.Frame = this.SetFrameCenterHorizontal(SigninContentLayout, marginTop, 300, 40);
                SigninContentLayout.AddSubview(SigninPassword);

                marginTop += (40 + 20); // 40 Height, 20 MarginBottom

                // Button
                SigninButton.Frame = this.SetFrameCenterHorizontal(SigninContentLayout, marginTop, 300, 40);
                SigninContentLayout.AddSubview(SigninButton);

                marginTop += (40 + 20); // 40 Height, 20 MarginBottom

            } catch (Exception ex) {

                // Console
                Console.WriteLine(ex.ToString());

            }

        }

    }

}