// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;

namespace Mac.LearningApplication
{
	public partial class PreferenceWindowController : NSWindowController
	{
		public PreferenceWindowController (IntPtr handle) : base (handle)
		{
		}

        public override void WindowDidLoad()
        {
            base.WindowDidLoad();
            Window.Delegate = new PreferenceWindowDelegate(Window);
            Toolbar.SelectedItemIdentifier = "Profile";
        }
	}
}
