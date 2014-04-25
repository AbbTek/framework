using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Persistence.NHibernate
{
    [Serializable]
    public class QueryHintInterceptor : EmptyInterceptor
    {
        internal const string QUERY_HINT_NOLOCK_COMMENT = "queryhint-nolock: ";
        internal const string QUERY_HINT_INDEX_COMMENT = "queryhint-index: ";

        /// <summary>
        /// Gets a comment to add to a sql query to tell this interceptor to add 'OPTION (TABLE HINT(table_alias, INDEX = index_name))' to the query.
        /// </summary>
        internal static string GetQueryHintNoLock(string tableName)
        {
            return QUERY_HINT_NOLOCK_COMMENT + tableName;
        }

        internal static string GetQueryHintIndex(string tableName, string index)
        {
            return QUERY_HINT_INDEX_COMMENT + tableName + " " + index;
        }

        public override SqlString OnPrepareStatement(SqlString sql)
        {
            if (sql.ToString().Contains(QUERY_HINT_NOLOCK_COMMENT))
            {
                sql = ApplyQueryHintNoLock(sql, sql.ToString());
            }

            return base.OnPrepareStatement(sql);
        }

        private static SqlString ApplyQueryHintNoLock(SqlString sql, string sqlString)
        {
            var indexOfTableName = sqlString.IndexOf(QUERY_HINT_NOLOCK_COMMENT) + QUERY_HINT_NOLOCK_COMMENT.Length;

            if (indexOfTableName < 0)
                throw new InvalidOperationException(
                    "Query hint comment should contain name of table, like this: '/* queryhint-nolock: tableName */'");

            var indexOfTableNameEnd = sqlString.IndexOf(" ", indexOfTableName + 1);

            if (indexOfTableNameEnd < 0)
                throw new InvalidOperationException(
                    "Query hint comment should contain name of table, like this: '/* queryhint-nlock: tableName */'");

            var tableName = sqlString.Substring(indexOfTableName, indexOfTableNameEnd - indexOfTableName).Trim();

            var regex = new Regex(string.Format(@"\[?{0}\]?\s([\w_]+)", tableName));

            var aliasMatches = regex.Matches(sqlString, indexOfTableNameEnd);

            if (aliasMatches.Count == 0)
                throw new InvalidOperationException("Could not find aliases for table with name: " + tableName);

            var q = 0;
            foreach (Match aliasMatch in aliasMatches)
            {
                var alias = aliasMatch.Groups[1].Value;
                var aliasIndex = aliasMatch.Groups[1].Index + q + alias.Length;

                sql = sql.Insert(aliasIndex, " WITH (NOLOCK)");
                q += " WITH (NOLOCK)".Length;
            }
            return sql;
        }

        private static SqlString InsertOption(SqlString sql, string option)
        {
            // The original code used just "sql.Length". I found that the end of the sql string actually contains new lines and a semi colon.
            // Might need to change in future versions of NHibernate.
            var regex = new Regex(@"[^\;\s]", RegexOptions.RightToLeft);
            var insertAt = regex.Match(sql.ToString()).Index + 1;
            return sql.Insert(insertAt, option);
        }
    }
}
