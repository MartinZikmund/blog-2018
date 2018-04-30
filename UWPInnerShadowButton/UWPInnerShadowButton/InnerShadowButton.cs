using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace UWPInnerShadowButton
{
    public sealed class InnerShadowButton : Button
    {
        public InnerShadowButton()
        {
            this.DefaultStyleKey = typeof(InnerShadowButton);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var rootGrid = (Grid)GetTemplateChild("RootGrid");
            var visual = ElementCompositionPreview.GetElementVisual(rootGrid);
            var compositor = visual.Compositor;
            visual.Clip = compositor.CreateInsetClip();
        }
    }
}
