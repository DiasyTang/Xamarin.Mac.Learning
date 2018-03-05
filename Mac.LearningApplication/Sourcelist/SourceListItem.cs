using System;
using Foundation;
using AppKit;
using System.Collections;
using System.Collections.Generic;
namespace Mac.LearningApplication.Sourcelist
{
    public class SourceListItem:NSObject,IEnumerator,IEnumerable
    {
        private string _title;
        private NSImage _icon;
        private string _tag;
        private int _position = -1;
        private List<SourceListItem> _items = new List<SourceListItem>();

        public delegate void ClickedDelegate();
        public event ClickedDelegate Clicked;

        internal void RasieClickedEvent(){
            this.Clicked?.Invoke();
        }

        public string Title{
            get => _title;
            set => _title = value;
        }

        public NSImage Icon{
            get => _icon;
            set => _icon = value;
        }

        public string Tag{
            get => _tag;
            set => _tag = value;
        }

        public SourceListItem this[int index]{
            get => _items[index];
            set => _items[index] = value;
        }

        public int Count{
            get => _items.Count;
        }

        public bool HasChildren{
            get => Count > 0;
        }

        public IEnumerator GetEnumerator(){
            _position++;
            return (IEnumerator)this;
        }

        public void Reset(){
            _position = -1;
        }

        public object Current{
            get{
                try{
                    return _items[_position];
                }
                catch(IndexOutOfRangeException){
                    throw new InvalidOperationException();
                }
            }
        }

        public SourceListItem()
        {
        }

        public SourceListItem(string title){
            this._title = title;
        }

        public SourceListItem(string title,ClickedDelegate clicked){
            this._title = title;
            this.Clicked = clicked;
        }

        public SourceListItem(string title,string icon){
            this._title = title;
            this._icon = NSImage.ImageNamed(icon);
        }

        public SourceListItem(string title,string icon,ClickedDelegate clicked){
            this._title = title;
            this._icon = NSImage.ImageNamed(icon);
            this.Clicked = clicked;
        }

        public SourceListItem(string title,NSImage icon){
            this._icon = icon;
            this._title = title;
        }

        public SourceListItem(string title,NSImage icon,ClickedDelegate clicked){
            this._title = title;
            this._icon = icon;
            this.Clicked = clicked;
        }

        public SourceListItem(string title,NSImage icon,string tag){
            this._title = title;
            this._icon = icon;
            this._tag = tag;
        }

        public SourceListItem(string title,NSImage icon,string tag,ClickedDelegate clicked){
            this._title = title;
            this._icon = icon;
            this._tag = tag;
            this.Clicked = clicked;
        }

        public void AddItem(string title){
            _items.Add(new SourceListItem(title));
        }

        public void AddItem(string title,ClickedDelegate clicked){
            _items.Add(new SourceListItem(title,clicked));
        }

        public void AddItem(string title,string icon){
            _items.Add(new SourceListItem(title,icon));
        }

        public void AddItem(string title,string icon,ClickedDelegate clicked){
            _items.Add(new SourceListItem(title,icon,clicked));
        }

        public void AddItem(string title,NSImage icon){
            _items.Add(new SourceListItem(title,icon));
        }

        public void AddItem(string title,NSImage icon,ClickedDelegate clicked){
            _items.Add(new SourceListItem(title,icon,clicked));
        }

        public void AddItem(string title,NSImage icon,string tag){
            _items.Add(new SourceListItem(title,icon,tag));
        }

        public void AddItem(string title,NSImage icon,string tag,ClickedDelegate clicked){
            _items.Add(new SourceListItem(title,icon,tag,clicked));
        }

        public void Insert(int n,SourceListItem item){
            _items.Insert(n,item);
        }

        public void RemoveItem(SourceListItem item){
            _items.Remove(item);
        }

        public void RemoveItem(int n){
            _items.RemoveAt(n);
        }

        public void Clear(){
            _items.Clear();
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _items.Count;
        }

    }
}
