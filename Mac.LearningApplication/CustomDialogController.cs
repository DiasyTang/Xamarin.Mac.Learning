// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;

namespace Mac.LearningApplication
{
    public partial class CustomDialogController : NSViewController
    {
        #region Private Variable
        private string _dialogTitle = "Title";
        private string _dialogDescription = "Description";
        private NSViewController _presentor;
        #endregion

        #region Computed Properties
        public string DialogTitle
        {
            get => _dialogTitle;
            set => _dialogTitle = value;
        }

        public string DialogDescription
        {
            get => _dialogDescription;
            set => _dialogDescription = value;
        }

        public NSViewController Presentor
        {
            get => _presentor;
            set => _presentor = value;
        }
        #endregion

        #region Constructors
        public CustomDialogController(IntPtr handle) : base(handle)
        {
        }
        #endregion

        public override void ViewWillAppear()
        {
            base.ViewWillAppear();
            Title.StringValue = DialogTitle;
            Description.StringValue = DialogDescription;
        }

        private void CloseDialog(){
            Presentor.DismissViewController(this);
        }

        partial void CancelDialog(NSObject sender)
        {
            RaiseDialogCanceled();
            CloseDialog();
        }

        partial void OkDialog(NSObject sender)
        {
            RaiseDialogAccepted();
            CloseDialog();
        }

        public EventHandler DialogAccepted;
        public EventHandler DialogCanceled;

        internal void RaiseDialogAccepted(){
            this.DialogAccepted?.Invoke(this, EventArgs.Empty);
        }

        internal void RaiseDialogCanceled(){
            this.DialogAccepted?.Invoke(this, EventArgs.Empty);
        }

    }
}
