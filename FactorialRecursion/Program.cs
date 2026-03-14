using System;

class Program
{
    // Recursive function to calculate factorial
    // n! = n * (n-1)! with base case 0! = 1
    static int Factorial(int n)
    {
        // Base case: factorial of 0 or 1 is 1
        if (n == 0 || n == 1)
        {
            return 1;
        }

        // Recursive call: n! = n * (n-1)!
        return n * Factorial(n - 1);
    }

    static void Main()
    {
        Console.WriteLine("Enter a number to calculate factorial:");
        int num;

        // Read input from user and convert to integer
        while (!int.TryParse(Console.ReadLine(), out num) || num < 0)
        {
            Console.WriteLine("Invalid input. Please enter a non-negative integer:");
        }

        // Call recursive factorial function
        int result = Factorial(num);

        // Display the result
        Console.WriteLine($"Factorial of {num} is: {result}");
    }
}

