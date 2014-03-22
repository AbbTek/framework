using NHibernate.Criterion;
using Simplelabs.Framework.Persistence.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Persistence.NHibernate.Criterion
{
    /// <summary>
    /// Restricciones especiales, para objetos como HierarchyId
    /// </summary>
    public  static class SpecialRestrictions
    {
        /// <summary>
        /// Consultas del tipo IsDescendantOf sobre un tipo de dato heirarchyID
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value">Valor de la jerarquia como /10/1/3</param>
        /// <returns></returns>
        public static AbstractCriterion IsDescendantOf(string propertyName, string value)
        {            
            return new IsDescendantOfExpression(propertyName, value);
        }

        /// <summary>
        /// Consultas del tipo IsDescendantOf sobre un tipo de dato heirarchyID
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value">Valor de la jerarquia como /10/1/3</param>
        /// <returns></returns>
        public static AbstractCriterion IsDescendantOf(IProjection property, string value)
        {
            return new IsDescendantOfExpression(property, value);
        }
    }
}
