using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using GeoAPI.Geometries;
using Simplelabs.Framework.Persistence.NHibernate;
using Simplelabs.Framework.Test.Domain;
using NHibernate.Spatial.Criterion;

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
