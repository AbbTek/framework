using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplelabs.Framework.Persistence.NHibernate;
using NHibernate;
using NHibernate.Spatial.Type;
using System.Threading.Tasks;

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
    }
}
