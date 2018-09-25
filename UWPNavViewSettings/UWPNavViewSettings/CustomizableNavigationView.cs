using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPNavViewSettings
{
    public class CustomizableNavigationView : NavigationView
    {
        private const string SettingsNavigationViewItemName = "SettingsNavPaneItem";

        private NavigationViewItem _settingsItem;

        public static readonly DependencyProperty SettingsItemTextProperty = DependencyProperty.Register(
           nameof(SettingsItemText), typeof(string), typeof(CustomizableNavigationView), new PropertyMetadata(default(string), SettingsItemTextChanged));

        public string SettingsItemText
        {
            get => (string)GetValue(SettingsItemTextProperty);
            set => SetValue(SettingsItemTextProperty, value);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _settingsItem = (NavigationViewItem)GetTemplateChild(SettingsNavigationViewItemName);
            UpdateSettingsItemText();
        }

        private static void SettingsItemTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomizableNavigationView navigationView)
            {
                navigationView.UpdateSettingsItemText();
            }
        }

        private void UpdateSettingsItemText()
        {
            if (_settingsItem != null)
            {
                _settingsItem.Content = SettingsItemText ?? "";
            }
        }
    }
}
