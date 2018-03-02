using System;

using AppKit;
using Foundation;

namespace Mac.LearningApplication
{
    public partial class ViewController : NSViewController
    {
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
        }

        public override void ViewWillAppear()
        {
            base.ViewWillAppear();
            this.View.Window.Title = "Untitled";
        }

        public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            switch(segue.Identifier){
                case "ModalSegue":
                    var dialog = segue.DestinationController as CustomDialogController;
                    dialog.DialogTitle = "MacDialog";
                    dialog.DialogDescription = "This is a sample dialog";
                    dialog.DialogAccepted += (s, e) =>
                    {
                        Console.WriteLine("Dialog accepted");
                    };
                    dialog.Presentor = this;
                    break;
                case "SheetSegue":
                    var sheet = segue.DestinationController as SheetViewController;
                    sheet.SheetAccepted += (s, e) =>
                    {
                        Console.WriteLine("User Name: {0} Password: {1}", sheet.UserName, sheet.Password);
                    };
                    sheet.Presentor = this;
                    break;
            }
        }
    }
}
