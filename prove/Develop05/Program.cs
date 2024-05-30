using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

abstract class Goal
{
    public string Description { get; set; }
    public int Points { get; protected set; }
    public abstract void RecordEvent();
    public abstract bool IsCompleted();
}

class SimpleGoal : Goal
{
    private bool completed = false;
    public SimpleGoal(string description, int points)
    {
        Description = description;
        Points = points;
    }
    public override void RecordEvent()
    {
        completed = true;
    }
    public override bool IsCompleted()
    {
        return completed;
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string description, int points)
    {
        Description = description;
        Points = points;
    }
    public override void RecordEvent()
    {
        // Eternal goals are never "completed", but each event gives points
    }
    public override bool IsCompleted()
    {
        return false;
    }
}

class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount = 0;
    private int bonusPoints;
    public ChecklistGoal(string description, int points, int targetCount, int bonusPoints)
    {
        Description = description;
        Points = points;
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
    }
    public override void RecordEvent()
    {
        currentCount++;
    }
    public override bool IsCompleted()
    {
        return currentCount >= targetCount;
    }
    public int CurrentCount => currentCount;
    public int TargetCount => targetCount;
    public int BonusPoints => bonusPoints;
}
class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int score = 0;

    static void Main(string[] args)
    {
        LoadGoals();
        string command;
        do
        {
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save and Exit");
            Console.Write("Enter your choice: ");
            command = Console.ReadLine();
            switch (command)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    ShowScore();
                    break;
                case "5":
                    SaveGoals();
                    Console.WriteLine("Goals saved. Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        } while (command != "5");
    }

    private static void CreateNewGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select the type of goal: ");
        string goalType = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                goals.Add(new SimpleGoal(description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(description, points));
                break;
            case "3":
                Console.Write("Enter target count: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(description, points, targetCount, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid goal type. Goal not created.");
                break;
        }
    }

    private static void RecordEvent()
    {
        ShowGoals();
        Console.Write("Enter the number of the goal to record: ");
        int goalNumber = int.Parse(Console.ReadLine());
        if (goalNumber >= 1 && goalNumber <= goals.Count)
        {
            Goal goal = goals[goalNumber - 1];
            goal.RecordEvent();
            score += goal.Points;
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted())
            {
                score += checklistGoal.BonusPoints;
            }
            Console.WriteLine("Event recorded.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private static void ShowGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            string status = goal.IsCompleted() ? "[X]" : "[ ]";
            if (goal is ChecklistGoal checklistGoal)
            {
                status += $" Completed {checklistGoal.CurrentCount}/{checklistGoal.TargetCount} times";
            }
            Console.WriteLine($"{i + 1}. {status} {goal.Description} ({goal.Points} points)");
        }
    }

    private static void ShowScore()
    {
        Console.WriteLine($"Current score: {score}");
    }

    private static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(score);
            foreach (Goal goal in goals)
            {
                string type = goal.GetType().Name;
                string line = $"{type},{goal.Description},{goal.Points}";
                if (goal is ChecklistGoal checklistGoal)
                {
                    line += $",{checklistGoal.TargetCount},{checklistGoal.CurrentCount},{checklistGoal.BonusPoints}";
                }
                writer.WriteLine(line);
            }
        }
    }

    private static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                score = int.Parse(reader.ReadLine());
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string type = parts[0];
                    string description = parts[1];
                    int points = int.Parse(parts[2]);

                    switch (type)
                    {
                        case "SimpleGoal":
                            goals.Add(new SimpleGoal(description, points));
                            break;
                        case "EternalGoal":
                            goals.Add(new EternalGoal(description, points));
                            break;
                        case "ChecklistGoal":
                            int targetCount = int.Parse(parts[3]);
                            int currentCount = int.Parse(parts[4]);
                            int bonusPoints = int.Parse(parts[5]);
                            ChecklistGoal checklistGoal = new ChecklistGoal(description, points, targetCount, bonusPoints)
                            {
                                // We need a way to set the current count directly (not available in the original class design)
                            };
                            for (int i = 0; i < currentCount; i++)
                            {
                                checklistGoal.RecordEvent();
                            }
                            goals.Add(checklistGoal);
                            break;
                    }
                }
            }
        }
    }
}
1