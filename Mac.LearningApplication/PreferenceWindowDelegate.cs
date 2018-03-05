using System;
using AppKit;
using Foundation;

namespace Mac.LearningApplication
{
    public class PreferenceWindowDelegate:NSWindowDelegate
    {
        public static AppDelegate App{
            get => (AppDelegate)NSApplication.SharedApplication.Delegate;
        }

        public NSWindow Window { get; set; }

        public PreferenceWindowDelegate(NSWindow window)
        {
            this.Window = window;
        }

        public override bool WindowShouldClose(NSObject sender)
        {
            App.UpdateWindowPreferences();
            return true;
        }
    }
}
