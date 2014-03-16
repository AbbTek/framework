using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplelabs.Framework.Persistence.NHibernate;
using Simplelabs.Framework.Test.Domain;

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
                for (int i = 0; i < 1000; i++)
                {
                    session.Save(new Persona()
                    {
                        Nombre = "Carlos " + i
                    });
                }
                tx.Commit();
            }        
        }
    }
}
