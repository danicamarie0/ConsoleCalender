namespace ConsoleCalender
{
    public class Calendar
    {
        private List<NoteEntry> entries = CSVData.GetAll();
        public void AddEntry(DateOnly date, string note)
        {
            entries.Add(new NoteEntry(date, note));
            CSVData.Overwrite(entries);
        }

        public bool EditEntry(int index, string newNote)
        {
            if (index < 0 || index >= entries.Count) return false;

            entries[index].Note = newNote;
            CSVData.Overwrite(entries);
            return true;
        }

        public bool DeleteEntry(int index)
        {
            if (index < 0 || index >= entries.Count) return false;

            entries.RemoveAt(index);
            CSVData.Overwrite(entries);
            return true;
        }

        public List<NoteEntry> GetAllEntries()
        {
            return entries;
        }

        public int Count => entries.Count;
    }
}
