using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Models.Domain
{
    public class Direccion
    {
        public virtual int ID { get; set; }
        public virtual string Calle { get; set; }
        public virtual string Numero { get; set; }
        public virtual IPoint Referencia { get; set; }
        public virtual string TextoReferencia { get; set; }
    }
}