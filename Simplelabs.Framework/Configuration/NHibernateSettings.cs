using Simplelabs.Framework.Configuration.Elements;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Configuration
{
    public class NHibernateSettings : ConfigurationElement
    {
        private const string sessions = "sessions";
        private const string defaultSession = "defaultSession";
        private const string sessionManager = "sessionManager";

        [ConfigurationProperty(defaultSession)]
        public string DefaultSession
        {
            get { return (string)this[defaultSession]; }
        }

        [ConfigurationProperty(sessionManager,IsRequired=true)]
        public string SessionManager
        {
            get { return (string)this[sessionManager]; }
        }

        [ConfigurationProperty(sessions)]
        public ElementsCollection<NHibernateSession> NHibernateSessions
        {
            get { return (ElementsCollection<NHibernateSession>)this[sessions]; }
        }
    }
}
