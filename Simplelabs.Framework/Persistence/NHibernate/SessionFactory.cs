using NHibernate;
using Simplelabs.Framework.Configuration;
using Simplelabs.Framework.Configuration.Elements;
using Simplelabs.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Persistence.NHibernate
{
    public static class SessionFactory
    {
        private static string defaultSession = "default";
        private static readonly Dictionary<string, AbstractSessionManager> managers = Create();

        static SessionFactory()
        {
            defaultSession = string.IsNullOrWhiteSpace(CManager.Settings.NHibernate.DefaultSession) ? defaultSession : CManager.Settings.NHibernate.DefaultSession;
        }

        private static Dictionary<string, AbstractSessionManager> Create()
        {
            var managers = new Dictionary<string, AbstractSessionManager>();

            var settings = CManager.Settings.NHibernate;
            try
            {
                foreach (var sessionFactory in settings.NHibernateSessions.Cast<NHibernateSession>())
                {
                    var objSessionManager = Reflection.CreateObject<AbstractSessionManager>(settings.SessionManager, new object[]{ sessionFactory});
                    managers.Add(sessionFactory.Name, (AbstractSessionManager)objSessionManager);
                }
                return managers;
            }
            catch (Exception e)
            {
                throw new FrameworkException(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.PersistenceErrorNotCreateSessionManager), e);
            }
        }

        public static ISession GetSession()
        {
            return GetSession(defaultSession, null);
        }

        public static ISession GetSession(string name)
        {
            return GetSession(name, null);
        }

        public static ISession GetSession(IInterceptor interceptor)
        {
            return GetSession(defaultSession, interceptor);
        }

        public static ISession GetSession(string name, IInterceptor interceptor)
        {
            return managers[name].GetSession(interceptor);
        }

        public static global::NHibernate.Cfg.Configuration GetCurrentConfiguration()
        {
            return GetCurrentConfiguration(defaultSession);
        }

        public static global::NHibernate.Cfg.Configuration GetCurrentConfiguration(string name)
        {
            return AbstractSessionManager.cfgs[name];
        }

        public static void CloseAllSession()
        {
            foreach (var item in managers)
            {
                item.Value.CloseSession();
            }
        }
    }
}
