using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplelabs.Framework.Persistence.NHibernate;
using NHibernate;
using NHibernate.Spatial.Type;
using System.Threading.Tasks;
using Simplelabs.Framework.Test.Domain;
using Simplelabs.Framework.Persistence.NHibernate.Extensions;

namespace Simplelabs.Framework.Test
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void TestSQL()
        {
            Parallel.For(0, 100, (i) =>
            {
                var session = SessionFactory.GetSession();
                var sql = session.CreateSQLQuery("Select Calle, Referencia From Direccion")
                    .AddScalar("Calle", NHibernateUtil.String)
                    .AddScalar("Referencia", NHibernateUtil.Custom(typeof(GeometryType)));
                var l = sql.List();
            });
        }

        [TestMethod]
        public void QueryHintNoLock()
        {
            var session = SessionFactory.GetSession(new QueryHintInterceptor());
            var c = session.CreateCriteria<Direccion>();
            c.QueryHintNoLock("Direccion");
            c.SetMaxResults(1);
            var l = c.List();
        }
    }
}
