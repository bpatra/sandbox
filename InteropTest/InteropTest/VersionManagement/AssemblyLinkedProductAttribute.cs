using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrontExcelAddIn.VersionManagement
{
    public sealed class AssemblyLinkedProductAttribute : Attribute
    {
        public AssemblyLinkedProductAttribute(string productName, string productVersion)
        {
            Name = productName;
            Version = productVersion;
        }

        public String Name { get; set; }
        public String Version { get; set; }
    }
}
