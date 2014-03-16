using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simplelabs.Framework.Test
{
    [TestClass]
    public class SetupTest
    {
        [TestMethod]
        public void Test()
        {
            var rr = 1;
        }

        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            var s = Simplelabs.Framework.Persistence.NHibernate.SessionFactory.GetSession();
        }
    }
}
