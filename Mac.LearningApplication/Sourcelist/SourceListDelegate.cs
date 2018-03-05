using System;
using AppKit;
using Foundation;
namespace Mac.LearningApplication.Sourcelist
{
    public class SourceListDelegate:NSOutlineViewDelegate
    {
        private SourceListView _controller;

        public SourceListDelegate(SourceListView controller)
        {
            this._controller = controller;
        }

        public override bool ShouldEditTableColumn(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
        {
            return false;
        }

        public override NSCell GetCell(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
        {
            nint row = outlineView.RowForItem(item);
            return tableColumn.DataCellForRow(row);
        }

        public override bool IsGroupItem(NSOutlineView outlineView, NSObject item)
        {
            return ((SourceListItem)item).HasChildren;
        }

        public override NSView GetView(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
        {
            NSTableCellView view = null;

            if(((SourceListItem)item).HasChildren){
                view = (NSTableCellView)outlineView.MakeView("HeaderCell", this);
            }
            else{
                view = (NSTableCellView)outlineView.MakeView("DataCell", this);
                view.ImageView.Image = ((SourceListItem)item).Icon;
            }

            view.TextField.StringValue = ((SourceListItem)item).Title;

            return view;
        }

        public override bool ShouldSelectItem(NSOutlineView outlineView, NSObject item)
        {
            return (outlineView.GetParent(item) != null);
        }

        public override void SelectionDidChange(NSNotification notification)
        {
            NSIndexSet selectedIndexes = _controller.SelectedRows;

            if(selectedIndexes.Count>1){
                
            }
            else{
                var item = _controller.Data.ItemForRow((int)selectedIndexes.FirstIndex);

                if(item!=null){
                    item.RasieClickedEvent();
                    _controller.RaiseItemSelected(item);
                }
            }
        }
    }
}
