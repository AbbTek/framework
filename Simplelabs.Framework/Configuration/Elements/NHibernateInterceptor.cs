using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Configuration.Elements
{
    /// <summary>
    /// Para los interceptores
    /// </summary>
    public class NHibernateInterceptor : ConfigurationElement, IKeyElement
    {
        private const string type = "type";

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(type,IsRequired=true)]
        public string Type
        {
            get { return (string)this[type]; }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Key
        {
            get { return this.Type; }
        }
    }
}
