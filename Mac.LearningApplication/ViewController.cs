using System;

using AppKit;
using CoreGraphics;
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

        partial void OpenPanelClicked(NSObject sender)
        {
            var dlg = NSOpenPanel.OpenPanel;
            dlg.CanChooseFiles = true;
            dlg.CanChooseDirectories = true;
            dlg.AllowedFileTypes = new string[] { "txt", "html", "md", "css" };

            if(dlg.RunModal()==1){
                var url = dlg.Urls[0];

                if(url!=null){
                    var path = url.Path;
                    TestLabel.StringValue = path;
                }
            }
        }

        public void  ConfigureEditor(){
            TestLabel.TextColor = NSColor.Red;
        }

        partial void AlertTitleClicked(NSObject sender)
        {
            var alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Informational,
                InformativeText = "This is the body of the alert where you describe the situation and any actions to correct it.",
                MessageText = "Alert Title"
            };
            alert.RunModal();
        }

        partial void AlertAddsAlertButton(NSObject sender)
        {
            var alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Informational,
                InformativeText = "This is the body of the alert where you describe the situation and any actions to correct it.",
                MessageText = "Alert Title"
            };
            alert.AddButton("OK");
            alert.AddButton("Cancel");
            alert.AddButton("Maybe");
            alert.BeginSheetForResponse(this.View.Window,(result)=>{
                Console.WriteLine("Alert Result:{0}",result);
            });
        }

        partial void SuppressAlertClicked(NSObject sender)
        {
            var alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Informational,
                InformativeText = "This is the body of the alert where you describe the situation and any actions to correct it.",
                MessageText = "Alert Title"
            };
            alert.AddButton("OK");
            alert.AddButton("Cancel");
            alert.AddButton("Maybe");
            alert.ShowsSuppressionButton = true;
            var result = alert.RunModal();
            Console.WriteLine("Alert Result:{0},Suppress:{1}",result,alert.SuppressionButton.State==NSCellStateValue.On);
        }

        partial void CustomSubViewClicked(NSObject sender)
        {
            var input = new NSTextField(new CGRect(0, 0, 300, 20));

            var alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Informational,
                InformativeText = "This is the body of the alert where you describe the situation and any actions to correct it.",
                MessageText = "Alert Title"
            };
            alert.AddButton("OK");
            alert.AddButton("Cancel");
            alert.AddButton("Maybe");
            alert.ShowsSuppressionButton = true;
            alert.AccessoryView = input;
            alert.Layout();
            var result = alert.RunModal();
            Console.WriteLine("Alert Result: {0}, Suppress: {1}",result,alert.SuppressionButton.State==NSCellStateValue.On);
        }
    }
}
