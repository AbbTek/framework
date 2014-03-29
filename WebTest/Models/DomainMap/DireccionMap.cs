using FluentNHibernate.Mapping;
using NHibernate.Spatial.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTest.Models.Domain;

namespace WebTest.Models.DomainMap
{
    public class DireccionMap : ClassMap<Direccion>
    {
        public DireccionMap()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Calle);
            Map(x => x.Numero);
            Map(x => x.Referencia)
                .CustomType<GeometryType>();
            Map(x => x.TextoReferencia);
        }
    }
}