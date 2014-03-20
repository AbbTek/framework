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
	public class SpatialRelationProjection : SpatialProjection
	{
		private readonly SpatialRelation relation;
		private readonly string anotherPropertyName;
        private readonly IProjection anotherProjection;

		/// <summary>
		/// Initializes a new instance of the <see cref="SpatialRelationProjection"/> class.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="relation">The relation.</param>
		/// <param name="anotherPropertyName">Name of another property.</param>
		public SpatialRelationProjection(string propertyName, SpatialRelation relation, string anotherPropertyName)
			: base(propertyName)
		{
			this.relation = relation;
			this.anotherPropertyName = anotherPropertyName;
		}

        public SpatialRelationProjection(IProjection projection, SpatialRelation relation, IProjection anotherProjection)
            : base(projection)
        {
            this.relation = relation;
            this.anotherProjection = anotherProjection;
        }

		/// <summary>
		/// Gets the types.
		/// </summary>
		/// <param name="criteria">The criteria.</param>
		/// <param name="criteriaQuery">The criteria query.</param>
		/// <returns></returns>
		public override IType[] GetTypes(ICriteria criteria, ICriteriaQuery criteriaQuery)
		{
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
            SqlString sqlString = this.propertyName != null ? 
                spatialDialect.GetSpatialRelationString(criteriaQuery.GetColumn(criteria, this.propertyName), this.relation, criteriaQuery.GetColumn(criteria, this.anotherPropertyName), false) :
                spatialDialect.GetSpatialRelationString(SqlStringHelper.RemoveAsAliasesFromSql(projection.ToSqlString(criteria, position, criteriaQuery, enabledFilters)),
                this.relation, SqlStringHelper.RemoveAsAliasesFromSql(anotherProjection.ToSqlString(criteria, position, criteriaQuery, enabledFilters)), false);
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
