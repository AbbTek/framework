using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Persistence.NHibernate.Projections
{
    /// <summary>
    /// Para IProjections especiales, como las de HierarchyId
    /// </summary>
    public static class SpecialProjections
    {
        /// <summary>
        /// Funcion GetAncestor para HierarchyId
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static SimpleProjection GetAncestor(IProjection projection, int level)
        {
            return new GetAncestorProjection(projection, level);
        }

        /// <summary>
        /// Funcion GetDescendant para HierarchyId
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="child1"></param>
        /// <param name="child2"></param>
        /// <returns></returns>
        public static SimpleProjection GetDescendant(IProjection projection, string child1, string child2)
        {
            return new GetDescendantProjection(projection, child1, child2);
        }

        /// <summary>
        /// Funcion GetLevel para HierarchyId
        /// </summary>
        /// <param name="projection"></param>
        /// <returns></returns>
        public static SimpleProjection GetLevel(IProjection projection)
        {
            return new GetLevelProjection(projection);
        }

        /// <summary>
        /// Funcion GetReparentedValue para HierarchyId
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="oldRoot"></param>
        /// <param name="newRoot"></param>
        /// <returns></returns>
        public static SimpleProjection GetReparentedValue(IProjection projection, string oldRoot, string newRoot)
        {
            return new GetReparentedValueProjection(projection, oldRoot, newRoot);
        }

        /// <summary>
        /// Funcion ToHierarchyId para HierarchyId
        /// </summary>
        /// <param name="projection"></param>
        /// <returns></returns>
        public static SimpleProjection ToHierarchyId(IProjection projection)
        {
            return new ToHierarchyIdProjection(projection);
        }

        /// <summary>
        /// Funcion ToString para algun objeto
        /// </summary>
        /// <param name="projection"></param>
        /// <returns></returns>
        public static SimpleProjection ToStringMethod(IProjection projection)
        {
            return new ToStringMethodProjection(projection);
        }
    }
}
