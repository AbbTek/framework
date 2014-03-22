using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplelabs.Framework.Persistence.NHibernate;
using Simplelabs.Framework.Test.Domain;
using NHibernate.Spatial.Criterion;
using NHibernate.Criterion;

namespace Simplelabs.Framework.Test.GIS
{
    [TestClass]
    public class RelateTest
    {
        [TestMethod]
        public void RelateConPatronTodoFalso()
        {
            string pattern = "FF*FF****";

            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Relate("Referencia", "Referencia", pattern));
            criteria.SetMaxResults(50);
            var r = criteria.List();

            Assert.IsNotNull(r);

            foreach (bool a in r)
            {
                Assert.IsFalse(a);
            }
        }

        [TestMethod]
        public void RelateConPatronTodoFalso2()
        {
            string pattern = "FF*FF****";

            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Relate(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia), pattern));
            criteria.SetMaxResults(50);
            var r = criteria.List();

            Assert.IsNotNull(r);

            foreach (bool a in r)
            {
                Assert.IsFalse(a);
            }
        }

        [TestMethod]
        public void RelateConPatronTodoVerdadero()
        {
            string pattern = "*********";

            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Relate("Referencia", "Referencia", pattern));
            
            criteria.SetMaxResults(50);
            var r = criteria.List();

            Assert.IsNotNull(r);

            foreach (bool a in r)
            {
                Assert.IsTrue(a);
            }
        }

        [TestMethod]
        public void RelateConPatronTodoVerdadero2()
        {
            string pattern = "*********";

            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Relate(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia), pattern));
            criteria.SetMaxResults(50);
            var r = criteria.List();

            Assert.IsNotNull(r);

            foreach (bool a in r)
            {
                Assert.IsTrue(a);
            }
        }
    }
}
