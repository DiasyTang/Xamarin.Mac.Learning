using System;

using AppKit;
using Foundation;

namespace Mac.LearningApplication
{
    public partial class ViewController : NSViewController
    {
        public string Text{
            get => DocumentEditor.Value;
            set => DocumentEditor.Value = value;
        }

        public bool DocumentEdited{
            get => View.Window.DocumentEdited;
            set => View.Window.DocumentEdited = value;
        }

        public ViewController(IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Do any additional setup after loading the view.
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            DocumentEditor.TextDidChange += (s, e) =>
            {
                DocumentEdited = true;
            };
        }

        public override void ViewWillAppear()
        {
            base.ViewWillAppear();
            this.View.Window.Title = "Untitled";

            View.Window.Delegate = new EditorWindowDelegate(View.Window);
        }
    }
}
