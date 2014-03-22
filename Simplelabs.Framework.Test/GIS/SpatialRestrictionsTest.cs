using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using GeoAPI.Geometries;
using Simplelabs.Framework.Persistence.NHibernate;
using Simplelabs.Framework.Test.Domain;
using NHibernate.Spatial.Criterion;
using NHibernate.Criterion;

namespace Simplelabs.Framework.Test.GIS
{
    [TestClass]
    public class SpatialRestrictionsTest
    {
        [TestMethod]
        public void Contains()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Contains("Referencia", p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Contains2()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Contains(Projections.Property<Direccion>(d=>d.Referencia), p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void CoveredBy()
        {
            var session = SessionFactory.GetSession();
            var c1 = session.CreateCriteria<Direccion>();            
            c1.SetMaxResults(1);
            var d = c1.UniqueResult<Direccion>();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.CoveredBy("Referencia", d.Referencia.Buffer(100)));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void CoveredBy2()
        {
            var session = SessionFactory.GetSession();
            var c1 = session.CreateCriteria<Direccion>();
            c1.SetMaxResults(1);
            var d = c1.UniqueResult<Direccion>();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.CoveredBy(Projections.Property<Direccion>(di => di.Referencia), d.Referencia.Buffer(100)));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Covers()
        {
            var session = SessionFactory.GetSession();
            var c1 = session.CreateCriteria<Direccion>();                        
            c1.SetMaxResults(1);
            var d = c1.UniqueResult<Direccion>();

            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Covers("Referencia", d.Referencia.Buffer(100)));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Covers2()
        {
            var session = SessionFactory.GetSession();
            var c1 = session.CreateCriteria<Direccion>();
            c1.SetMaxResults(1);
            var d = c1.UniqueResult<Direccion>();

            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Covers(Projections.Property<Direccion>(di=>di.Referencia), d.Referencia.Buffer(100)));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Crosses()
        {
            Polygon p = GetPolygonChico();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.Crosses("Referencia", p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Crosses2()
        {
            Polygon p = GetPolygonChico();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Crosses(Projections.Property<Direccion>(di => di.Referencia), p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Disjoint()
        {
            Polygon p = GetPolygonChico();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.Disjoint("Referencia", p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Disjoint2()
        {
            Polygon p = GetPolygonChico();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Disjoint(Projections.Property<Direccion>(di => di.Referencia), p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Eq()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.Eq("Referencia", p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Eq2()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Eq(Projections.Property<Direccion>(di => di.Referencia), p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Filter()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.Filter("Referencia", p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Filter2()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Filter(Projections.Property<Direccion>(di => di.Referencia), p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }


        [TestMethod]
        public void Intersects()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>(); 
            criteria.Add(SpatialRestrictions.Intersects("Referencia", p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Intersects2()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Intersects(Projections.Property<Direccion>(di => di.Referencia), p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void IsClosed()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.IsClosed("Referencia"));
            criteria.SetMaxResults(10);
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void IsClosed2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.IsClosed(Projections.Property<Direccion>(di => di.Referencia)));
            criteria.SetMaxResults(10);
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void IsEmpty()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.IsEmpty("Referencia"));
            criteria.SetMaxResults(10);
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void IsEmpty2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.IsEmpty(Projections.Property<Direccion>(di => di.Referencia)));
            criteria.SetMaxResults(10);
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void IsRing()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.IsRing("Referencia"));
            criteria.SetMaxResults(10);
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void IsRing2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.IsRing(Projections.Property<Direccion>(di => di.Referencia)));
            criteria.SetMaxResults(10);
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void IsSimple()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.IsSimple("Referencia"));
            criteria.SetMaxResults(10);
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void IsSimple2()
        {
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.IsSimple(Projections.Property<Direccion>(di => di.Referencia)));
            criteria.SetMaxResults(10);
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void IsValid()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.IsValid("Referencia"));
            criteria.SetMaxResults(10);
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void IsValid2()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.IsValid(Projections.Property<Direccion>(di => di.Referencia)));
            criteria.SetMaxResults(10);
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Overlaps()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.Overlaps("Referencia", p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Overlaps2()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Overlaps(Projections.Property<Direccion>(di => di.Referencia), p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Touches()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.Touches("Referencia", p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Touches2()
        {
            Polygon p = GetPolygon();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Touches(Projections.Property<Direccion>(di => di.Referencia), p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Within()
        {
            Polygon p = GetPolygonChico();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(SpatialRestrictions.Within("Referencia", p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void Within2()
        {
            Polygon p = GetPolygonChico();
            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();
            criteria.Add(SpatialRestrictions.Within(Projections.Property<Direccion>(di => di.Referencia), p));
            IList<Direccion> direcciones = criteria.List<Direccion>();
        }

        [TestMethod]
        public void CombineTest()
        {
            Polygon p = GetPolygon();


            List<Coordinate> coordenadas1 = new List<Coordinate>();
            coordenadas1.Add(new Coordinate(0, 0));
            coordenadas1.Add(new Coordinate(0, -80));
            coordenadas1.Add(new Coordinate(-20, -50));
            coordenadas1.Add(new Coordinate(-20, 0));
            coordenadas1.Add(new Coordinate(0, 0));
            Polygon p1 = new Polygon(new LinearRing(coordenadas1.ToArray()));

            List<Coordinate> coordenadas2 = new List<Coordinate>();
            coordenadas2.Add(new Coordinate(-30, 0));
            coordenadas2.Add(new Coordinate(0, -80));
            coordenadas2.Add(new Coordinate(-20, -50));
            coordenadas2.Add(new Coordinate(-20, 55));
            coordenadas2.Add(new Coordinate(-30, 0));
            Polygon p2 = new Polygon(new LinearRing(coordenadas2.ToArray()));


            var session = SessionFactory.GetSession();
            var criteria = session.CreateCriteria<Direccion>();  
            criteria.Add(NHibernate.Criterion.Expression.Conjunction()
                .Add(SpatialRestrictions.Within("Referencia", p))
                .Add(SpatialRestrictions.Covers("Referencia", p1))
                .Add(SpatialRestrictions.Disjoint("Referencia", p2)));
            IList<Direccion> direcciones = criteria.List<Direccion>();

        }

        private Polygon GetPolygon()
        {
            var coordenadas = new List<Coordinate>();
            coordenadas.Add(new Coordinate(-70.6662736, -33.4522086));
            coordenadas.Add(new Coordinate(-70.6175961, -33.4426576));
            coordenadas.Add(new Coordinate(-70.622225, -33.4779757));
            coordenadas.Add(new Coordinate(-70.654850602655, -33.4812744821386));
            coordenadas.Add(new Coordinate(-70.6662736, -33.4522086));
            return new Polygon(new LinearRing(coordenadas.ToArray()));
        }

        private Polygon GetPolygonChico()
        {
            var coordenadas = new List<Coordinate>();
            coordenadas.Add(new Coordinate(-70.6666, -33.4522));
            coordenadas.Add(new Coordinate(-70.6667, -33.4433));
            coordenadas.Add(new Coordinate(-70.6655, -33.4666));
            coordenadas.Add(new Coordinate(-70.6668, -33.4667));
            coordenadas.Add(new Coordinate(-70.6666, -33.4522));
            return new Polygon(new LinearRing(coordenadas.ToArray()));
        }
    }
}
