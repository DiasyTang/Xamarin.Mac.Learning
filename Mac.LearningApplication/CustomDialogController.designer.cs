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
	[Register ("CustomDialogController")]
	partial class CustomDialogController
	{
		[Outlet]
		AppKit.NSTextField Description { get; set; }

		[Outlet]
		AppKit.NSTextField Title { get; set; }

		[Action ("CancelDialog:")]
		partial void CancelDialog (Foundation.NSObject sender);

		[Action ("OkDialog:")]
		partial void OkDialog (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Title != null) {
				Title.Dispose ();
				Title = null;
			}

			if (Description != null) {
				Description.Dispose ();
				Description = null;
			}
		}
	}
}
