namespace ConsoleCalender
{
    public class Calendar
    {
        private List<NoteEntry> entries = JSONData.GetAll();
        public void AddEntry(DateTime date, string note)
        {
            entries.Add(new NoteEntry(date, note));
            JSONData.Overwrite(entries);
        }

        public bool EditEntry(int index, string newNote)
        {
            if (index < 0 || index >= entries.Count) return false;

            entries[index].Note = newNote;
            JSONData.Overwrite(entries);
            return true;
        }

        public bool DeleteEntry(int index)
        {
            if (index < 0 || index >= entries.Count) return false;

            entries.RemoveAt(index);
            JSONData.Overwrite(entries);
            return true;
        }

        public List<NoteEntry> GetAllEntries()
        {
            return entries;
        }

        public int Count => entries.Count;
    }
}
