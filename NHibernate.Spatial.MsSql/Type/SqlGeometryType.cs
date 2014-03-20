// Copyright 2008 - Ricardo Stuven (rstuven@gmail.com)
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
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Types;
using NHibernate.SqlTypes;
using NHibernate.Type;
using System.IO;

namespace NHibernate.Spatial.Type
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	public class SqlGeometryType : ImmutableType
	{
        /// <summary>
        /// 
        /// </summary>
		public SqlGeometryType()
			// Pass any SqlType to base class.
			: base(SqlTypeFactory.Byte)
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rs"></param>
        /// <param name="name"></param>
        /// <returns></returns>
		public override object NullSafeGet(IDataReader rs, string name)
		{
			object value = base.NullSafeGet(rs, name);
			return value ?? SqlGeometry.Null;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rs"></param>
        /// <param name="name"></param>
        /// <returns></returns>
		public override object Get(IDataReader rs, string name)
		{
			return Get(rs, rs.GetOrdinal(name));
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
		public override string ToString(object value)
		{
			return value.ToString();
		}

        /// <summary>
        /// 
        /// </summary>
		public override string Name
		{
			get { return ReturnedClass.Name; }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rs"></param>
        /// <param name="index"></param>
        /// <returns></returns>
		public override object Get(IDataReader rs, int index)
		{
            var reader = rs as NHibernate.Driver.NHybridDataReader;
            if (reader != null)
                return this.DeserializeSqlGeometry(reader.Target as SqlDataReader, index);
            else
                return (SqlGeometry)rs[index];
		}

        private SqlGeometry DeserializeSqlGeometry(SqlDataReader sqlDataReader, int geometryColumnIndex)
        {
            SqlGeometry sqlGeometry = new SqlGeometry();
            System.Data.SqlTypes.SqlBytes bytes = sqlDataReader.GetSqlBytes(geometryColumnIndex);
            using (MemoryStream stream = new MemoryStream(bytes.Buffer))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    sqlGeometry.Read(reader);
                }
            }
            return sqlGeometry;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
		public override object FromStringValue(string xml)
		{
			return SqlGeometry.STGeomFromText(new SqlChars(xml), 0);
		}

        /// <summary>
        /// 
        /// </summary>
		public override System.Type ReturnedClass
		{
			get { return typeof(SqlGeometry); }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="value"></param>
        /// <param name="index"></param>
		public override void Set(IDbCommand cmd, object value, int index)
		{
			object parameterValue = ((INullable) value).IsNull ? DBNull.Value : value;

            SqlParameter sqlParameter = (SqlParameter)cmd.Parameters[index];
			sqlParameter.SqlDbType = SqlDbType.Udt;
			sqlParameter.UdtTypeName = "geometry";
			sqlParameter.Value = parameterValue;
		}
	}
}
