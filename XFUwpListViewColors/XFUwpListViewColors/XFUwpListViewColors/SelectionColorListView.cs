using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFUwpListViewColors
{
    public class SelectionColorListView : ListView
    {
        public static readonly BindableProperty SelectionColorProperty =
            BindableProperty.Create(nameof(SelectionColor), typeof(Color), typeof(SelectionColorListView), Color.LawnGreen);

        public Color SelectionColor
        {
            get => (Color)GetValue(SelectionColorProperty);
            set => SetValue(SelectionColorProperty, value);
        }
    }
}
