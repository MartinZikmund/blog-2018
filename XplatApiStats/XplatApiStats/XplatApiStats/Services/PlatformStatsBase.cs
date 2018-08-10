using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace XplatApiStats.Services
{
    public abstract class PlatformStatsBase : IPlatformStats
    {
        protected abstract Assembly SourceAssembly { get; }

        protected abstract string PlatformName { get; }

        protected abstract Type BaseViewType { get; }

        public ApiStats GetStats()
        {
            var stats = new ApiStats
            {
                TypeCount = SourceAssembly.ExportedTypes.Count(),
                LongestTypeFullName = GetLongestTypeFullName(),
                ShortestTypeFullName = GetShortestTypeFullName(),
                LongestTypeName = GetLongestTypeName(),
                ShortestTypeName = GetShortestTypeName(),
                AverageTypeNameLength = GetAverageTypeName(),
                LongestTypeMemberName = GetLongestTypeMemberName(),
                ShortestTypeMemberName = GetShortestTypeMemberName(),
                AverageTypeMemberNameLength = GetAverageTypeMemberNameLength(),
                NumberOfTypesWithPlatformInName = GetNumberOfTypesWithPlatformInName(),
                NumberOfViews = GetNumberOfViews()
            };
            return stats;
        }

        private int GetNumberOfViews()
        {
            return SourceAssembly.ExportedTypes.Count(type => BaseViewType.IsAssignableFrom(type));
        }

        private double GetAverageTypeMemberNameLength()
        {
            return SourceAssembly.ExportedTypes.SelectMany(type => type.GetMembers()).Average(member => member.Name.Length);
        }

        private string GetShortestTypeMemberName()
        {
            return SourceAssembly.ExportedTypes.SelectMany(type => type.GetMembers()).OrderBy(member => member.Name.Length).First().Name;
        }

        private string GetLongestTypeMemberName()
        {
            return SourceAssembly.ExportedTypes.SelectMany(type => type.GetMembers()).OrderByDescending(member => member.Name.Length).First().Name;
        }

        private double GetAverageTypeName()
        {
            return SourceAssembly.ExportedTypes.Average(type => type.Name.Length);
        }

        private string GetShortestTypeName()
        {
            return SourceAssembly.ExportedTypes.OrderBy(type => type.Name.Length).First().Name;
        }

        private string GetLongestTypeName()
        {
            return SourceAssembly.ExportedTypes.OrderByDescending(type => type.Name.Length).First().Name;
        }

        private string GetShortestTypeFullName()
        {            
            return SourceAssembly.ExportedTypes.Where(t=>t.Name=="Color").OrderBy(t => t?.FullName?.Length).First()
                .FullName;
        }

        private string GetLongestTypeFullName()
        {
            return SourceAssembly.ExportedTypes.OrderByDescending(t => t?.FullName?.Length).First()
                .FullName;
        }

        private int GetNumberOfTypesWithPlatformInName()
        {
            return SourceAssembly.ExportedTypes.Count(type =>
                type.Name.IndexOf(PlatformName, StringComparison.InvariantCultureIgnoreCase) >= 0);
        }
    }
}
