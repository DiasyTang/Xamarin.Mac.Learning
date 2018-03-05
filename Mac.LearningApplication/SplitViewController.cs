using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using Mac.LearningApplication.Sourcelist;

namespace Mac.LearningApplication
{
    public partial class SplitViewController : AppKit.NSSplitViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public SplitViewController(IntPtr handle) : base(handle)
        {
            
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var left = LeftViewController.ViewController as LeftViewController;
            var right = RightViewController.ViewController as RightViewController;
            left.ViewTypeChanged += (viewType) =>
            {
                right.ShowView(viewType);
            };
        }
        #endregion
    }
}
