using System;
using System.ComponentModel;

using UIKit;
using Foundation;

namespace XamarinTemplate.iOS {
    
    [Register("InputBorder"), DesignTimeVisible(true)]
    public partial class InputBorder : UITextField {

        public string BorderColor = "EEEEEE";

        public InputBorder () {

            float red, green, blue;

            red = Convert.ToInt32(BorderColor.Substring(0, 2), 16) / 255f;
            green = Convert.ToInt32(BorderColor.Substring(2, 2), 16) / 255f;
            blue = Convert.ToInt32(BorderColor.Substring(4, 2), 16) / 255f;

            this.Layer.BorderColor = UIColor.FromRGBA(red, green, blue, 1.0f).CGColor;
            this.Layer.BorderWidth = 1.0f;
            this.Layer.CornerRadius = 10;
            this.Layer.MasksToBounds = true;

        }

        public InputBorder(IntPtr handle) : base(handle) {

            float red, green, blue;

            red = Convert.ToInt32(BorderColor.Substring(0, 2), 16) / 255f;
            green = Convert.ToInt32(BorderColor.Substring(2, 2), 16) / 255f;
            blue = Convert.ToInt32(BorderColor.Substring(4, 2), 16) / 255f;

            this.Layer.BorderColor = UIColor.FromRGBA(red, green, blue, 1.0f).CGColor;
            this.Layer.BorderWidth = 1.0f;
            this.Layer.CornerRadius = 10;
            this.Layer.MasksToBounds = true;

        }

    }

}
