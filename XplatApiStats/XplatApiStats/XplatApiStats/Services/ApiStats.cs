using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XplatApiStats.Services
{
    public class ApiStats : BindableObject
    {
        public int NumberOfTypesWithPlatformInName { get; set; }

        public string LongestTypeFullName { get; set; }

        public string ShortestTypeFullName { get; set; }

        public string LongestTypeName { get; set; }

        public string ShortestTypeName { get; set; }

        public int TypeCount { get; set; }

        public double AverageTypeNameLength { get; set; }

        public string LongestTypeMemberName { get; set; }

        public string ShortestTypeMemberName { get; set; }

        public double AverageTypeMemberNameLength { get; set; }
        public int NumberOfViews { get; set; }
    }
}
