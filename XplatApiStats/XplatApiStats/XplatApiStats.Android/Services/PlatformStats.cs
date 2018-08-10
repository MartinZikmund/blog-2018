using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XplatApiStats.Droid.Services;
using XplatApiStats.Services;

[assembly:Dependency(typeof(PlatformStats))]
namespace XplatApiStats.Droid.Services
{
    public class PlatformStats : PlatformStatsBase
    {
        protected override Assembly SourceAssembly => typeof(Activity).Assembly;
    }
}