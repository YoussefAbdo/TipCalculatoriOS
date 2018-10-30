using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TipCalculatoriOS
{
    class MyViewController : UIViewController
    {
        public MyViewController()
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.Yellow;

            UITextField totalAmount = new UITextField()
            {
                Frame = new CoreGraphics.CGRect(20, 28, View.Bounds.Width - 40, 35),
                KeyboardType = UIKeyboardType.DecimalPad,
                BorderStyle = UITextBorderStyle.RoundedRect,
                Placeholder = "Enter Total Amount",
            };

            UIButton calcButton = new UIButton(UIButtonType.Custom)
            {
                Frame = new CoreGraphics.CGRect(20, 71, View.Bounds.Width - 40, 45),
                BackgroundColor = UIColor.FromRGB(0, 0.5f, 0),
            };
            calcButton.SetTitle("Calculate", UIControlState.Normal);

            UILabel resultLabel = new UILabel()
            {
                Frame = new CoreGraphics.CGRect(20, 124, View.Bounds.Width - 40, 40),
                TextColor = UIColor.Blue,
                TextAlignment = UITextAlignment.Center,
                Font = UIFont.SystemFontOfSize(24),
                Text = "Tip is $0.00",
            };
            View.AddSubviews(totalAmount, calcButton, resultLabel);

            calcButton.TouchUpInside += (s, e) =>
            {
                double value = 0;
                Double.TryParse(totalAmount.Text, out value);
                resultLabel.Text = string.Format("Tip is {0:C}", value * 0.2);

                totalAmount.ResignFirstResponder();
            };
        }
    }
}