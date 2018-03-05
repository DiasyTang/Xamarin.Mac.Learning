using AppKit;
using Foundation;

namespace Mac.LearningApplication
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        #region Computed Properties
        public AppPreferences Preferences { get; set; } = new AppPreferences();
        #endregion

        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

        public override NSApplicationTerminateReply ApplicationShouldTerminate(NSApplication sender)
        {
            return NSApplicationTerminateReply.Now;
        }

        public override bool ApplicationShouldHandleReopen(NSApplication sender, bool hasVisibleWindows)
        {
            return true;
        }

        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {
            return true;
        }

        public void UpdateWindowPreferences(){
            for (int n = 0; n < NSApplication.SharedApplication.Windows.Length;++n){
                var content = NSApplication.SharedApplication.Windows[n].ContentViewController;
                if(content is ViewController){
                    (content as ViewController).ConfigureEditor();
                }
            }
        }
    }
}
