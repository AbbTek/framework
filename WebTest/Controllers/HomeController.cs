using NHibernate;
using NHibernate.Spatial.Type;
using Simplelabs.Framework.Persistence.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            Load();
            var session = SessionFactory.GetSession();
            var sql = session.CreateSQLQuery("SELECT Calle, Referencia FROM Direccion")
                .AddScalar("Calle", NHibernateUtil.String)
                .AddScalar("Referencia", NHibernateUtil.Custom(typeof(GeometryType)));
            var l = sql.List();
            //sql.SetResultTransformer(Transformers.AliasToBean<DireccionQM>());
            return View();
        }

        private static void Load()
        {
            var session = SessionFactory.GetSession();
            var sql = session.CreateSQLQuery("SELECT Calle, Referencia FROM Direccion")
                .AddScalar("Calle", NHibernateUtil.String)
                .AddScalar("Referencia", NHibernateUtil.Custom(typeof(GeometryType)));
            var l = sql.List();
        }

    }
}
