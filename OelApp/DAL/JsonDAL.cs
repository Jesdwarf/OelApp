using System;
using System.IO;
using Newtonsoft.Json;

namespace OelApp
{
    public static class JsonDAL
    {
        private static string filePath = "";

        public static void WriteToJsonFile<T>(T objectToWrite, bool append = false) where T : new()
        {
            filePath =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Oelapp.json");
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static T ReadFromJsonFile<T>() where T : new()
        {
            filePath =
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Oelapp.json");
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}