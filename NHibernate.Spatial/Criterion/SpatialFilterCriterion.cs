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
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NHibernate.Engine;
using NHibernate.Criterion;
using NHibernate.Persister.Entity;
using NHibernate.Spatial.Dialect;
using NHibernate.SqlCommand;
using NHibernate.Type;
using System.Collections.Generic;
using System.Linq;

namespace NHibernate.Spatial.Criterion
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class SpatialFilterCriterion : AbstractCriterion
	{
		//private readonly string propertyName;
		private readonly IGeometry envelope;
        private readonly IProjection projection;

		/// <summary>
		/// Initializes a new instance of the <see cref="SpatialFilterCriterion"/> class.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="envelope">The envelope.</param>
		/// <param name="srid">The srid.</param>
		public SpatialFilterCriterion(string propertyName, Envelope envelope, int srid)
		{			
            this.projection = Projections.Property(propertyName);
			this.envelope = GeometryFactory.Default.ToGeometry(envelope);
			this.envelope.SRID = srid;
		}

        public SpatialFilterCriterion(IProjection projection, Envelope envelope, int srid)
        {
            this.projection = projection;
            this.envelope = GeometryFactory.Default.ToGeometry(envelope);
            this.envelope.SRID = srid;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="SpatialFilterCriterion"/> class.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="envelope">The envelope.</param>
		public SpatialFilterCriterion(string propertyName, IGeometry envelope)
		{			
            this.projection = Projections.Property(propertyName);
			this.envelope = envelope;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="envelope"></param>
        public SpatialFilterCriterion(IProjection projection, IGeometry envelope)
        {
            this.projection = projection;
            this.envelope = envelope;
        }

		/// <summary>
		/// Return typed values for all parameters in the rendered SQL fragment
		/// </summary>
		/// <param name="criteria"></param>
		/// <param name="criteriaQuery"></param>
		/// <returns>
		/// An array of TypedValues for the Expression.
		/// </returns>
		public override TypedValue[] GetTypedValues(ICriteria criteria, ICriteriaQuery criteriaQuery)
		{
            return CriterionUtil.GetTypedValues(criteriaQuery, criteria, projection, null, this.envelope);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
        public override IProjection[] GetProjections()
		{
            return new IProjection[] { projection };
		}

		/// <summary>
		/// Render a SqlString for the expression.
		/// </summary>
		/// <param name="criteria"></param>
		/// <param name="criteriaQuery"></param>
		/// <param name="enabledFilters"></param>
		/// <returns>
		/// A SqlString that contains a valid Sql fragment.
		/// </returns>
		public override SqlString ToSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
		{
			ISpatialDialect spatialDialect = (ISpatialDialect)criteriaQuery.Factory.Dialect;

            SqlString[] columnsUsingProjection =
                CriterionUtil.GetColumnNames(null, projection, criteriaQuery, criteria, enabledFilters);

            IType typeUsingProjection = projection.GetTypes(criteria, criteriaQuery).Single();
            
			if (typeUsingProjection.IsCollectionType)
			{
				throw new QueryException(string.Format("cannot use collection property ({0}.{1}) directly in a criterion, use ICriteria.CreateCriteria instead", criteriaQuery.GetEntityName(criteria), this.projection.ToString()));
			}
			string[] keyColumns = criteriaQuery.GetIdentifierColumns(criteria);

            
			string entityType = criteriaQuery.GetEntityName(criteria);//, this.propertyName);
			AbstractEntityPersister entityPersister = (AbstractEntityPersister)criteriaQuery.Factory.GetEntityPersister(entityType);

			// Only one key column is assumed
			string keyColumn = keyColumns[0];
			string alias = criteriaQuery.GetSQLAlias(criteria);//, this.propertyName);
			string tableName = entityPersister.TableName;
			int aliasLength = alias.Length + 1;

            Parameter[] parameters = criteriaQuery.NewQueryParameter(CriterionUtil.GetTypedValues(criteriaQuery, criteria, projection, null, new object[] { this.envelope }).Single()).ToArray();
			
            SqlStringBuilder builder = new SqlStringBuilder(10 * columnsUsingProjection.Length);
			for (int i = 0; i < columnsUsingProjection.Length; i++)
			{
				if (i > 0)
				{
					builder.Add(" AND ");
				}
				string geometryColumn = columnsUsingProjection[i].ToString().Remove(0, aliasLength);
                builder.Add(spatialDialect.GetSpatialFilterString(alias, geometryColumn, keyColumn, tableName, parameters[i]));
			}
			return builder.ToSqlString();
		}

		/// <summary>
		/// Gets a string representation of the <see cref="T:NHibernate.Criterion.AbstractCriterion"/>.
		/// </summary>
		/// <returns>
		/// A String that shows the contents of the <see cref="T:NHibernate.Criterion.AbstractCriterion"/>.
		/// </returns>
		/// <remarks>
		/// This is not a well formed Sql fragment.  It is useful for logging what the <see cref="T:NHibernate.Criterion.AbstractCriterion"/>
		/// looks like.
		/// </remarks>
		public override string ToString()
		{
            return projection.ToString();
		}

	}
}
