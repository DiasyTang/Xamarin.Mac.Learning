using System;
using AppKit;
using Foundation;

namespace Mac.LearningApplication
{
    [Register("AppPreferences")]
    public class AppPreferences:NSObject
    {
        #region Computed Properties
        [Export("DefaultLanguage")]
        public int DefaultLanguage{
            get => LoadInt("DefaultLanguage", 0);
            set
            {
                WillChangeValue(nameof(DefaultLanguage));
                SaveInt(nameof(DefaultLanguage), value, true);
                DidChangeValue(nameof(DefaultLanguage));
            }
        }

        [Export("SmartLinks")]
        public bool SmartLinks{
            get => LoadBool(nameof(SmartLinks), true);
            set{
                WillChangeValue(nameof(SmartLinks));
                SaveBool(nameof(SmartLinks),value,true);
                DidChangeValue(nameof(SmartLinks));
            }
        }

        [Export("EditorBackgroundColor")]
        public NSColor EditorBackgroundColor{
            get => LoadColor(nameof(EditorBackgroundColor), NSColor.White);
            set{
                WillChangeValue(nameof(EditorBackgroundColor));
                SaveColor(nameof(EditorBackgroundColor),value,true);
                DidChangeValue(nameof(EditorBackgroundColor));
            }
        }
            
        #endregion

        #region Public Methods
        public void SaveInt(string key, int value, bool sync)
        {
            NSUserDefaults.StandardUserDefaults.SetInt(value,key);
            if (sync)
                NSUserDefaults.StandardUserDefaults.Synchronize();
        }

        public  int LoadInt(string key, int defaultValue)
        {
            var number = NSUserDefaults.StandardUserDefaults.IntForKey(key);

            return number == null ? defaultValue : (int)number;
        }

        public void SaveBool(string key,bool value,bool sync){
            NSUserDefaults.StandardUserDefaults.SetBool(value,key);
            if (sync)
                NSUserDefaults.StandardUserDefaults.Synchronize();
        }

        public bool LoadBool(string key,bool defaultValue){
            bool? value = NSUserDefaults.StandardUserDefaults.BoolForKey(key);
            return value??defaultValue;
        }

        public string NSColorToHexString(NSColor color,bool withAlpha){
            nfloat red = 0, green = 0, blue = 0, alpha = 0;
            color.GetRgba(out red,out green,out blue,out alpha);

            alpha *= 255;
            red *= 255;
            green *= 255;
            blue *= 255;

            if (withAlpha)
            {
                return String.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", (int)alpha, (int)red, (int)green, (int)blue);
            }
            else
            {
                return String.Format("#{0:X2}{1:X2}{2:X2}", (int)red, (int)green, (int)blue);
            }
        }

        public NSColor NSColorFromHexString(string hexValue){
            var colorString = hexValue.Replace("#", "");
            float red, green, blue, alpha;

            switch(colorString.Length){
                case 3:
                    red = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(0, 1)), 16) / 255f;
                    green = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(1, 1)), 16) / 255f;
                    blue = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(2, 1)), 16) / 255f;
                    return NSColor.FromRgba(red, green, blue, 1.0f);
                case 6:
                    red = Convert.ToInt32(colorString.Substring(0, 2), 16) / 255f;
                    green = Convert.ToInt32(colorString.Substring(2, 2), 16) / 255f;
                    blue = Convert.ToInt32(colorString.Substring(4, 2), 16) / 255f;
                    return NSColor.FromRgba(red, green, blue, 1.0f);
                case 8:
                    alpha = Convert.ToInt32(colorString.Substring(0, 2), 16) / 255f;
                    red = Convert.ToInt32(colorString.Substring(2, 2), 16) / 255f;
                    green= Convert.ToInt32(colorString.Substring(4, 2), 16) / 255f;
                    blue = Convert.ToInt32(colorString.Substring(6, 2), 16) / 255f;
                    return NSColor.FromRgba(red, green, blue, alpha);
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Invalid color value '{0}'. It should be a hex value of the form #RBG,#RRGGBB or #AARRGGBB", hexValue));
            }
        }

        public NSColor LoadColor(string key,NSColor defaultValue){
            var hex = NSUserDefaults.StandardUserDefaults.StringForKey(key);

            return hex == null ? defaultValue : NSColorFromHexString(hex);
        }

        public void SaveColor(string key,NSColor color,bool sync){
            NSUserDefaults.StandardUserDefaults.SetString(NSColorToHexString(color,true),key);
            if (sync)
                NSUserDefaults.StandardUserDefaults.Synchronize();
        }
        #endregion


        public AppPreferences()
        {
        }
    }
}
