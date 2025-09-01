namespace ConsoleCalender
{
    internal class CSVData
    {
        private static readonly string filePath = "note.csv";

        public static List<NoteEntry> GetAll()
        {
            var entries = new List<NoteEntry>();
            if (!File.Exists(filePath)) return entries;
            //check if a file exist 
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',', 2); //method to break string
                if (parts.Length == 2 && DateOnly.TryParse(parts[0], out var date))
                {
                    entries.Add(new NoteEntry(date, parts[1]));
                }
            }
            return entries;
        }

        public static void Overwrite(List<NoteEntry> entries)
        {
            var outLines = new List<string>
              {
                "Date,Note"
              };

            foreach (var entry in entries)
            {
                outLines.Add($"{entry.Date:yyyy-MM-dd},{entry.Note}");
            }

            File.WriteAllLines(filePath, outLines);
        }


    }
}
