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
        public void QueryHintIndex()
        {
            var session = SessionFactory.GetSession(new QueryHintInterceptor());
            var c = session.CreateCriteria<Direccion>();
            c.QueryHintIndex("Direccion","IX_Direccion_1");
            c.SetMaxResults(1);
            var l = c.List();
        }

        [TestMethod]
        public void QueryHintIndex2()
        {
            var session = SessionFactory.GetSession(new QueryHintInterceptor());
            var c = session.CreateCriteria<Unidad>();
            c.QueryHintIndex("TestSchema.[Unidad]", "IX_TestSchema_Unidad_1");
            c.SetMaxResults(1);
            var l = c.List();
        }
    }
}
