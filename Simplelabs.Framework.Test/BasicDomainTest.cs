using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplelabs.Framework.Persistence.NHibernate;
using Simplelabs.Framework.Test.Domain;
using NHibernate.Criterion;

namespace Simplelabs.Framework.Test
{
    [TestClass]
    public class BasicDomainTest
    {
        [TestMethod]
        public void Create()
        {
            var session = SessionFactory.GetSession();
            using (var tx = session.BeginTransaction())
            {
                var criteria = session.CreateCriteria<Persona>();
                criteria.SetProjection(Projections.RowCount());
                var total = criteria.UniqueResult<int>();
                if (total < 2000)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        session.Save(new Persona()
                        {
                            Nombre = "Carlos " + i
                        });
                    }
                }
                tx.Commit();
            }
        }
    }
}
