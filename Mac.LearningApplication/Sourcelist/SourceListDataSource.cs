using System;
using AppKit;
using Foundation;
using System.Collections;
using System.Collections.Generic;

namespace Mac.LearningApplication.Sourcelist
{
    public class SourceListDataSource:NSOutlineViewDataSource
    {
        private SourceListView _controller;

        public List<SourceListItem> Items = new List<SourceListItem>();

        public SourceListDataSource(SourceListView controller)
        {
            this._controller = controller;
        }

        public override nint GetChildrenCount(NSOutlineView outlineView, NSObject item)
        {
            if(item==null){
                return Items.Count;
            }
            else{
                return ((SourceListItem)item).Count;
            }
        }

        public override bool ItemExpandable(NSOutlineView outlineView, NSObject item)
        {
            return ((SourceListItem)item).HasChildren;
        }

        public override NSObject GetChild(NSOutlineView outlineView, nint childIndex, NSObject item)
        {
            if(item==null){
                return Items[(int)childIndex];
            }
            else{
                return ((SourceListItem)item)[(int)childIndex];
            }
        }

        public override NSObject GetObjectValue(NSOutlineView outlineView, NSTableColumn tableColumn, NSObject item)
        {
            return new NSString(((SourceListItem)item).Title);
        }

        internal SourceListItem ItemForRow(int row){
            int index = 0;

            foreach(SourceListItem item in Items){
                if(row>=index&&row<=(index+item.Count)){
                    return item[row - index - 1];
                }
                index += item.Count + 1;
            }
            return null;
        }
    }
}
