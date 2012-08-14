using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace Poc.Serializer
{
    public class SoapSerializer : ISerializer
    {
        private SoapFormatter _serializer;
        private FileStream _stream;

        public SoapSerializer()
        {
            _serializer = new SoapFormatter();
        }

        public void Serialize<T>(string path, T value)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            _stream = new FileStream(path, FileMode.Create);
            _stream.Close();
        }

        public T Deserialize<T>(string path)
        {
            if (!File.Exists(path))
            {
                return default(T);
            }
            _stream = new FileStream(path, FileMode.Open);
            T ret = (T)_serializer.Deserialize(_stream);
            _stream.Close();
            return ret;
        }


        public void Serialize<T>(Stream serialisationStream, T value)
        {
            _serializer.Serialize(serialisationStream, value);
        }

        public T Deserialize<T>(Stream serialisationStream)
        {
            return (T)_serializer.Deserialize(serialisationStream);
        }
    }
}
