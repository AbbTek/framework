using NHibernate;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.SqlCommand;
using Simplelabs.Framework.Persistence.NHibernate;
using Simplelabs.Framework.Persistence.NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Persistence.Criterion
{
    /// <summary>
    /// Expresion para las consultas de HierarchyId
    /// </summary>
    [Serializable]
    public class IsDescendantOfExpression : AbstractCriterion
    {
        private readonly IProjection _projection;
        private readonly TypedValue _typedValue;
        private readonly string _value;

        /// <summary>
        /// Consultas del tipo IsDescendantOf
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value">String con formato de la jerarquia ejemplo :/10/1/3/</param>
        public IsDescendantOfExpression(string propertyName, string value)
        {
            _projection = global::NHibernate.Criterion.Projections.Property(propertyName);
            _value = value;
            _typedValue = new TypedValue(new SqlHierarchyIdType(), _value, EntityMode.Poco);
        }

        /// <summary>
        /// Consultas del tipo IsDescendantOf
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="value">String con formato de la jerarquia ejemplo :/10/1/3/</param>
        public IsDescendantOfExpression(IProjection projection, string value)
        {
            _projection = projection;
            _value = value;
            _typedValue = new TypedValue(new SqlHierarchyIdType(), _value, EntityMode.Poco);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="criteriaQuery"></param>
        /// <param name="enabledFilters"></param>
        /// <returns></returns>
        public override SqlString ToSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery,
                                              IDictionary<string, IFilter> enabledFilters)
        {
            var columns = CriterionUtil.GetColumnNames(null, _projection, criteriaQuery, criteria,
                                                       enabledFilters);
            if (columns.Length != 1)
                throw new HibernateException(
                    "IsDescendantOf may only be used with single-column properties / projections.");

            var lhs = new SqlStringBuilder(6);

            lhs.Add(columns[0]);
            lhs.Add(".IsDescendantOf(");
            lhs.Add(criteriaQuery.NewQueryParameter(_typedValue).Single());
            lhs.Add(") = 1");

            return lhs.ToSqlString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="criteriaQuery"></param>
        /// <returns></returns>
        public override TypedValue[] GetTypedValues(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return new[] { _typedValue };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IProjection[] GetProjections()
        {
            return new[] { _projection };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _projection + ".IsDescendantOf('" + _value + "')";
        }
    }
}
