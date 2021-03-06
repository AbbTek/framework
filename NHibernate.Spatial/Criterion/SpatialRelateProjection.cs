// Copyright 2007 - Ricardo Stuven (rstuven@gmail.com)
//
// This file is part of NHibernate.Spatial.
// NHibernate.Spatial is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// NHibernate.Spatial is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with NHibernate.Spatial; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Collections.Generic;
using NHibernate.Spatial.Dialect;
using NHibernate.SqlCommand;
using NHibernate.Criterion;
using NHibernate.Type;

namespace NHibernate.Spatial.Criterion
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SpatialRelateProjection : SpatialProjection
    {
        private readonly string anotherPropertyName;
        private readonly string pattern;
        private readonly IProjection anotherProjection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialRelateProjection"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="anotherPropertyName">Name of another property.</param>
        public SpatialRelateProjection(string propertyName, string anotherPropertyName)
            : base(propertyName)
        {
            this.anotherPropertyName = anotherPropertyName;
            this.pattern = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherProjection"></param>
        public SpatialRelateProjection(IProjection projection, IProjection anotherProjection)
            : base(projection)
        {
            this.anotherProjection = anotherProjection;
            this.pattern = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpatialRelateProjection"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="anotherPropertyName">Name of another property.</param>
        /// <param name="pattern">The pattern.</param>
        public SpatialRelateProjection(string propertyName, string anotherPropertyName, string pattern)
            : base(propertyName)
        {
            this.anotherPropertyName = anotherPropertyName;
            this.pattern = pattern;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherProjection"></param>
        /// <param name="pattern"></param>
        public SpatialRelateProjection(IProjection projection, IProjection anotherProjection, string pattern)
            : base(projection)
        {
            this.anotherProjection = anotherProjection;
            this.pattern = pattern;
        }

        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="criteriaQuery">The criteria query.</param>
        /// <returns></returns>
        public override IType[] GetTypes(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            if (this.pattern == null)
            {
                return new IType[] { NHibernateUtil.String };
            }
            return new IType[] { NHibernateUtil.Boolean };
        }

        /// <summary>
        /// Render the SQL Fragment.
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="position"></param>
        /// <param name="criteriaQuery"></param>
        /// <param name="enabledFilters"></param>
        /// <returns></returns>
        public override SqlString ToSqlString(ICriteria criteria, int position, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            ISpatialDialect spatialDialect = (ISpatialDialect)criteriaQuery.Factory.Dialect;
            SqlString sqlString = null;

            if (this.propertyName != null)
            {
                string column1 = criteriaQuery.GetColumn(criteria, this.propertyName);
                string column2 = criteriaQuery.GetColumn(criteria, this.anotherPropertyName);
                sqlString = spatialDialect.GetSpatialRelateString(column1, column2, this.pattern, this.pattern != null, false);
            }
            else
            {
                var obj1 = SqlStringHelper.RemoveAsAliasesFromSql(projection.ToSqlString(criteria, position, criteriaQuery, enabledFilters));
                var obj2 = SqlStringHelper.RemoveAsAliasesFromSql(anotherProjection.ToSqlString(criteria, position, criteriaQuery, enabledFilters));
                sqlString = spatialDialect.GetSpatialRelateString(obj1, obj2, this.pattern, this.pattern != null, false);
            }
            return new SqlStringBuilder()
                .Add(sqlString)
                .Add(" as y")
                .Add(position.ToString())
                .Add("_")
                .ToSqlString();
        }


        public override SqlString ToSqlString(string column, ISpatialDialect spatialDialect)
        {
            throw new NotImplementedException();
        }

        public override SqlString ToSqlString(IProjection projection, ISpatialDialect spatialDialect, ICriteria criteria, int position, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            throw new NotImplementedException();
        }
    }
}
