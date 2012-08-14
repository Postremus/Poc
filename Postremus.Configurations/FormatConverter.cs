using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Poc
{
    public class FormatConverter
    {
        public FormatConverter()
        {
        }

        /// <summary>
        /// Konvertiert die angegebene Datei von dem 'fromSerializer' Format in das 'toSerializer' Format
        /// </summary>
        /// <param name="path"></param>
        /// <param name="fromSerializer"></param>
        /// <param name="toSerializer"></param>
        public void Convert(string path, ISerializer fromSerializer, ISerializer toSerializer)
        {
            if (!File.Exists(path)) new FileNotFoundException("path");
            object o = fromSerializer.Deserialize<object>(path);
            toSerializer.Serialize<object>(path, o);
        }
    }
}
