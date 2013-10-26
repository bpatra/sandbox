using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FrontExcelAddIn.VersionManagement
{
    // http://lancelarsen.com/reading-values-from-assemblyinfo-cs/
    static public class AssemblyInfo
    {
        public static string Company { get { return GetExecutingAssemblyAttribute<AssemblyCompanyAttribute>(a => a.Company); } }
        public static string Product { get { return GetExecutingAssemblyAttribute<AssemblyProductAttribute>(a => a.Product); } }
        public static string Copyright { get { return GetExecutingAssemblyAttribute<AssemblyCopyrightAttribute>(a => a.Copyright); } }
        public static string Trademark { get { return GetExecutingAssemblyAttribute<AssemblyTrademarkAttribute>(a => a.Trademark); } }
        public static string Title { get { return GetExecutingAssemblyAttribute<AssemblyTitleAttribute>(a => a.Title); } }
        public static string Description { get { return GetExecutingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }
        public static string Configuration { get { return GetExecutingAssemblyAttribute<AssemblyDescriptionAttribute>(a => a.Description); } }
        public static string FileVersion { get { return GetExecutingAssemblyAttribute<AssemblyFileVersionAttribute>(a => a.Version); } }

        public static Version Version { get { return Assembly.GetExecutingAssembly().GetName().Version; } }
        public static string VersionFull { get { return Version.ToString(); } }
        public static string VersionMajor { get { return Version.Major.ToString(); } }
        public static string VersionMinor { get { return Version.Minor.ToString(); } }
        public static string VersionBuild { get { return Version.Build.ToString(); } }
        public static string VersionRevision { get { return Version.Revision.ToString(); } }

        public static string LinkedProductName { get { return AssemblyInfo.GetExecutingAssemblyAttribute<AssemblyLinkedProductAttribute>(a => a.Name); } }
        public static string LinkedProductVersion { get { return AssemblyInfo.GetExecutingAssemblyAttribute<AssemblyLinkedProductAttribute>(a => a.Version); } }

        public static string GetExecutingAssemblyAttribute<T>(Func<T, string> value, string defaultValue = null) where T : Attribute
        {
            T attribute = (T)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(T));
            if (attribute == null)
                return defaultValue;
            return value.Invoke(attribute);
        }
    }
}
