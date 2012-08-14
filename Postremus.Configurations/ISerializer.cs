using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Poc
{
    public interface ISerializer
    {
        void Serialize<T>(string path, T value);
        void Serialize<T>(Stream serialisationStream, T value);
        T Deserialize<T>(string path);
        T Deserialize<T>(Stream serialisationStream);
    }
}
