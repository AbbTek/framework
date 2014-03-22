using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Configuration.Elements
{
    /// <summary>
    /// Configuración de Nhibernate
    /// </summary>
    public class NHibernateSession : ConfigurationElement, IKeyElement
    {
        private const string name = "name";
        private const string filePath = "filePath";
        private const string virtualPath = "virtualPath";
        private const string interceptors = "interceptors";

        /// <summary>
        /// Nombre de la sesión
        /// </summary>
        [ConfigurationProperty(name, IsRequired = true, IsKey = true)]
        public string Name
        {
            get { return (string)this[name]; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(filePath)]
        public string FilePath
        {
            get { return (string)this[filePath]; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(virtualPath)]
        public string VirtualPath
        {
            get { return (string)this[virtualPath]; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(interceptors)]
        public ElementsCollection<NHibernateInterceptor> Interceptors
        {
            get { return (ElementsCollection<NHibernateInterceptor>)this[interceptors]; }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Key
        {
            get { return this.Name; }
        }
    }
}
