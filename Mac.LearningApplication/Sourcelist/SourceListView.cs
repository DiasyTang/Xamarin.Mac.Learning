using System;
using AppKit;
using Foundation;
namespace Mac.LearningApplication.Sourcelist
{
    [Register("SourceListView")]
    public class SourceListView:NSOutlineView
    {
        public SourceListDataSource Data{
            get => (SourceListDataSource)this.DataSource;
        }
        public SourceListView()
        {
        }

        public SourceListView(IntPtr handle):base(handle){
            
        }

        public SourceListView(NSCoder coder):base(coder){
            
        }

        public SourceListView(NSObjectFlag t):base(t){
            
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }

        public void Initialize(){
            this.DataSource = new SourceListDataSource(this);
            this.Delegate = new SourceListDelegate(this);
        }

        public void AddItem(SourceListItem item){
            if(Data!=null){
                Data.Items.Add(item);
            }
        }

        public delegate void ItemSelectedDelegate(SourceListItem item);
        public event ItemSelectedDelegate ItemSelected;

        internal void RaiseItemSelected(SourceListItem item){
            this.ItemSelected?.Invoke(item);
        }
    }
}
