using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Poc
{
    public class SerializationManager
    {
        private ISerializerMode _serializerMode;

        public SerializationManager(ISerializerMode mode)
        {

        }

        public void ChangeSerializationType<T>(Type to, Stream serialisationStream)
        {
            if (!(to is ISerializerMode))
            {
                throw new ArgumentException("Param to must be implement ISerializerMode", "to");
            }

            T obj = Deserialize<T>(serialisationStream);
            
            _serializerMode = (ISerializerMode)Activator.CreateInstance(to);
            Serialize<T>(serialisationStream, obj);
        }

        public void Serialize<T>(string path, T value)
        {
            Stream stream = File.Create(path);
            Serialize<T>(stream, value);
            stream.Close();
        }

        public void Serialize<T>(Stream serialisationStream, T value)
        {
            _serializerMode.Serialize<T>(serialisationStream, value);
        }

        public T Deserialize<T>(string path)
        {
            return _serializerMode.Deserialize<T>(File.Open(path, FileMode.Open, FileAccess.Read));
        }

        public T Deserialize<T>(Stream serialisationStream)
        {
            return _serializerMode.Deserialize<T>(serialisationStream);
        }
    }
}
