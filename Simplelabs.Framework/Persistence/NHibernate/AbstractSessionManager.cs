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
        protected ISessionFactory sessionFactory;
        static internal Dictionary<string, global::NHibernate.Cfg.Configuration> cfgs = new Dictionary<string, global::NHibernate.Cfg.Configuration>();

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
            Metadata.AddMapping(cfg, MetadataClass.GeometryColumn);
            Metadata.AddMapping(cfg, MetadataClass.SpatialReferenceSystem);
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

        public abstract ISession GetSession();
        public abstract ISession GetSession(IInterceptor interceptor);
        public abstract void CloseSession();
    }
}
