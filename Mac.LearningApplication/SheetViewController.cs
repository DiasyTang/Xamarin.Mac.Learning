// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;

namespace Mac.LearningApplication
{
    public partial class SheetViewController : NSViewController
    {
        public SheetViewController(IntPtr handle) : base(handle)
        {
        }

        #region Private Variables
        private string _userName = "";
        private string _password = "";
        private NSViewController _presentor;
        #endregion

        #region Computed Properties
        public string UserName
        {
            get => _userName;
            set => _userName = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public NSViewController Presentor
        {
            get => _presentor;
            set => _presentor = value;
        }
        #endregion

        #region Override Methods
        public override void ViewWillAppear()
        {
            base.ViewWillAppear();

            NameField.StringValue = UserName;
            PasswordField.StringValue = Password;

            NameField.Changed += (s, e) =>
            {
                UserName = NameField.StringValue;
            };

            PasswordField.Changed += (s, e) =>
            {
                Password = NameField.StringValue;
            };
        }
        #endregion

        #region Private Methods
        private void CloseSheet()
        {
            Presentor.DismissViewController(this);
        }
        #endregion

        #region Custom Actions
        partial void AcceptSheet(NSObject sender)
        {
            RasieSheetAccepted();
            CloseSheet();
        }

        partial void CancelSheet(NSObject sender)
        {
            RasieSheetCanceled();
            CloseSheet();
        }
        #endregion

        #region Events
        public EventHandler SheetAccepted;
        public EventHandler SheetCanceled;

        internal void RasieSheetCanceled()
        {
            SheetCanceled?.Invoke(this, EventArgs.Empty);
        }

        internal void RasieSheetAccepted()
        {
            SheetAccepted?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
