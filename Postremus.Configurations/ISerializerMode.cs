using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Poc
{
    public interface ISerializerMode
    {
        void Serialize<T>(Stream serialisationStream, T value);
        T Deserialize<T>(Stream serialisationStream);
    }
}
