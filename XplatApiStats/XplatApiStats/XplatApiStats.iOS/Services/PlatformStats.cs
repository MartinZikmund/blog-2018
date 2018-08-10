using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using XplatApiStats.iOS.Services;
using XplatApiStats.Services;

[assembly: Dependency(typeof(PlatformStats))]
namespace XplatApiStats.iOS.Services
{
    public class PlatformStats : PlatformStatsBase
    {
        protected override Assembly SourceAssembly => typeof(UIApplication).Assembly;
    }
}