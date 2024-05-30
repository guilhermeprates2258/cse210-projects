using System;
using System.Threading;

public abstract class Activity
{
    protected string name;
    protected string description;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public abstract void StartActivity(int duration);

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Pausing for {i} seconds...");
            Thread.Sleep(1000);
        }
    }

    protected void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void StartActivity(int duration)
    {
        Console.WriteLine($"Starting {name}...");
        Console.WriteLine(description);
        Console.WriteLine($"Setting duration to {duration} seconds.");
        Pause(3); // Pause for 3 seconds

        Console.WriteLine("Prepare to begin...");
        Pause(3); // Pause for 3 seconds

        Console.WriteLine("Breathe in...");
        DisplaySpinner(duration);

        Console.WriteLine($"{name} activity completed.");
        Console.WriteLine("Good job!");
        Pause(3); // Pause for 3 seconds
    }
}

public class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void StartActivity(int duration)
    {
        Console.WriteLine($"Starting {name}...");
        Console.WriteLine(description);
        Console.WriteLine($"Setting duration to {duration} seconds.");
        Pause(3); // Pause for 3 seconds

        Console.WriteLine("Prepare to begin...");
        Pause(3); // Pause for 3 seconds

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            DisplaySpinner(3);
        }

        Console.WriteLine($"{name} activity completed.");
        Console.WriteLine("Good job!");
        Pause(3); // Pause for 3 seconds
    }
}

public class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void StartActivity(int duration)
    {
        Console.WriteLine($"Starting {name}...");
        Console.WriteLine(description);
        Console.WriteLine($"Setting duration to {duration} seconds.");
        Pause(3); // Pause for 3 seconds

        Console.WriteLine("Prepare to begin...");
        Pause(3); // Pause for 3 seconds

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);

        Console.WriteLine("Start listing items...");

        // Simulate user input by waiting for duration seconds
        Thread.Sleep(duration * 1000);

        Console.WriteLine("Activity completed.");
        Console.WriteLine("Good job!");
        Pause(3); // Pause for 3 seconds
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Mindfulness App!");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity (1-4): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter duration (in seconds): ");
                    int breathingDuration = int.Parse(Console.ReadLine());
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.StartActivity(breathingDuration);
                    break;
                case "2":
                    Console.Write("Enter duration (in seconds): ");
                    int reflectionDuration = int.Parse(Console.ReadLine());
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.StartActivity(reflectionDuration);
                    break;
                case "3":
                    Console.Write("Enter duration (in seconds): ");
                    int listingDuration = int.Parse(Console.ReadLine());
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.StartActivity(listingDuration);
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }
}
