using Simplelabs.Framework.Configuration.Elements;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Configuration
{
    /// <summary>
    /// Configuración de NHibernate
    /// </summary>
    public class NHibernateSettings : ConfigurationElement
    {
        private const string sessions = "sessions";
        private const string defaultSession = "defaultSession";
        private const string sessionManager = "sessionManager";

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(defaultSession)]
        public string DefaultSession
        {
            get { return (string)this[defaultSession]; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(sessionManager,IsRequired=true)]
        public string SessionManager
        {
            get { return (string)this[sessionManager]; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(sessions)]
        public ElementsCollection<NHibernateSession> NHibernateSessions
        {
            get { return (ElementsCollection<NHibernateSession>)this[sessions]; }
        }
    }
}
