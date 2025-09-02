using System.Text.Json;

namespace ConsoleCalender
{
    internal class JSONData
    {
        private static readonly string filePath = "note.json";

        public static List<NoteEntry> GetAll()
        {
            if (!File.Exists(filePath)) return new List<NoteEntry>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<NoteEntry>>(json) ?? new List<NoteEntry>();
        }

        public static void Overwrite(List<NoteEntry> entries)
        {
            var json = JsonSerializer.Serialize(entries, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }
    }
}

