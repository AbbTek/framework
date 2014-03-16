using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Configuration.Elements
{
    public class NHibernateSession : ConfigurationElement, IKeyElement
    {
        private const string name = "name";
        private const string filePath = "filePath";
        private const string virtualPath = "virtualPath";
        private const string interceptors = "interceptors";

        [ConfigurationProperty(name, IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this[name]; }
        }

        [ConfigurationProperty(filePath)]
        public string FilePath
        {
            get { return (string)this[filePath]; }
        }

        [ConfigurationProperty(virtualPath)]
        public string VirtualPath
        {
            get { return (string)this[virtualPath]; }
        }

        [ConfigurationProperty(interceptors)]
        public ElementsCollection<NHibernateInterceptor> Interceptors
        {
            get { return (ElementsCollection<NHibernateInterceptor>)this[interceptors]; }
        }

        public object Key
        {
            get { return this.Name; }
        }
    }
}
