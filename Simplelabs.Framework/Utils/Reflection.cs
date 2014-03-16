using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework.Utils
{
    public static class Reflection
    {
        /// <summary>
        /// Crea una instancia por el nombre del tipo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static T CreateObject<T>(string typeName) where T : class
        {
            return CreateObject<T>(typeName, null);
        }

        public static T CreateObject<T>(string typeName, object[] args) where T : class
        {
            var type = Type.GetType(typeName);
            var obj = type.Assembly.CreateInstance(type.FullName, false, System.Reflection.BindingFlags.CreateInstance, null, args, null, new object[] { });
            return obj as T;
        }
    }
}
