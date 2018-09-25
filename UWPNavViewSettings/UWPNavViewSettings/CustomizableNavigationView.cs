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

        private readonly SymbolIcon _defaultIcon = new SymbolIcon(Symbol.Setting);
        private NavigationViewItem _settingsItem;

        public static readonly DependencyProperty SettingsItemTextProperty = DependencyProperty.Register(
               nameof(SettingsItemText), typeof(string), typeof(CustomizableNavigationView), new PropertyMetadata(default(string), SettingsItemChanged));

        public static readonly DependencyProperty SettingsItemIconProperty = DependencyProperty.Register(
            nameof(SettingsItemIcon), typeof(IconElement), typeof(CustomizableNavigationView), new PropertyMetadata(default(IconElement), SettingsItemChanged));

        public IconElement SettingsItemIcon
        {
            get => (IconElement)GetValue(SettingsItemIconProperty);
            set => SetValue(SettingsItemIconProperty, value);
        }

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

        private static void SettingsItemChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is CustomizableNavigationView navigationView)
            {
                navigationView.UpdateSettingsItemText();
            }
        }

        private void UpdateSettingsItemText()
        {
            if (_settingsItem != null)
            {
                _settingsItem.Content = SettingsItemText ?? "";
                _settingsItem.Icon = SettingsItemIcon ?? _defaultIcon;
            }
        }
    }
}
