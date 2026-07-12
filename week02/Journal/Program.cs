
// Creativity:
// I exceeded the core requirements by adding a Mood field to each journal entry.
// Users can record how they were feeling when writing each journal entry.
// The mood is displayed and saved to the file along with the date, prompt, and response.



using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("How are you feeling today? ");
                    string mood = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._date = DateTime.Now.ToShortDateString();
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;
                    newEntry._mood = mood;

                    journal.AddEntry(newEntry);

                    Console.WriteLine("Journal entry added!");
                    break;
                case 2:
                    Console.WriteLine();
                    journal.DisplayAll();
                    break;

                case 3:
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();

                    journal.SaveToFile(saveFile);

                    Console.WriteLine("Journal saved successfully!");
                    break;

                case 4:
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();

                    journal.LoadFromFile(loadFile);

                    Console.WriteLine("Journal loaded successfully!");
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}