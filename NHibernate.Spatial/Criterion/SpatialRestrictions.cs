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
using NHibernate.Criterion;

namespace NHibernate.Spatial.Criterion
{
	/// <summary>
	/// 
	/// </summary>
	public class SpatialRestrictions
	{
		internal SpatialRestrictions()
		{
		}

		#region Filter

		/// <summary>
		/// Filters the specified property name.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="envelope">The envelope.</param>
		/// <param name="srid">The srid.</param>
		/// <returns></returns>
		public static SpatialFilterCriterion Filter(string propertyName, Envelope envelope, int srid)
		{
			return new SpatialFilterCriterion(propertyName, envelope, srid);
		}

        /// <summary>
        /// Filters the specified property name. 
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="envelope"></param>
        /// <param name="srid"></param>
        /// <returns></returns>
        public static SpatialFilterCriterion Filter(IProjection projection, Envelope envelope, int srid)
        {
            return new SpatialFilterCriterion(projection, envelope, srid);
        }

		/// <summary>
		/// Filters the specified property name.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="envelope">The envelope.</param>
		/// <returns></returns>
		public static SpatialFilterCriterion Filter(string propertyName, IGeometry envelope)
		{
			return new SpatialFilterCriterion(propertyName, envelope);
		}

        /// <summary>
        /// Filters the specified property name.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="envelope"></param>
        /// <returns></returns>
        public static SpatialFilterCriterion Filter(IProjection projection, IGeometry envelope)
        {
            return new SpatialFilterCriterion(projection, envelope);
        }
		
		#endregion 

		#region Relations

		/// <summary>
		/// Determines whether the specified geometry property contains another geometry.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="anotherGeometry">Another geometry.</param>
		/// <returns></returns>
		public static SpatialRelationCriterion Contains(string propertyName, object anotherGeometry)
		{
			return new SpatialRelationCriterion(propertyName, SpatialRelation.Contains, anotherGeometry);
		}

        /// <summary>
        /// Determines whether the specified geometry property contains another geometry.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherGeometry"></param>
        /// <returns></returns>
        public static SpatialRelationCriterion Contains(IProjection projection, object anotherGeometry)
        {
            return new SpatialRelationCriterion(projection, SpatialRelation.Contains, anotherGeometry);
        }

		/// <summary>
		/// Determines whether the specified geometry property is covered by another geometry.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="anotherGeometry">Another geometry.</param>
		/// <returns></returns>
		public static SpatialRelationCriterion CoveredBy(string propertyName, object anotherGeometry)
		{
			return new SpatialRelationCriterion(propertyName, SpatialRelation.CoveredBy, anotherGeometry);
		}

        /// <summary>
        /// Determines whether the specified geometry property is covered by another geometry.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherGeometry"></param>
        /// <returns></returns>
        public static SpatialRelationCriterion CoveredBy(IProjection projection, object anotherGeometry)
        {
            return new SpatialRelationCriterion(projection, SpatialRelation.CoveredBy, anotherGeometry);
        }

		/// <summary>
		/// Determines whether the specified geometry property covers another geometry.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="anotherGeometry">Another geometry.</param>
		/// <returns></returns>
		public static SpatialRelationCriterion Covers(string propertyName, object anotherGeometry)
		{
			return new SpatialRelationCriterion(propertyName, SpatialRelation.Covers, anotherGeometry);
		}

        /// <summary>
        /// Determines whether the specified geometry property covers another geometry.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherGeometry"></param>
        /// <returns></returns>
        public static SpatialRelationCriterion Covers(IProjection projection, object anotherGeometry)
        {
            return new SpatialRelationCriterion(projection, SpatialRelation.Covers, anotherGeometry);
        }

		/// <summary>
		/// Determines whether the specified geometry property crosses another geometry.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="anotherGeometry">Another geometry.</param>
		/// <returns></returns>
		public static SpatialRelationCriterion Crosses(string propertyName, object anotherGeometry)
		{
			return new SpatialRelationCriterion(propertyName, SpatialRelation.Crosses, anotherGeometry);
		}

        /// <summary>
        /// Determines whether the specified geometry property crosses another geometry.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherGeometry"></param>
        /// <returns></returns>
        public static SpatialRelationCriterion Crosses(IProjection projection, object anotherGeometry)
        {
            return new SpatialRelationCriterion(projection, SpatialRelation.Crosses, anotherGeometry);
        }

		/// <summary>
		/// Determines whether the specified geometry property is disjoint with another geometry.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="anotherGeometry">Another geometry.</param>
		/// <returns></returns>
		public static SpatialRelationCriterion Disjoint(string propertyName, object anotherGeometry)
		{
			return new SpatialRelationCriterion(propertyName, SpatialRelation.Disjoint, anotherGeometry);
		}

        /// <summary>
        /// Determines whether the specified geometry property is disjoint with another geometry.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherGeometry"></param>
        /// <returns></returns>
        public static SpatialRelationCriterion Disjoint(IProjection projection, object anotherGeometry)
        {
            return new SpatialRelationCriterion(projection, SpatialRelation.Disjoint, anotherGeometry);
        }

		/// <summary>
		/// Determines whether the specified geometry property is equals to another geometry.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="anotherGeometry">Another geometry.</param>
		/// <returns></returns>
		public static SpatialRelationCriterion Eq(string propertyName, object anotherGeometry)
		{
			return new SpatialRelationCriterion(propertyName, SpatialRelation.Equals, anotherGeometry);
		}

        /// <summary>
        /// Determines whether the specified geometry property is equals to another geometry.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherGeometry"></param>
        /// <returns></returns>
        public static SpatialRelationCriterion Eq(IProjection projection, object anotherGeometry)
        {
            return new SpatialRelationCriterion(projection, SpatialRelation.Equals, anotherGeometry);
        }

		/// <summary>
		/// Determines whether the specified geometry property intersects another geometry.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="anotherGeometry">Another geometry.</param>
		/// <returns></returns>
		public static SpatialRelationCriterion Intersects(string propertyName, object anotherGeometry)
		{
			return new SpatialRelationCriterion(propertyName, SpatialRelation.Intersects, anotherGeometry);
		}

        /// <summary>
        /// Determines whether the specified geometry property intersects another geometry.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherGeometry"></param>
        /// <returns></returns>
        public static SpatialRelationCriterion Intersects(IProjection projection, object anotherGeometry)
        {
            return new SpatialRelationCriterion(projection, SpatialRelation.Intersects, anotherGeometry);
        }

		/// <summary>
		/// Determines whether the specified geometry property overlaps another geometry.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="anotherGeometry">Another geometry.</param>
		/// <returns></returns>
		public static SpatialRelationCriterion Overlaps(string propertyName, object anotherGeometry)
		{
			return new SpatialRelationCriterion(propertyName, SpatialRelation.Overlaps, anotherGeometry);
		}

        /// <summary>
        /// Determines whether the specified geometry property overlaps another geometry.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherGeometry"></param>
        /// <returns></returns>
        public static SpatialRelationCriterion Overlaps(IProjection projection, object anotherGeometry)
        {
            return new SpatialRelationCriterion(projection, SpatialRelation.Overlaps, anotherGeometry);
        }

		/// <summary>
		/// Determines whether the specified geometry property touches another geometry.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="anotherGeometry">Another geometry.</param>
		/// <returns></returns>
		public static SpatialRelationCriterion Touches(string propertyName, object anotherGeometry)
		{
			return new SpatialRelationCriterion(propertyName, SpatialRelation.Touches, anotherGeometry);
		}

        /// <summary>
        /// Determines whether the specified geometry property touches another geometry.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherGeometry"></param>
        /// <returns></returns>
        public static SpatialRelationCriterion Touches(IProjection projection, object anotherGeometry)
        {
            return new SpatialRelationCriterion(projection, SpatialRelation.Touches, anotherGeometry);
        }

		/// <summary>
		/// Determines whether the specified geometry property is within another geometry.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="anotherGeometry">Another geometry.</param>
		/// <returns></returns>
		public static SpatialRelationCriterion Within(string propertyName, object anotherGeometry)
		{
			return new SpatialRelationCriterion(propertyName, SpatialRelation.Within, anotherGeometry);
		}

        /// <summary>
        /// Determines whether the specified geometry property is within another geometry.
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="anotherGeometry"></param>
        /// <returns></returns>
        public static SpatialRelationCriterion Within(IProjection projection, object anotherGeometry)
        {
            return new SpatialRelationCriterion(projection, SpatialRelation.Within, anotherGeometry);
        }
		#endregion

		#region Validations

		/// <summary>
		/// Determines whether the specified geometry property is closed.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static SpatialValidationCriterion IsClosed(string propertyName)
		{
			return new SpatialValidationCriterion(propertyName, SpatialValidation.IsClosed);
		}

        /// <summary>
        /// Determines whether the specified geometry property is closed.
        /// </summary>
        /// <param name="projection"></param>
        /// <returns></returns>
        public static SpatialValidationCriterion IsClosed(IProjection projection)
        {
            return new SpatialValidationCriterion(projection, SpatialValidation.IsClosed);
        }

		/// <summary>
		/// Determines whether the specified geometry property is empty.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static SpatialValidationCriterion IsEmpty(string propertyName)
		{
			return new SpatialValidationCriterion(propertyName, SpatialValidation.IsEmpty);
		}

        /// <summary>
        /// Determines whether the specified geometry property is empty.
        /// </summary>
        /// <param name="projection"></param>
        /// <returns></returns>
        public static SpatialValidationCriterion IsEmpty(IProjection projection)
        {
            return new SpatialValidationCriterion(projection, SpatialValidation.IsEmpty);
        }

		/// <summary>
		/// Determines whether the specified geometry property is ring.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static SpatialValidationCriterion IsRing(string propertyName)
		{
			return new SpatialValidationCriterion(propertyName, SpatialValidation.IsRing);
		}

        /// <summary>
        /// Determines whether the specified geometry property is ring.
        /// </summary>
        /// <param name="projection"></param>
        /// <returns></returns>
        public static SpatialValidationCriterion IsRing(IProjection projection)
        {
            return new SpatialValidationCriterion(projection, SpatialValidation.IsRing);
        }

		/// <summary>
		/// Determines whether the specified geometry property is simple.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static SpatialValidationCriterion IsSimple(string propertyName)
		{
			return new SpatialValidationCriterion(propertyName, SpatialValidation.IsSimple);
		}

        /// <summary>
        /// Determines whether the specified geometry property is simple.
        /// </summary>
        /// <param name="projection"></param>
        /// <returns></returns>
        public static SpatialValidationCriterion IsSimple(IProjection projection)
        {
            return new SpatialValidationCriterion(projection, SpatialValidation.IsSimple);
        }

		/// <summary>
		/// Determines whether the specified geometry property is valid.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <returns></returns>
		public static SpatialValidationCriterion IsValid(string propertyName)
		{
			return new SpatialValidationCriterion(propertyName, SpatialValidation.IsValid);
		}

        /// <summary>
        /// Determines whether the specified geometry property is valid.
        /// </summary>
        /// <param name="projection"></param>
        /// <returns></returns>
        public static SpatialValidationCriterion IsValid(IProjection projection)
        {
            return new SpatialValidationCriterion(projection, SpatialValidation.IsValid);
        }
		#endregion
	}

}