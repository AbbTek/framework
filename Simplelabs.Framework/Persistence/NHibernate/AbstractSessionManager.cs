using NHibernate;
using Simplelabs.Framework.Configuration.Elements;
using Simplelabs.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Simplelabs.Framework.Persistence.NHibernate
{
    /// <summary>
    /// Clase para la abstacción de sesiones en distintos tipos de aplicaciones (Web, Windows service)
    /// </summary>
    internal abstract class AbstractSessionManager
    {
        protected ISessionFactory sessionFactory;

        public AbstractSessionManager(NHibernateSession sessionConfig)
        {
            var file = GetFile(sessionConfig);
            var cfg = new global::NHibernate.Cfg.Configuration();
            cfg.Configure(file);

            foreach (var item in sessionConfig.Interceptors.Cast<NHibernateInterceptor>())
            {
                var interceptor = Reflection.CreateObject<IInterceptor>(item.Type);
                if (interceptor != null)
                    cfg.SetInterceptor(interceptor);
            }

            this.sessionFactory = cfg.BuildSessionFactory();
        }

        private static string GetFile(NHibernateSession session)
        {
            var filePath = "";

            if (string.IsNullOrWhiteSpace(session.FilePath) && string.IsNullOrWhiteSpace(session.VirtualPath))
            {
                throw new FrameworkException(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.PersistenceErrorConfigurationNoFile));
            }
            else if (!string.IsNullOrWhiteSpace(session.FilePath))
            {
                filePath = session.FilePath;
            }
            else if (!string.IsNullOrWhiteSpace(session.VirtualPath))
            {
                filePath = HttpContext.Current.Server.MapPath(session.VirtualPath);
            }
            return filePath;
        }

        public abstract ISession GetSession();
        public abstract ISession GetSession(IInterceptor interceptor);
        public abstract void CloseSession();
    }
}
