using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Poc.SerializerModes
{
    public class BinarySerializer : ISerializerMode
    {
        private BinaryFormatter _serializer;
        private FileStream _stream;

        public BinarySerializer()
        {
            _serializer = new BinaryFormatter();
        }

        public void Serialize<T>(string path, T value)
        {
            _stream = new FileStream(path, FileMode.Open);
            _serializer.Serialize(_stream, value);
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
