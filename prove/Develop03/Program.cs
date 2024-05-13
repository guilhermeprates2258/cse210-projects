using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create a new scripture
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his only Son, that whoever believes in him should not perish but have eternal life.");

        // Display the complete scripture
        scripture.Display();

        // Prompt the user to press enter or type quit
        while (true)
        {
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            // Hide a few random words
            scripture.HideRandomWords();

            // Clear the console screen and display the scripture with hidden words
            Console.Clear();
            scripture.Display();
        }
    }
}