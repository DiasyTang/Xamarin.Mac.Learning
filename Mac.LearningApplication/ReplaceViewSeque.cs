using System;
using AppKit;
using Foundation;

namespace Mac.LearningApplication
{
    [Register("ReplaceViewSeque")]
    public class ReplaceViewSeque : NSStoryboardSegue
    {
        #region Constructors
        public ReplaceViewSeque()
        {
        }

        public ReplaceViewSeque(string identifier, NSObject sourceController, NSObject destinationController)
        {

        }

        public ReplaceViewSeque(IntPtr handle) : base(handle)
        {

        }

        public ReplaceViewSeque(NSObjectFlag x) : base(x)
        {

        }
        #endregion

        #region Override Methods
        public override void Perform()
        {
            var source = SourceController as NSViewController;
            var destination = DestinationController as NSViewController;

            if (source == null)
            {
                var window = NSApplication.SharedApplication.KeyWindow;
                window.ContentViewController = destination;
                window.ContentViewController?.RemoveFromParentViewController();
            }
            else
            {
                source.RemoveFromParentViewController();
            }
        }
        #endregion
    }
}
