using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poc
{
    [Serializable()]
    public class Config
    {
        private SerializationManager _seriManager;
        private string _path;
        private Dictionary<string, object> _dic;

        public string Path
        {
            get
            {
                return _path;
            }
        }

        public Dictionary<string, object> Dic
        {
            get
            {
                return _dic;
            }
        }

        public Config(string path, ISerializerMode serializer)
        {
            _dic = new Dictionary<string, object>();
            _path = path;
            _seriManager = new SerializationManager(serializer);
        }

        public T GetValue<T>(string key)
        {
            if (_dic.Count == 0) return default(T);
            return (T)Dic[key];
        }

        public void SetValue<T>(string key, T value)
        {
            if (key == null || value == null) return;
            Dic[key] = value;
        }

        public void Serialize()
        {
            _seriManager.Serialize(this._path, this);
        }

        public Config DeSerialize()
        {
            return _seriManager.Deserialize<Config>(this._path);
        }
    }
}