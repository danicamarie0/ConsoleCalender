using System.Globalization;

namespace ConsoleCalender
{

    internal class Program
    {
        static readonly Calendar calendar = new();

        static void Main(string[] args)
        {
            var entries = CSVData.GetAll();

            Console.WriteLine();
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to your digital Calendar!");
                Console.WriteLine("1. Add Note");

                if (calendar.Count > 0)
                {
                    Console.WriteLine("2. Edit Note");
                    Console.WriteLine("3. Delete Note");
                    Console.WriteLine("4. View All Notes");
                }

                Console.WriteLine("5. Exit");
                Console.Write("Pick your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNote();
                        break;
                    case "2":
                        if (calendar.Count > 0) EditNote();
                        else ShowUnavailable("Edit");
                        break;
                    case "3":
                        if (calendar.Count > 0) DeleteNote();
                        else ShowUnavailable("Delete");
                        break;
                    case "4":
                        if (calendar.Count > 0) ViewNotes();
                        else ShowUnavailable("View");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Pause();
                        break;
                }
            }
        }

        static void AddNote()
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            string parseFormat = culture.DateTimeFormat.ShortDatePattern;

            Console.WriteLine($"Enter date in format ({parseFormat}):");
            string input = Console.ReadLine();

            if (DateOnly.TryParseExact(input, parseFormat, culture, DateTimeStyles.None, out DateOnly parsedDate))
            {
                Console.Write("Enter note: ");
                string note = Console.ReadLine();

                calendar.AddEntry(parsedDate, note);
                Console.WriteLine("Note successfully added.");
            }

            else
            {
                Console.WriteLine("Invalid date format.");
            }

            Pause();
        }

        static void EditNote()
        {
            var entries = calendar.GetAllEntries();
            Console.WriteLine("Choose a note to edit:");
            for (int i = 0; i < entries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {entries[i]}");
            }

            Console.Write("Enter the number of the note to edit: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= entries.Count)
            {
                string newNote = PromptForNote();
                if (calendar.EditEntry(choice - 1, newNote))
                {
                    Console.WriteLine("Note updated.");
                }
            }
            else
            {
                Console.WriteLine("There's no note available with that number");
            }

            Pause();
        }

        static void DeleteNote()
        {
            var entries = calendar.GetAllEntries();
            Console.WriteLine("Choose a note to delete:");
            for (int i = 0; i < entries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {entries[i]}");
            }

            Console.Write("Enter the number of the note to delete: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && calendar.DeleteEntry(choice - 1))
                Console.WriteLine("Note deleted.");
            else
                Console.WriteLine("Invalid selection.");

            Pause();
        }

        static void ViewNotes()
        {
            Console.WriteLine("=== Calendar Notes ===");
            foreach (var entry in calendar.GetAllEntries())
            {
                Console.WriteLine(entry.ToString());
            }

            Pause();
        }

        static string PromptForNote()
        {
            Console.Write("Enter new note: ");
            return Console.ReadLine();
        }

        static void ShowUnavailable(string action)
        {
            Console.WriteLine($"This is not a valid option. Cannot {action}.");
            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}