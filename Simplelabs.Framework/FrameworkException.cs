using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework
{
    /// <summary>
    /// Excepción para los errores del Framework
    /// </summary>
    [Serializable]
    public class FrameworkException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public FrameworkException() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public FrameworkException(string message) : base(message) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public FrameworkException(string message, Exception inner) : base(message, inner) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected FrameworkException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
