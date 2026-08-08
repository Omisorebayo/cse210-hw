using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity:
        // I exceeded the core requirements by preventing reflection
        // questions from being repeated until all available questions
        // have been used during the activity session. This gives the
        // user more variety and encourages deeper reflection.

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity =
                    new BreathingActivity();

                activity.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity activity =
                    new ReflectingActivity();

                activity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity activity =
                    new ListingActivity();

                activity.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Thank you for using the Mindfulness Program."
                );

                break;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Invalid choice. Please select 1, 2, 3, or 4."
                );

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}