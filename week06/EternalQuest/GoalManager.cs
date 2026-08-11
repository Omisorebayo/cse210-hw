
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();

            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoalDetails();
                    break;

                case "3":
                    RecordEvent();
                    break;

                case "4":
                    SaveGoals();
                    break;

                case "5":
                    LoadGoals();
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    break;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Thank you for using Eternal Quest!");
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("          ETERNAL QUEST");
        Console.WriteLine("======================================");

        Console.WriteLine($"Score: {_score}");

        int level = GetLevel();

        Console.WriteLine($"Level: {level}");
        Console.WriteLine($"Rank: {GetRank()}");
    }

    private int GetLevel()
    {
        return (_score / 500) + 1;
    }

    private string GetRank()
    {
        int level = GetLevel();

        if (level >= 10)
        {
            return "Eternal Champion";
        }
        else if (level >= 7)
        {
            return "Quest Master";
        }
        else if (level >= 5)
        {
            return "Faithful Adventurer";
        }
        else if (level >= 3)
        {
            return "Growing Disciple";
        }
        else
        {
            return "Quest Beginner";
        }
    }

    private void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    private void ListGoalDetails()
    {
        Console.Clear();

        Console.WriteLine("Your Goals:");
        Console.WriteLine();

        if (_goals.Count == 0)
        {
            Console.WriteLine("You currently have no goals.");
        }
        else
        {
            foreach (Goal goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }

        Pause();
    }

    private void CreateGoal()
    {
        Console.Clear();

        Console.WriteLine("Create New Goal");
        Console.WriteLine();
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of your goal? ");
        string description = Console.ReadLine();

        int points = GetIntegerInput("How many points is this goal worth? ");

        switch (choice)
        {
            case "1":
                SimpleGoal simpleGoal =
                    new SimpleGoal(name, description, points);

                _goals.Add(simpleGoal);

                Console.WriteLine();
                Console.WriteLine("Simple goal created!");
                break;

            case "2":
                EternalGoal eternalGoal =
                    new EternalGoal(name, description, points);

                _goals.Add(eternalGoal);

                Console.WriteLine();
                Console.WriteLine("Eternal goal created!");
                break;

            case "3":
                int target =
                    GetIntegerInput("How many times must you complete this goal? ");

                int bonus =
                    GetIntegerInput("How many bonus points will you receive? ");

                ChecklistGoal checklistGoal =
                    new ChecklistGoal(
                        name,
                        description,
                        points,
                        target,
                        bonus);

                _goals.Add(checklistGoal);

                Console.WriteLine();
                Console.WriteLine("Checklist goal created!");
                break;

            default:
                Console.WriteLine();
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Pause();
    }

    private void RecordEvent()
    {
        Console.Clear();

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record.");
            Pause();
            return;
        }

        Console.WriteLine("The Goals Are:");

        Console.WriteLine();

        ListGoalNames();

        Console.WriteLine();

        int choice =
            GetIntegerInput("Which goal did you accomplish? ");

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("That is not a valid goal.");
            Pause();
            return;
        }

        Goal selectedGoal = _goals[choice - 1];

        int oldLevel = GetLevel();

        int pointsEarned = selectedGoal.RecordEvent();

        _score += pointsEarned;

        Console.WriteLine();
        Console.WriteLine($"Congratulations!");
        Console.WriteLine($"You earned {pointsEarned} points.");
        Console.WriteLine($"Your new score is {_score}.");

        int newLevel = GetLevel();

        if (newLevel > oldLevel)
        {
            Console.WriteLine();
            Console.WriteLine("**************************************");
            Console.WriteLine($"       LEVEL UP! You are now Level {newLevel}!");
            Console.WriteLine($"       Rank: {GetRank()}");
            Console.WriteLine("**************************************");
        }

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine();
            Console.WriteLine("Goal completed! Great work!");
        }

        Pause();
    }

    private void SaveGoals()
    {
        Console.Clear();

        Console.Write("Enter the filename to save your goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine();
        Console.WriteLine("Goals saved successfully!");

        Pause();
    }

    private void LoadGoals()
    {
        Console.Clear();

        Console.Write("Enter the filename to load your goals: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine();
            Console.WriteLine("File not found.");
            Pause();
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            Pause();
            return;
        }

        _goals.Clear();

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(lines[i]))
            {
                Goal goal = CreateGoalFromString(lines[i]);

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("Goals loaded successfully!");

        Pause();
    }

    private Goal CreateGoalFromString(string line)
    {
        string[] parts = line.Split('|');

        string type = parts[0];

        if (type == "SimpleGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool isComplete = bool.Parse(parts[4]);

            return new SimpleGoal(
                name,
                description,
                points,
                isComplete);
        }

        if (type == "EternalGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            return new EternalGoal(
                name,
                description,
                points);
        }

        if (type == "ChecklistGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            int amountCompleted = int.Parse(parts[4]);
            int target = int.Parse(parts[5]);
            int bonus = int.Parse(parts[6]);

            return new ChecklistGoal(
                name,
                description,
                points,
                amountCompleted,
                target,
                bonus);
        }

        return null;
    }

    private int GetIntegerInput(string message)
    {
        int number;

        Console.Write(message);

        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Please enter a valid number: ");
        }

        return number;
    }

    private void Pause()
    {
        Console.WriteLine();
        Console.Write("Press ENTER to continue...");
        Console.ReadLine();
    }
}