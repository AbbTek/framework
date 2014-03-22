using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplelabs.Framework.Persistence.NHibernate;
using Simplelabs.Framework.Test.Domain;
using NHibernate.Spatial.Criterion;
using NHibernate.Criterion;
using NetTopologySuite.Geometries;

namespace Simplelabs.Framework.Test.GIS
{
    [TestClass]
    public class SpatialProjectionsTest
    {
        [TestMethod]
        public void Buffer()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Buffer("Referencia", 0.1));
            criteria.SetMaxResults(10);
            var r = criteria.List();
        }

        [TestMethod]
        public void Buffer2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Buffer(Projections.Property<Direccion>(d => d.Referencia), 0.1));
            criteria.SetMaxResults(10);
            var r = criteria.List();
        }


        [TestMethod]
        public void Contains()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Contains("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Contains2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Contains(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void ConvexHull()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.ConvexHull("Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void ConvexHull2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.ConvexHull(Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void CoveredBy()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.CoveredBy("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void CoveredBy2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.CoveredBy(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Covers()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Covers("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Covers2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Covers(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Crosses()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Crosses("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Crosses2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Crosses(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }


        [TestMethod]
        public void Difference()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Difference("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Difference2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Crosses(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Disjoint()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Disjoint("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Disjoint2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Disjoint(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }


        [TestMethod]
        public void Distance()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Distance("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Distance2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Distance(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Equals()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Equals("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Equals2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Equals(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Intersection()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Intersection("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Intersection2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Intersection(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Intersects()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Intersects("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Intersects2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Intersects(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void IsClosed()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.IsClosed("Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void IsClosed2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.IsClosed(Projections.Property<Direccion>(d=>d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void IsEmpty()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.IsEmpty("Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void IsEmpty2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.IsEmpty(Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }


        [TestMethod]
        public void IsRing()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.IsRing("Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void IsRing2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.IsRing(Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void IsSimple()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.IsSimple("Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void IsSimple2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.IsSimple(Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void IsValid()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.IsValid("Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void IsValid2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.IsValid(Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Overlaps()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Overlaps("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Overlaps2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Overlaps(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void SymDifference()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.SymDifference("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void SymDifference2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.SymDifference(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Touches()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Touches("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Touches2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Touches(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Union()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Union("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Union2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Union(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Within()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Within("Referencia", "Referencia"));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestMethod]
        public void Within2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.SetProjection(SpatialProjections.Within(Projections.Property<Direccion>(d => d.Referencia), Projections.Property<Direccion>(d => d.Referencia)));
            criteria.SetMaxResults(10);
            var r = criteria.List();
            Assert.IsTrue(r.Count > 0);
        }

        [TestInitialize]
        public void Init()
        {
            var session = SessionFactory.GetSession();

            using (var tx = session.BeginTransaction())
            {
                var c = session.CreateCriteria<Direccion>();
                c.SetProjection(Projections.RowCount());
                var total = c.UniqueResult<int>();
                var random = new Random();
                if (total < 100)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        var d = new Direccion()
                        {
                            Referencia = new Point(random.NextDouble(), random.NextDouble()),
                            Numero = i.ToString(),
                            Calle = "Los soles " + i
                        };
                        session.Save(d);
                    }
                }
                tx.Commit();
            }
        }
    }
}
