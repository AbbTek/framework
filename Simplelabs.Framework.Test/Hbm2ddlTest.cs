using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simplelabs.Framework.Persistence.NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Simplelabs.Framework.Test
{
    [TestClass]
    public class Hbm2ddlTest
    {
        [TestMethod]
        public void CreateDDL()
        {
            var s = new SchemaExport(SessionFactory.GetCurrentConfiguration());
            s.SetOutputFile("d:\\testddl.sql");
            s.Create(false, false);
        }
    }
}
