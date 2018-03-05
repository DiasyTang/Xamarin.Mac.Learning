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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        AppKit.NSTextField TestLabel { get; set; }

        [Action ("AlertAddsAlertButton:")]
        partial void AlertAddsAlertButton (Foundation.NSObject sender);

        [Action ("AlertTitleClicked:")]
        partial void AlertTitleClicked (Foundation.NSObject sender);

        [Action ("CustomSubViewClicked:")]
        partial void CustomSubViewClicked (Foundation.NSObject sender);

        [Action ("OpenPanelClicked:")]
        partial void OpenPanelClicked (Foundation.NSObject sender);

        [Action ("SuppressAlertClicked:")]
        partial void SuppressAlertClicked (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (TestLabel != null) {
                TestLabel.Dispose ();
                TestLabel = null;
            }
        }
    }
}
