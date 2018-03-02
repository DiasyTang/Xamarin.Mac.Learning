using System.IO;
using System.Threading.Tasks;
using AppKit;
using Foundation;

namespace Mac.LearningApplication
{
    public class EditorWindowDelegate : NSWindowDelegate
    {
        #region Computed Properties
        public NSWindow Window { get; set; }
        #endregion

        #region Constructors
        public EditorWindowDelegate(NSWindow window)
        {
            this.Window = window;
        }
        #endregion

        #region Override Methods
        public override bool WindowShouldClose(NSObject sender)
        {
            if (Window.DocumentEdited)
            {
                var alert = new NSAlert()
                {
                    AlertStyle = NSAlertStyle.Critical,
                    InformativeText = "Save changes to document before closing window?",
                    MessageText = "Save Document",
                };
                alert.AddButton("Save");
                alert.AddButton("Lose Changes");
                alert.AddButton("Cancel");
                var result = alert.RunSheetModal(Window);

                switch (result)
                {
                    case 1000:
                        var viewController = Window.ContentViewController as ViewController;
                        if (Window.RepresentedUrl != null)
                        {
                            var path = Window.RepresentedUrl.Path;
                            File.WriteAllText(path, viewController.Text);
                            return true;
                        }
                        else
                        {
                            var dlg = new NSSavePanel();
                            dlg.Title = "Save Document";
                            dlg.BeginSheet(Window, (rslt) =>
                            {
                                if (rslt == 1)
                                {
                                    var path = dlg.Url.Path;
                                    File.WriteAllText(path, viewController.Text);
                                    Window.DocumentEdited = false;
                                    viewController.View.Window.SetTitleWithRepresentedFilename(Path.GetFileName(path));
                                    viewController.View.Window.RepresentedUrl = dlg.Url;
                                }
                            });
                            return false;
                        }
                    case 1001:
                        return true;
                    case 1002:
                        return false;

                }
            }
            return true;
        }
    }
}
#endregion