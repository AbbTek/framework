using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Configuration.Elements
{
    /// <summary>
    /// Utilidad para manejar colecciones de elementos de configuración
    /// </summary>
    /// <typeparam name="T">Elemento de la configuración</typeparam>
    public class ElementsCollection<T> : ConfigurationElementCollection where T : ConfigurationElement, IKeyElement, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return (ConfigurationElement)new T();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            var obj = element as IKeyElement;
            return obj != null ? obj.Key : null;
        }

        /// <summary>
        /// 
        /// </summary>
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }        
    }
}
