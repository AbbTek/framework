﻿using NHibernate;
using NHibernate.Context;
using Simplelabs.Framework.Configuration.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Simplelabs.Framework.Persistence.NHibernate
{
    internal class WebSessionManager : AbstractSessionManager
    {
        public WebSessionManager(NHibernateSession session) : base(session) { }

        public override global::NHibernate.ISession GetSession()
        {
            return this.GetSession(null);
        }

        public override global::NHibernate.ISession GetSession(global::NHibernate.IInterceptor interceptor)
        {
            ISession session = null;
            if (ManagedWebSessionContext.HasBind(HttpContext.Current, sessionFactory))
            {
                session = this.sessionFactory.GetCurrentSession();
            }
            else
            {
                session = interceptor != null ? sessionFactory.OpenSession(interceptor) : sessionFactory.OpenSession();
                ManagedWebSessionContext.Bind(HttpContext.Current, session);
             }
            return session;
        }

        public override void CloseSession()
        {
            if (ManagedWebSessionContext.HasBind(HttpContext.Current, sessionFactory))
            {
                var session = this.sessionFactory.GetCurrentSession();
                if (session != null && session.IsOpen)
                {
                    session.Close();
                    ManagedWebSessionContext.Unbind(HttpContext.Current, sessionFactory);
                }
            }
        }
    }
}
