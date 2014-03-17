using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Test.Domain
{
    public class UnidadGeopolitica
    {
        public virtual int ID { get; set; }
        public virtual string Nodo { get; set; }

        public virtual UnidadGeopolitica Padre { get; set; }

        public virtual List<UnidadGeopolitica> Hijos { get; set; }
    }
}
