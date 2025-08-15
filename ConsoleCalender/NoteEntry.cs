using System.Globalization;

namespace ConsoleCalender
{
    public class NoteEntry
    {
        public DateOnly Date { get; set; }
        public string Note { get; set; }

        public NoteEntry(DateOnly date, string note)
        {
            Date = date;
            Note = note;
        }

        public override string ToString()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            string parseFormat = culture.DateTimeFormat.ShortDatePattern;
            return $"{Date.ToString(parseFormat, culture)} - {Note}";
        }
    }
}