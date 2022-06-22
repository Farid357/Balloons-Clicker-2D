using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Clicker.SaveSystem
{
    public sealed class BinaryStorage : IStorage, IDeletable
    {
        private readonly BinaryFormatter _formatter;

        public BinaryStorage() => _formatter = new BinaryFormatter();

        public void Delete(string path)
        {
            var allPath = Path.Combine(Application.persistentDataPath, path);
            if (Exists(allPath))
            {
                File.Delete(allPath);
            }
        }

        public T Load<T>(string path, T loadObject)
        {
            var allPath = Path.Combine(Application.persistentDataPath, path);
            if (Exists(allPath))
            {
                using FileStream file = File.Open(allPath, FileMode.Open);
                loadObject = (T)_formatter.Deserialize(file);
            }
            return loadObject;
        }

        public bool Exists(string path)
        {
            var allPath = Path.Combine(Application.persistentDataPath, path);
            return File.Exists(allPath);
        }

        public void Save<T>(string path, T saveObject)
        {
            var allPath = Path.Combine(Application.persistentDataPath, path);
            using var file = File.Create(allPath);
            _formatter.Serialize(file, saveObject);
        }
    }
}
