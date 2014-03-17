using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Simplelabs.Framework.Persistence.NHibernate
{
    public class NHibernateHttpModule : IHttpModule
    {
        public void Dispose()
        {          
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += context_EndRequest;
        }

        void context_EndRequest(object sender, EventArgs e)
        {
            SessionFactory.CloseAllSession();
        }
    }
}
