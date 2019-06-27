using System;
using System.Collections.Generic;
using RentACarLibrary.Models;
using RentACarLibrary.FSAccess;

namespace RentACarLibrary.DataAccess.FileConnection
{
    public class DataConnection<T> : IDataConnection<T> where T: IDataModel
    {
        private string dataDirectory;

        public DataConnection(string dataDirectory)
        {
            this.dataDirectory = dataDirectory;
        }

        public T Create(T data)
        {
            T[] models = GetAll();
            int maxID = 0;
            if (models != null)
            {
                foreach (T model in models)
                {
                    if (maxID < model.ID)
                    {
                        maxID = model.ID;
                    }
                }
            }
            data.ID = maxID + 1;
            string fullPath = $"{dataDirectory}//{data.ID}.bin";

            return (T)FSConnection.Create(fullPath, data);
        }

        public T Delete(int id)
        {
            string fullPath = GetFullPath(id);
            return (T)FSConnection.Delete(fullPath) ;
        }

        public T[] Filter(Func<T, bool> expression)
        {
            List<T> output = new List<T>();
            T[] models = GetAll();
            foreach (T model in models)
            {
                if (expression(model))
                {
                    output.Add(model);
                }
            }
            return output.ToArray();
        }

        public T Get(int id)
        {
            string fullPath = GetFullPath(id);
            return (T)FSConnection.Read(fullPath) ;
        }

        public T[] GetAll()
        {
            List<T> models = new List<T>();
            string[] files = ModelConnectionHelpers.GetDirectoryFiles(dataDirectory);
            if (files == null)
            {
                return models.ToArray();
            }
            
            foreach(string file in files)
            {
                models.Add((T)FSConnection.Read(file));
            }

            return models.ToArray();
        }

        public T Update(T data)
        {
            string fullPath = GetFullPath(data.ID);
            return (T)FSConnection.Update(fullPath, data) ;
        }

        private string GetFullPath(int id)
        {
            string fullPath = $"{dataDirectory}//{id}.bin";
            return fullPath;
        }
    }
}
