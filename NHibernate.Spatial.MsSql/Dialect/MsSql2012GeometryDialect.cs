using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Spatial.Type;
using NHibernate.Type;

namespace NHibernate.Spatial.Dialect
{
    /// <summary>
    /// 
    /// </summary>
    public class MsSql2012GeometryDialect : MsSql2012SpatialDialect
    {
        private static readonly IType geometryType = new CustomType(typeof(MsSqlGeometryType), null);


        /// <summary>
        /// Gets the type of the geometry.
        /// </summary>
        /// <value>The type of the geometry.</value>
        public override IType GeometryType
        {
            get { return geometryType; }
        }

        /// <summary>
        /// Creates the geometry user type.
        /// </summary>
        /// <returns></returns>
        public override IGeometryUserType CreateGeometryUserType()
        {
            return new MsSqlGeometryType();
        }

        /// <summary>
        /// Gets the SQL Server spatial datatype name.
        /// </summary>
        protected override string SqlTypeName
        {
            get { return "geometry"; }
        }

        /// <summary>
        /// Gets the columns catalog view name.
        /// </summary>
        protected override string GeometryColumnsViewName
        {
            get { return "NHSP_GEOMETRY_COLUMNS"; }
        }

    }
}
