﻿using NHibernate;
using NHibernate.Criterion;
using NHibernate.Engine;
using NHibernate.SqlCommand;
using NHibernate.Type;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Simplelabs.Framework.Persistence.NHibernate.Projections
{
    internal class GetLevelProjection : SimpleProjection
    {
        private readonly IProjection _projection;


        public GetLevelProjection(IProjection projection)
        {
            _projection = projection;
        }

        public override SqlString ToSqlString(ICriteria criteria, int position, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            var loc = position * GetHashCode();
            var val = _projection.ToSqlString(criteria, loc, criteriaQuery, enabledFilters);
            val = val.Substring(0, val.LastIndexOfCaseInsensitive(" as "));

            var ret = new SqlStringBuilder()
                .Add(val)
                .Add(".GetLevel()")
                .Add(" as ")
                .Add(GetColumnAliases(position)[0])
                .ToSqlString();

            return ret;
        }

        public override IType[] GetTypes(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return new IType[] { NHibernateUtil.Int32 };
        }

        public override bool IsGrouped
        {
            get { return _projection.IsGrouped; }
        }

        public override bool IsAggregate
        {
            get { return false; }
        }

        public override SqlString ToGroupSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            return _projection.ToGroupSqlString(criteria, criteriaQuery, enabledFilters);
        }
    }
}
