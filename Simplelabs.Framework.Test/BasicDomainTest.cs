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
        public void CreatePersonas()
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

        [TestMethod]
        public void CreateUnidadGeopolitica()
        {
            var session = SessionFactory.GetSession();
            using (var tx = session.BeginTransaction())
            {
                var padre = new UnidadGeopolitica()
                {
                    Nodo = "/1/"
                };
                padre.Hijos = new System.Collections.Generic.List<UnidadGeopolitica>();
                padre.Hijos.Add(new UnidadGeopolitica()
                {
                    Padre = padre,
                    Nodo = "/1/1/"
                });
                padre.Hijos.Add(new UnidadGeopolitica()
                {
                    Padre = padre,
                    Nodo = "/1/2/"
                });
                padre.Hijos.Add(new UnidadGeopolitica()
                {
                    Padre = padre,
                    Nodo = "/1/3/"
                });

                session.Save(padre);
                tx.Commit();
            }
        }
    }
}
