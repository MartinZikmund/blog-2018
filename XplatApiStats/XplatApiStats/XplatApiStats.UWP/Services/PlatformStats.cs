using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Xamarin.Forms;
using XplatApiStats.Services;
using XplatApiStats.UWP.Services;
using Application = Windows.UI.Xaml.Application;

[assembly:Dependency(typeof(PlatformStats))]
namespace XplatApiStats.UWP.Services
{    
    public class PlatformStats : PlatformStatsBase
    {
        protected override Assembly SourceAssembly => typeof(Application).Assembly;
        protected override string PlatformName => "windows";

        protected override Type BaseViewType => typeof(FrameworkElement);
    }
}
