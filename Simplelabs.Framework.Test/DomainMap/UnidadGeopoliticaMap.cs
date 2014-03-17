using FluentNHibernate.Mapping;
using Simplelabs.Framework.Persistence.NHibernate;
using Simplelabs.Framework.Test.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Test.DomainMap
{
    public class UnidadGeopoliticaMap : ClassMap<UnidadGeopolitica>
    {
        public UnidadGeopoliticaMap()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Nodo).CustomType<SqlHierarchyIdType>();
            References<UnidadGeopolitica>(x => x.Padre)          
                .Column("IDPadre")
                .Cascade.All();
            HasMany<UnidadGeopolitica>(x => x.Hijos)
                .Cascade.All();
        }
    }
}
