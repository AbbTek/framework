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
    /// <summary>
    /// Utilidad para crear las sesiones de NHibernate y mantener esta sesión en el contexto
    /// </summary>
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
                    var objSessionManager = GetSessionManagerName(settings.SessionManager, sessionFactory);
                    managers.Add(sessionFactory.Name, (AbstractSessionManager)objSessionManager);
                }
                return managers;
            }
            catch (Exception e)
            {
                throw new FrameworkException(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.PersistenceErrorNotCreateSessionManager), e);
            }
        }

        private static AbstractSessionManager GetSessionManagerName(string name, NHibernateSession sessionFactory)
        {
            switch (name.ToLowerInvariant())
            {
                case "web":
                    return new WebSessionManager(sessionFactory);
                case "thread":
                    return new ThreadSessionManager(sessionFactory);
                default:
                    return Reflection.CreateObject<AbstractSessionManager>(name, new object[]{ sessionFactory});;
            }
        }

        /// <summary>
        /// Obtiene la sesión actual o crea una
        /// </summary>
        /// <returns></returns>
        public static ISession GetSession()
        {
            return GetSession(defaultSession, null);
        }

        /// <summary>
        /// Obtiene una sesión actual o crea una, por un nombre de sesión para manejo de múltiples BD
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ISession GetSession(string name)
        {
            return GetSession(name, null);
        }

        /// <summary>
        /// Obtiene la sesión actual o crea una y agrega un interceptor
        /// </summary>
        /// <param name="interceptor"></param>
        /// <returns></returns>
        public static ISession GetSession(IInterceptor interceptor)
        {
            return GetSession(defaultSession, interceptor);
        }

        /// <summary>
        /// Obtiene una sesión actual o crea una, por un nombre de sesión para manejo de múltiples BD.
        /// Y agrega un interceptor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="interceptor"></param>
        /// <returns></returns>
        public static ISession GetSession(string name, IInterceptor interceptor)
        {
            return managers[name].GetSession(interceptor);
        }

        /// <summary>
        /// Obtiene la configuración de NHibernate para la sesión por defecto
        /// </summary>
        /// <returns></returns>
        public static global::NHibernate.Cfg.Configuration GetCurrentConfiguration()
        {
            return GetCurrentConfiguration(defaultSession);
        }

        /// <summary>
        /// Obtiene la configuración de NHibernate para la sesión por defecto
        /// </summary>
        /// <param name="name">Nombre de la sesión para multiples BD</param>
        /// <returns></returns>
        public static global::NHibernate.Cfg.Configuration GetCurrentConfiguration(string name)
        {
            return AbstractSessionManager.cfgs[name];
        }

        /// <summary>
        /// Cierra todas las sesiones
        /// </summary>
        public static void CloseAllSession()
        {
            foreach (var item in managers)
            {
                item.Value.CloseSession();
            }
        }
    }
}
