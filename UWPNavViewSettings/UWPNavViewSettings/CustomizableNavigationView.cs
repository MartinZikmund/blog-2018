using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace UWPNavViewSettings
{
public class CustomizableNavigationView : NavigationView
{
    protected override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var settingsItem = (NavigationViewItem)GetTemplateChild("SettingsNavPaneItem");
        settingsItem.Content = "Custom text";
    }
}
}
