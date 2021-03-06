﻿using NHibernate;
using Simplelabs.Framework.Configuration.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Persistence.NHibernate
{
    internal class ThreadSessionManager : AbstractSessionManager
    {
        public ThreadSessionManager(NHibernateSession session) : base(session) { }
        public override global::NHibernate.ISession GetSession()
        {
            return this.GetSession(null);
        }

        public override global::NHibernate.ISession GetSession(global::NHibernate.IInterceptor interceptor)
        {
            ISession session = null;
            if (global::NHibernate.Context.ThreadStaticSessionContext.HasBind(sessionFactory))
            {
                session = this.sessionFactory.GetCurrentSession();
            }
            else
            {
                session = interceptor != null ? sessionFactory.OpenSession(interceptor) : sessionFactory.OpenSession();
                global::NHibernate.Context.ThreadStaticSessionContext.Bind(session);
            }

            return session;
        }

        public override void CloseSession()
        {
            
            if (global::NHibernate.Context.ThreadStaticSessionContext.HasBind(sessionFactory))
            {
                ISession session = this.sessionFactory.GetCurrentSession();

                if (session != null && session.IsOpen)
                {
                    session.Close();
                    global::NHibernate.Context.ThreadStaticSessionContext.Unbind(sessionFactory);
                }
            }
        }
    }
}
