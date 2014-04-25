using FluentNHibernate.Mapping;
using Simplelabs.Framework.Test.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Test.DomainMap
{
    public class UnidadMap : ClassMap<Unidad>
    {
        public UnidadMap()
        {
            Schema("TestSchema");
            Id(x => x.ID)
                .Column("IDUnidad")
                .GeneratedBy.Identity();
            Map(x => x.Nombre);
            Map(x => x.Estado);
        }
    }
}
