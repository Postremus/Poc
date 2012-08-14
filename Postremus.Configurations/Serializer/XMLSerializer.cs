using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Poc.Serializer
{
    public class XMLSerializer : ISerializer
    {
        XmlSerializer _serializer;
        FileStream _stream;

        public XMLSerializer()
        {
        }

        public void Serialize<T>(string path, T value)
        {
            _serializer = new XmlSerializer(typeof(T));
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
            _serializer = new XmlSerializer(typeof(T));
            _stream = new FileStream(path, FileMode.Open);
            T ret = (T)_serializer.Deserialize(_stream);
            _stream.Close();
            return ret;
        }

        public void Serialize<T>(Stream serialisationStream, T value)
        {
            _serializer = new XmlSerializer(typeof(T));
            _serializer.Serialize(serialisationStream, value);
        }

        public T Deserialize<T>(Stream serialisationStream)
        {
            _serializer = new XmlSerializer(typeof(T));
            return (T)_serializer.Deserialize(serialisationStream);
        }
    }
}
