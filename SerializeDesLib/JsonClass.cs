using Newtonsoft.Json;

namespace SerializeDesLib
{
    public class JsonClass<T>
    {
        public static void Serialize<T>(T data, string fileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(desktop + "\\" + fileName, json);
        }
        public static T Deserialize<T>(string fileName)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(desktop + "\\" + fileName);
            T data = JsonConvert.DeserializeObject<T>(json);
            return data;
        }
    }
}
