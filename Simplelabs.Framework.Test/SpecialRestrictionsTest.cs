using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplelabs.Framework.Persistence.NHibernate;
using Simplelabs.Framework.Test.Domain;
using Simplelabs.Framework.Persistence.Criterion;
using NHibernate.Criterion;
using Simplelabs.Framework.Persistence.NHibernate.Criterion;

namespace Simplelabs.Framework.Test
{
    [TestClass]
    public class SpecialRestrictionsTest
    {
        [TestMethod]
        public void IsDescendantOf()
        {
            var session = SessionFactory.GetSession();
            var cri = session.CreateCriteria<UnidadGeopolitica>();
            cri.Add(SpecialRestrictions.IsDescendantOf(Projections.Property<UnidadGeopolitica>(u => u.Nodo), "/1/"));
            var l = cri.List<UnidadGeopolitica>();
        }
    }
}
