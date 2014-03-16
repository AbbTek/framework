using NHibernate;
using NHibernate.Context;
using NHibernate.Engine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Persistence.NHibernate
{
    /// <summary>
    /// Permite la gestion de sesiones NHibernate en un ambiente multi thread
    /// </summary>
    public sealed class ManagedThreadSessionContext : ICurrentSessionContext
    {

        //private static Dictionary<int, Dictionary<ISessionFactoryImplementor,ISession>> sessions;
        private readonly ISessionFactoryImplementor factory;
        private const string key = "ManagedThreadSessionContextKey";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public ManagedThreadSessionContext(ISessionFactoryImplementor factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Obtiene la session actual para el thread en ejecucion
        /// </summary>
        /// <returns></returns>
        public global::NHibernate.ISession CurrentSession()
        {
            ISession currentSession = GetExistingSession(factory);
            if (currentSession == null)
            {
                throw new FrameworkException(string.Format(CultureInfo.CurrentUICulture, Properties.Resources.PersistenceErrorNotSession));
            }
            return currentSession;
        }

        /// <summary>
        /// Guarda la sesion para el thread
        /// </summary>        
        /// <param name="session"></param>
        public static void Bind(ISession session)
        {
            GetSessionMap(true)[((ISessionImplementor)session).Factory] = session;
        }

        /// <summary>
        /// Verifica si la sesion NHibernate existe
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static bool HasBind(ISessionFactory factory)
        {
            return GetExistingSession(factory) != null;
        }

        /// <summary>
        /// Quita la sesion NHibernate para el thread
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public static ISession Unbind(ISessionFactory factory)
        {
            ISession result = null;
            IDictionary sessionMap = GetSessionMap(false);
            if (sessionMap != null)
            {
                result = sessionMap[factory] as ISession;
                sessionMap.Remove(factory);
            }
            return result;
        }

        private static ISession GetExistingSession(ISessionFactory factory)
        {
            Dictionary<ISessionFactoryImplementor, ISession> sessionMap = GetSessionMap(false);
            ISessionFactoryImplementor sessionFactoryImplementor = factory as ISessionFactoryImplementor;
            if (sessionMap == null || !sessionMap.ContainsKey(sessionFactoryImplementor))
            {
                return null;
            }
            return sessionMap[sessionFactoryImplementor];
        }

        private static Dictionary<ISessionFactoryImplementor, ISession> GetSessionMap(bool create)
        {
            Dictionary<ISessionFactoryImplementor, ISession> map = (Dictionary<ISessionFactoryImplementor, ISession>)Thread.GetData(Thread.GetNamedDataSlot(key));
            if (map == null && create)
            {
                map = new Dictionary<ISessionFactoryImplementor, ISession>();
                Thread.SetData(Thread.GetNamedDataSlot(key), map);
            }
            return map;
        }
    }
}
