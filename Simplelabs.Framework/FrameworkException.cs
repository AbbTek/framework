using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplelabs.Framework
{
    [Serializable]
    public class FrameworkException : Exception
    {
        public FrameworkException() { }
        public FrameworkException(string message) : base(message) { }
        public FrameworkException(string message, Exception inner) : base(message, inner) { }
        protected FrameworkException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
