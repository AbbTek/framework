using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Configuration.Elements
{
    /// <summary>
    /// Para los coleciones genéricas
    /// </summary>
    public interface IKeyElement
    {
        /// <summary>
        /// Representa el elemento que es la llave del objeto
        /// </summary>
        object Key
        {
            get;
        }
    }
}
