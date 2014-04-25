using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Persistence.NHibernate.Extensions
{
    /// <summary>
    /// Extensiones para utilidades de NHibernate
    /// </summary>
    public static class NHibernateQueryExtensions
    {
        /// <summary>
        /// Permite agregar with (nolock) a alguna tabla
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static IQuery QueryHintNoLock(this IQuery query, string tableName)
        {
            return query.SetComment(QueryHintInterceptor.GetQueryHintNoLock(tableName));
        }

        /// <summary>
        /// Permite agregar with (nolock) a alguna tabla
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static ICriteria QueryHintNoLock(this ICriteria query, string tableName)
        {
            return query.SetComment(QueryHintInterceptor.GetQueryHintNoLock(tableName));
        }

        /// <summary>
        /// Permite forzar un indice a alguna tabla con with(index(nombre_indice))
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tableName"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IQuery QueryHintIndex(this IQuery query, string tableName, string index)
        {
            return query.SetComment(QueryHintInterceptor.GetQueryHintIndex(tableName, index));
        }

        /// <summary>
        /// Permite forzar un indice a alguna tabla con with(index(nombre_indice))
        /// </summary>
        /// <param name="query"></param>
        /// <param name="tableName"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ICriteria QueryHintIndex(this ICriteria query, string tableName, string index)
        {
            return query.SetComment(QueryHintInterceptor.GetQueryHintIndex(tableName, index));
        }
    }
}
