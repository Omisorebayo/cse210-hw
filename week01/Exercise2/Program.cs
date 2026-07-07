using System;
using System.IO.Pipelines;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";

        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }


        // Determine the sign based on the last digit of the grade percentage


        string sign = "";
        int readResult;

        readResult = gradePercentage % 10;
        if (readResult >= 7)
        {
            sign = "+";
        }
        else if (readResult < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        //grade exception
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        if (letter == "F")
        {
            sign = "";
        }


        Console.WriteLine($"Your letter grade is {letter}{sign}.");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the class. Better luck next time!");
        }
    }
}