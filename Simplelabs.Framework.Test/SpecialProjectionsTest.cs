using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplelabs.Framework.Persistence.NHibernate;
using Simplelabs.Framework.Test.Domain;
using NHibernate.Criterion;
using Simplelabs.Framework.Persistence.NHibernate.Criterion;
using Simplelabs.Framework.Persistence.NHibernate.Projections;

namespace Simplelabs.Framework.Test
{
    [TestClass]
    public class SpecialProjectionsTest
    {
        [TestMethod]
        public void GetAncestor()
        {
            var session = SessionFactory.GetSession();
            var cri = session.CreateCriteria<UnidadGeopolitica>();
            cri.SetProjection(SpecialProjections.GetAncestor(Projections.Property<UnidadGeopolitica>(u => u.Nodo), 1));            
            var l = cri.List();
        }

        [TestMethod]
        public void GetDescendant()
        {
            var session = SessionFactory.GetSession();
            var cri = session.CreateCriteria<UnidadGeopolitica>();
            cri.SetProjection(SpecialProjections.GetDescendant(Projections.Property<UnidadGeopolitica>(u => u.Nodo),null,null));
            var l = cri.List();
        }

        [TestMethod]
        public void GetLevel()
        {
            var session = SessionFactory.GetSession();
            var cri = session.CreateCriteria<UnidadGeopolitica>();
            cri.SetProjection(SpecialProjections.GetLevel(Projections.Property<UnidadGeopolitica>(u => u.Nodo)));
            var l = cri.List();
        }

        [TestMethod]
        public void GetReparentedValue()
        {
            var session = SessionFactory.GetSession();
            var cri = session.CreateCriteria<UnidadGeopolitica>();
            cri.SetProjection(SpecialProjections.GetReparentedValue(Projections.Property<UnidadGeopolitica>(u => u.Nodo),null,null));
            var l = cri.List();
        }

        [TestMethod]
        public void ToHierarchyId()
        {
            var session = SessionFactory.GetSession();
            var cri = session.CreateCriteria<UnidadGeopolitica>();
            cri.SetProjection(SpecialProjections.ToHierarchyId(
                SpecialProjections.ToStringMethod(Projections.Property<UnidadGeopolitica>(u => u.Nodo))));
            var l = cri.List();
        }

        [TestMethod]
        public void ToStringMethod()
        {
            var session = SessionFactory.GetSession();
            var cri = session.CreateCriteria<UnidadGeopolitica>();
            cri.SetProjection(SpecialProjections.ToStringMethod(Projections.Property<UnidadGeopolitica>(u => u.Nodo)));
            var l = cri.List();
        }
    }
}
