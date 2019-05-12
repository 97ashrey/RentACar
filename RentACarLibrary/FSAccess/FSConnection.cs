using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RentACarLibrary.FSAccess
{
    public static class FSConnection
    {

        // create file method
        public static object Create(string path, ISerializable data)
        {
            FileStream stream = File.Open(path, FileMode.CreateNew);
            BinaryFormatter formater = new BinaryFormatter();
            formater.Serialize(stream, data);
            stream.Close();
            return data;
        }

        // delete filemethod
        public static object Delete(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            object obj = Read(path);
            File.Delete(path);
            return obj;
        }

        public static object Read(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            FileStream stream = File.Open(path, FileMode.Open);
            BinaryFormatter formater = new BinaryFormatter();
            object obj = formater.Deserialize(stream);
            stream.Close();
            return obj;
        }

        public static object Update(string path, ISerializable data)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            FileStream stream = File.Open(path, FileMode.Truncate);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
            stream.Close();
            return data;
        }
    }
}
