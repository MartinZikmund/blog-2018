using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XFUwpListViewColors;
using XFUwpListViewColors.UWP;

[assembly: ExportRenderer(typeof(SelectionColorListView), typeof(SelectionColorListViewRenderer))]

namespace XFUwpListViewColors.UWP
{
    public class SelectionColorListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                UpdateSelectionColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(SelectionColorListView.SelectionColor))
            {
                UpdateSelectionColor();
            }
        }

        private void UpdateSelectionColor()
        {
            if (Control != null && Element is SelectionColorListView listView)
            {
                var nativeColor = XamarinColorToNative(listView.SelectionColor);
                Control.Resources["SystemControlHighlightListAccentLowBrush"] = new SolidColorBrush(nativeColor);
            }
        }

        private Windows.UI.Color XamarinColorToNative(Xamarin.Forms.Color color)
        {
            var alpha = (byte)(color.A * 255);
            var red = (byte)(color.R * 255);
            var green = (byte)(color.G * 255);
            var blue = (byte)(color.B * 255);
            return Windows.UI.Color.FromArgb(alpha, red, green, blue);
        }
    }
}