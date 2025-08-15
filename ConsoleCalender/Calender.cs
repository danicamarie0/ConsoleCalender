namespace ConsoleCalender
{
    public class Calendar
    {
        private NoteEntry[] entries = new NoteEntry[10];     
        private int count = 0;

        public bool AddEntry(DateOnly date, string note)
        {
            for (int i = 0; i < count; i++)
            {
                if (entries[i].Date == date) return false;
            }

            if (count == entries.Length)
            {
                ResizeArray();
            }

            entries[count++] = new NoteEntry(date, note);
            return true;
        }

        private void ResizeArray()
        {
            int newSize = entries.Length * 2;
            NoteEntry[] newArray = new NoteEntry[newSize];
            for (int i = 0; i < entries.Length; i++)
            {
                newArray[i] = entries[i];
            }
            entries = newArray;
        }

        public bool EditEntry(int index, string newNote)
        {
            if (index < 0 || index >= count) return false;
            entries[index].Note = newNote;
            return true;
        }

        public bool DeleteEntry(int index)
        {
            if (index < 0 || index >= count) return false;

            for (int i = index; i < count - 1; i++)
            {
                entries[i] = entries[i + 1];
            }

            entries[--count] = null;
            return true;
        }

        public NoteEntry[] GetAllEntries()
        {
            NoteEntry[] result = new NoteEntry[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = entries[i];
            }
            return result;
        }

        public int Count => count;
    }
}