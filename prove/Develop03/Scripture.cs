class Scripture
{
    private string reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"Reference: {reference}");
        foreach (Word word in words)
        {
            if (word.IsHidden)
                Console.Write("***** ");
            else
                Console.Write($"{word.Text} ");
        }
    }

    public void HideRandomWords()
    {
        Random rnd = new Random();
        foreach (Word word in words)
        {
            if (rnd.Next(2) == 0) // Hide approximately half of the words
                word.Hide();
        }
    }
}