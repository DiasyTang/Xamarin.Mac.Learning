// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Mac.LearningApplication
{
    [Register ("SplitViewController")]
    partial class SplitViewController
    {
        [Outlet]
        AppKit.NSSplitViewItem LeftViewController { get; set; }

        [Outlet]
        AppKit.NSSplitViewItem RightViewController { get; set; }

        [Outlet]
        AppKit.NSSplitView SplitView { get; set; }
        
        void ReleaseDesignerOutlets ()
        {
            if (LeftViewController != null) {
                LeftViewController.Dispose ();
                LeftViewController = null;
            }

            if (RightViewController != null) {
                RightViewController.Dispose ();
                RightViewController = null;
            }

            if (SplitView != null) {
                SplitView.Dispose ();
                SplitView = null;
            }
        }
    }
}
