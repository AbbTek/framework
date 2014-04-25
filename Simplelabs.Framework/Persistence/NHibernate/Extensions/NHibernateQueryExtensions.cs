using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Persistence.NHibernate.Extensions
{
    public static class NHibernateQueryExtensions
    {
        public static IQuery QueryHintNoLock(this IQuery query, string tableName)
        {
            return query.SetComment(QueryHintInterceptor.GetQueryHintNoLock(tableName));
        }

        public static ICriteria QueryHintNoLock(this ICriteria query, string tableName)
        {
            return query.SetComment(QueryHintInterceptor.GetQueryHintNoLock(tableName));
        }
    }
}
