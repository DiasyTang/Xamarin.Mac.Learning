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

            //if (source == null)
            //{
            //    var window = NSApplication.SharedApplication.KeyWindow;
            //    window.ContentViewController = destination;
            //    window.ContentViewController?.RemoveFromParentViewController();
            //}
            //else
            //{
            //    source.RemoveFromParentViewController();
            //}

            if(source.View.Subviews.Length>0){
                source.View.Subviews[0].RemoveFromSuperview();
            }

            destination.View.Frame = new CoreGraphics.CGRect(0, 0, source.View.Frame.Width, source.View.Frame.Height);
            destination.View.AutoresizingMask = NSViewResizingMask.HeightSizable | NSViewResizingMask.WidthSizable;
            source.View.AddSubview(destination.View);
        }
        #endregion
    }
}
