using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Configuration
{  
    public static class CManager
    {
        public const string SectionName = "simplelabs.framework";
        private static FrameworkSettings frameworkSetting = (FrameworkSettings)ConfigurationManager.GetSection(SectionName);

        public static FrameworkSettings Settings
        {
            get { return frameworkSetting; }
        }
    }
}
