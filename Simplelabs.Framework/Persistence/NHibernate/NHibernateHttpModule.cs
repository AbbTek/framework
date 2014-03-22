using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Simplelabs.Framework.Persistence.NHibernate
{
    /// <summary>
    /// Modulo para cerrar las sesiones NHibernate
    /// </summary>
    public class NHibernateHttpModule : IHttpModule
    {
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {          
        }

        /// <summary>
        /// Inicio
        /// </summary>
        /// <param name="context"></param>
        public void Init(HttpApplication context)
        {
            context.EndRequest += context_EndRequest;
        }

        /// <summary>
        /// Al final del Request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void context_EndRequest(object sender, EventArgs e)
        {
            SessionFactory.CloseAllSession();
        }
    }
}
