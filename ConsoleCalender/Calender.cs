    namespace ConsoleCalender
    {
        public class Calendar
        {
            private List<NoteEntry> entries = new();

            public void AddEntry(DateOnly date, string note)
            {
                entries.Add(new NoteEntry(date, note));
        }
            public bool EditEntry(int index, string newNote)
            {
                if (index < 0 || index >= entries.Count) return false;

                entries[index].Note = newNote;
                return true;
            }
            public bool DeleteEntry(int index)
            {
                if (index < 0 || index >= entries.Count) return false;

                entries.RemoveAt(index);
                return true;
            }

            public List<NoteEntry> GetAllEntries()
            {
                return entries;
            }

            public int Count => entries.Count;
        }
    }
