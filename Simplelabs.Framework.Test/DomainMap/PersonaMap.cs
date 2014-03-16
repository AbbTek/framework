using FluentNHibernate.Mapping;
using Simplelabs.Framework.Test.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Test.DomainMap
{
    public class PersonaMap : ClassMap<Persona>
    {
        public PersonaMap()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Nombre);
        }
    }
}
