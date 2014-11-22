using System;
using Xamarin.Forms;

namespace ThingsOfInternet.UI
{
    public static class ColorGenerator
    {
        private static int GridBackgroundColorsIndex;
        private static readonly Color[] GridBackgroundColors = new []
            {
                /*Color.FromHex("#D8DEA6"),
                Color.FromHex("#BCDEA6"),
                Color.FromHex("#A6DEAC"),
                Color.FromHex("#DEC8A6"),
                Color.FromHex("#DEACA6")*/
                Color.FromHex("#EFEFEF")
            };

        public static Color GridBackground
        {
            get { return GetNextGridBackgroundColor(); }
        }

        private static Color GetNextGridBackgroundColor()
        {
            return GridBackgroundColors[GridBackgroundColorsIndex++ % GridBackgroundColors.Length];
        }
    }
}

