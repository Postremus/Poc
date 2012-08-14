using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poc
{
    [Serializable()]
    public class Config
    {
        private ISerializer _serializer;
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

        public Config(string path, ISerializer serializer)
        {
            _dic = new Dictionary<string, object>();
            _path = path;
            _serializer = serializer;
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
            _serializer.Serialize(this._path, this);
        }

        public Config DeSerialize()
        {
            return _serializer.Deserialize<Config>(this._path);
        }
    }
}