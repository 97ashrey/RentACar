using System;
using System.Collections.Generic;
using System.IO;

namespace RentACarLibrary.DataAccess.FileConnection
{
    public static class ModelConnectionHelpers
    {
        public static string GetFullPathByPattern(string directory, string pattern)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            if (!dirInfo.Exists)
            {
                return null;
            }
            FileInfo[] fileInfos = dirInfo.GetFiles(pattern);
            if (fileInfos.Length == 0)
            {
                return null;
            }
            return fileInfos[0].FullName;
        }

        public static string GetFullPath(string directory, string fileName)
        {
            return $"{directory}\\{fileName}";
        }

        public static string[] GetDirectoryFiles(string directory)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            if (!dirInfo.Exists)
            {
                return null;
            }
            FileInfo[] fileInfos = dirInfo.GetFiles();
            string[] paths = new string[fileInfos.Length];
            for(int i=0; i<paths.Length; i++)
            {
                paths[i] = fileInfos[i].FullName;
            }

            return paths;
        }

        public static T[] Filter<T>(T[] array, Func<T, bool> expression)
        {
            List<T> output = new List<T>();
            foreach(T item in array)
            {
                if (expression(item))
                    output.Add(item);
            }

            return output.ToArray();
        }

    }
}
