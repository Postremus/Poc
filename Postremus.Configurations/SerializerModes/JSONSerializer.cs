using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Poc.SerializerModes
{
    public class JSONSerializer : ISerializerMode
    {
        DataContractJsonSerializer _seri;

        public JSONSerializer()
        {
        }

        public void Serialize<T>(System.IO.Stream serialisationStream, T value)
        {
            _seri = new DataContractJsonSerializer(typeof(T));
            _seri.WriteObject(serialisationStream, value);
        }

        public T Deserialize<T>(System.IO.Stream serialisationStream)
        {
            _seri = new DataContractJsonSerializer(typeof(T));
            return (T)_seri.ReadObject(serialisationStream);
        }
    }
}
