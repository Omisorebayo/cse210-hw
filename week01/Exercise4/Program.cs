using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();
        int question = -1;

        while (question != 0)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            question = int.Parse(input);

            if (question != 0)
            {
                numbers.Add(question);
            }
        }

        if (numbers.Count > 0)
        {
            // Calculate the sum
            int total = 0;
            foreach (int number in numbers)
            {
                total += number;
            }

            Console.WriteLine($"The sum of the numbers is: {total}");

            // Calculate the average
            double average = (double)total / numbers.Count;
            Console.WriteLine($"The average is: {average:F3}");

            // Find the largest number
            int largest = numbers[0];
            foreach (int number in numbers)
            {
                if (number > largest)
                {
                    largest = number;
                }
            }

            Console.WriteLine($"The largest number is: {largest}");

            // Sort and display the list
            numbers.Sort();

            Console.WriteLine("The sorted list is:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}