public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void WriteNewEntry()
    {
        Random rnd = new Random();
        string prompt = prompts[rnd.Next(prompts.Count)];
        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();
        Entry newEntry = new Entry(prompt, response, DateTime.Now.ToString());
        entries.Add(newEntry);
        Console.WriteLine("Entry added successfully.");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}");
        }
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter the filename to save the journal to: ");
        string fileName = Console.ReadLine();
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved to file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal to file: {ex.Message}");
        }
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter the filename to load the journal from: ");
        string fileName = Console.ReadLine();
        try
        {
            entries.Clear(); // Clear existing entries before loading from file
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        Entry loadedEntry = new Entry(parts[0], parts[1], parts[2]);
                        entries.Add(loadedEntry);
                    }
                }
            }
            Console.WriteLine("Journal loaded from file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal from file: {ex.Message}");
        }
    }
}