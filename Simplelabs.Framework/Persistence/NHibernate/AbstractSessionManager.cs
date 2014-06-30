using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg.ConfigurationSchema;
using NHibernate.Spatial.Mapping;
using NHibernate.Spatial.Metadata;
using Simplelabs.Framework.Configuration.Elements;
using Simplelabs.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Simplelabs.Framework.Persistence.NHibernate
{
    /// <summary>
    /// Clase para la abstacción de sesiones en distintos tipos de aplicaciones (Web, Windows service)
    /// </summary>
    public abstract class AbstractSessionManager
    {
        /// <summary>
        /// El constructor de sesiones
        /// </summary>
        protected ISessionFactory sessionFactory;
        static internal Dictionary<string, global::NHibernate.Cfg.Configuration> cfgs = new Dictionary<string, global::NHibernate.Cfg.Configuration>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sessionConfig"></param>
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

            cfg.AddAuxiliaryDatabaseObject(new SpatialAuxiliaryDatabaseObject(cfg));

            var fcfg = Fluently.Configure(cfg);
            using (XmlTextReader reader = new XmlTextReader(file))
                {
                    var hc = new HibernateConfiguration(reader);
                    foreach (var item in hc.SessionFactory.Mappings)
                    {
                      fcfg.Mappings(m=>m.FluentMappings.AddFromAssembly(Assembly.Load(item.Assembly)));  
                    }
                }


            this.sessionFactory = fcfg.BuildSessionFactory();

            if (!cfgs.ContainsKey(sessionConfig.Name))
                cfgs.Add(sessionConfig.Name, cfg);
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

        /// <summary>
        /// Obtiene o crea la sesión NHibernate 
        /// </summary>
        /// <returns></returns>
        public abstract ISession GetSession();
        /// <summary>
        /// Obtiene o crea la sesión NHibernate y agrega un interceptor
        /// </summary>
        /// <param name="interceptor"></param>
        /// <returns></returns>
        public abstract ISession GetSession(IInterceptor interceptor);
        /// <summary>
        /// Cierra la sesión
        /// </summary>
        public abstract void CloseSession();
        /// <summary>
        /// Obtiene ISessionFactory
        /// </summary>
        /// <returns></returns>
        public ISessionFactory GetSessionFactory()
        {
            return this.sessionFactory;
        }
    }
}
