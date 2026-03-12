using System;

namespace RecursiveFunctionsDemo
{
    
    // PROGRAM: Recursive Functions in Data Structures
    // DESCRIPTION: This program demonstrates recursive functions with multiple
    //              examples including factorial, Fibonacci, and other classic
    //              recursive algorithms


    class Program
    {
       
        // METHOD 1: Factorial using Recursion (Basic Example)
        // PURPOSE: Calculates the factorial of a number using recursion
        // FORMULA: n! = n * (n-1) * (n-2) * ... * 1
        // BASE CASE: 0! = 1, 1! = 1
        // RECURSIVE CASE: n! = n * (n-1)!
       
        static long CalculateFactorial(int n)
        {
            // Input validation - check for negative numbers
            if (n < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers!");
            }

            // BASE CASE: When n is 0 or 1, return 1
            // This is the stopping condition that prevents infinite recursion
            if (n == 0 || n == 1)
            {
                Console.WriteLine($"   Base case reached: factorial({n}) = 1");
                return 1;
            }

            // RECURSIVE CASE: n! = n * (n-1)!
            // The function calls itself with a smaller value (n-1)
            Console.WriteLine($"   Calculating: {n}! = {n} * factorial({n - 1})");
            
            // Recursive call: function calls itself with (n-1)
            long result = n * CalculateFactorial(n - 1);
            
            Console.WriteLine($"   Returning: factorial({n}) = {result}");
            return result;
        }

       
        // METHOD 2: Factorial with Detailed Step Tracking
        // PURPOSE: Shows each step of recursion with indentation for better visualization
                static long CalculateFactorialWithSteps(int n, string indent = "")
        {
            if (n < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers!");
            }

            Console.WriteLine($"{indent}Entering factorial({n})");

            if (n == 0 || n == 1)
            {
                Console.WriteLine($"{indent}Base case: factorial({n}) = 1");
                Console.WriteLine($"{indent}Exiting factorial({n}) -> 1");
                return 1;
            }

            Console.WriteLine($"{indent}Calling factorial({n - 1})");
            
            // Recursive call with increased indentation
            long result = n * CalculateFactorialWithSteps(n - 1, indent + "  ");
            
            Console.WriteLine($"{indent}Result: {n} * factorial({n - 1}) = {result}");
            Console.WriteLine($"{indent}Exiting factorial({n}) -> {result}");
            
            return result;
        }

        
        // METHOD 3: Iterative Factorial (for comparison)
        // PURPOSE: Demonstrates the iterative approach vs recursive approach

        static long CalculateFactorialIterative(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers!");
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

       
        // METHOD 4: Fibonacci Sequence using Recursion
        // PURPOSE: Additional example of recursion - calculates Fibonacci numbers
        // FORMULA: Fib(n) = Fib(n-1) + Fib(n-2)
        // BASE CASE: Fib(0) = 0, Fib(1) = 1
       
        static long CalculateFibonacci(int n)
        {
            // Input validation
            if (n < 0)
            {
                throw new ArgumentException("Fibonacci is not defined for negative numbers!");
            }

            // Base cases
            if (n == 0) return 0;
            if (n == 1) return 1;

            // Recursive case
            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }

       
        // METHOD 5: Fibonacci with Memoization (Optimized Recursion)
        // PURPOSE: Demonstrates optimization technique for recursion
        
        static long CalculateFibonacciMemoized(int n, long[] memo)
        {
            // Check if already calculated
            if (memo[n] != 0)
            {
                return memo[n];
            }

            // Base cases
            if (n == 0) return 0;
            if (n == 1) return 1;

            // Calculate and store in memo array
            memo[n] = CalculateFibonacciMemoized(n - 1, memo) + 
                     CalculateFibonacciMemoized(n - 2, memo);
            
            return memo[n];
        }

       
        // METHOD 6: Sum of Natural Numbers using Recursion
        // PURPOSE: Another example of recursion - sum of first n natural numbers
       
        static int SumOfNaturalNumbers(int n)
        {
            // Base case
            if (n == 0) return 0;
            
            // Recursive case
            return n + SumOfNaturalNumbers(n - 1);
        }

       
        // METHOD 7: Power Calculation using Recursion (x^n)
        // PURPOSE: Demonstrates recursion for mathematical operations
        
        static double CalculatePower(double baseNum, int exponent)
        {
            // Base cases
            if (exponent == 0) return 1;
            if (exponent == 1) return baseNum;
            
            // Handle negative exponents
            if (exponent < 0)
            {
                return 1 / CalculatePower(baseNum, -exponent);
            }
            
            // Recursive case
            return baseNum * CalculatePower(baseNum, exponent - 1);
        }

       
        // METHOD 8: Display Recursion Tree for Factorial
        // PURPOSE: Visualizes the recursion tree for educational purposes
       
        static void DisplayRecursionTree(int n, int level = 0)
        {
            string indent = new string(' ', level * 3);
            
            if (n <= 1)
            {
                Console.WriteLine($"{indent}└─ factorial({n}) = 1 [Base Case]");
                return;
            }
            
            Console.WriteLine($"{indent}└─ factorial({n}) = {n} * factorial({n - 1})");
            DisplayRecursionTree(n - 1, level + 1);
        }

        
        // MAIN METHOD - Program Entry Point
        
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine("     RECURSIVE FUNCTIONS IN DATA STRUCTURES - DEMONSTRATION     ");
            Console.WriteLine("=================================================================");
            Console.WriteLine();

            
            // EXAMPLE 1: Basic Factorial Calculation
           
            Console.WriteLine("EXAMPLE 1: BASIC FACTORIAL CALCULATION");  // Fixed: Changed println to WriteLine
            Console.WriteLine("----------------------------------------");
            
            int number = 5;
            Console.WriteLine($"Calculating factorial of {number} using recursion:");
            Console.WriteLine();
            
            long result = CalculateFactorial(number);
            
            Console.WriteLine();
            Console.WriteLine($"Final Result: {number}! = {result}");
            Console.WriteLine($"Verification: 5! = 5 × 4 × 3 × 2 × 1 = {result}");
            Console.WriteLine();

            
            // EXAMPLE 2: Factorial with Detailed Step Tracking
           
            Console.WriteLine("EXAMPLE 2: FACTORIAL WITH DETAILED STEP TRACKING");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("This shows the call stack and return values:\n");
            
            long detailedResult = CalculateFactorialWithSteps(4);
            Console.WriteLine($"\nFinal Result: 4! = {detailedResult}");
            Console.WriteLine();

            
            // EXAMPLE 3: Comparison - Recursive vs Iterative
           
            Console.WriteLine("EXAMPLE 3: RECURSIVE VS ITERATIVE APPROACH");
            Console.WriteLine("----------------------------------------");
            
            int testNumber = 10;
            
            // Recursive approach
            DateTime startTime = DateTime.Now;
            long recursiveResult = CalculateFactorial(testNumber);
            TimeSpan recursiveTime = DateTime.Now - startTime;
            
            // Iterative approach
            startTime = DateTime.Now;
            long iterativeResult = CalculateFactorialIterative(testNumber);
            TimeSpan iterativeTime = DateTime.Now - startTime;
            
            Console.WriteLine($"Number: {testNumber}!");
            Console.WriteLine($"Recursive Result: {recursiveResult}, Time: {recursiveTime.TotalMilliseconds} ms");
            Console.WriteLine($"Iterative Result: {iterativeResult}, Time: {iterativeTime.TotalMilliseconds} ms");
            Console.WriteLine();

            
            // EXAMPLE 4: Fibonacci Sequence (Multiple Recursive Calls)
           
            Console.WriteLine("EXAMPLE 4: FIBONACCI SEQUENCE USING RECURSION");
            Console.WriteLine("----------------------------------------");
            
            Console.WriteLine("Fibonacci sequence (first 10 numbers):");
            for (int i = 0; i < 10; i++)
            {
                long fib = CalculateFibonacci(i);
                Console.WriteLine($"Fibonacci({i}) = {fib}");
            }
            Console.WriteLine();

           
            // EXAMPLE 5: Optimized Fibonacci with Memoization
           
            Console.WriteLine("EXAMPLE 5: OPTIMIZED FIBONACCI WITH MEMOIZATION");
            Console.WriteLine("----------------------------------------");
            
            int fibNumber = 40;
            long[] memo = new long[fibNumber + 1];
            
            startTime = DateTime.Now;
            long fibResult = CalculateFibonacciMemoized(fibNumber, memo);
            TimeSpan fibTime = DateTime.Now - startTime;
            
            Console.WriteLine($"Fibonacci({fibNumber}) = {fibResult}");
            Console.WriteLine($"Calculation time with memoization: {fibTime.TotalMilliseconds} ms");
            Console.WriteLine("(Note: Without memoization, this would take much longer!)");
            Console.WriteLine();

            
            // EXAMPLE 6: Sum of Natural Numbers
           
            Console.WriteLine("EXAMPLE 6: SUM OF NATURAL NUMBERS");
            Console.WriteLine("----------------------------------------");
            
            int sumNumber = 10;
            int sum = SumOfNaturalNumbers(sumNumber);
            Console.WriteLine($"Sum of first {sumNumber} natural numbers = {sum}");
            Console.WriteLine($"Verification: 1+2+3+...+{sumNumber} = {(sumNumber * (sumNumber + 1)) / 2}");
            Console.WriteLine();

            
            // EXAMPLE 7: Power Calculation
            
            Console.WriteLine("EXAMPLE 7: POWER CALCULATION USING RECURSION");
            Console.WriteLine("----------------------------------------");
            
            double baseNum = 2;
            int exponent = 8;
            double power = CalculatePower(baseNum, exponent);
            Console.WriteLine($"{baseNum}^{exponent} = {power}");
            
            // Negative exponent example
            exponent = -3;
            power = CalculatePower(baseNum, exponent);
            Console.WriteLine($"{baseNum}^{exponent} = {power}");
            Console.WriteLine();

           
            // EXAMPLE 8: Recursion Tree Visualization
            
            Console.WriteLine("EXAMPLE 8: RECURSION TREE VISUALIZATION");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Visual representation of recursion for 5!:\n");
            DisplayRecursionTree(5);
            Console.WriteLine();

            
            // INTERACTIVE SECTION - User Input
            Console.WriteLine("INTERACTIVE SECTION - TRY IT YOURSELF!");
            Console.WriteLine("----------------------------------------");
            
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Calculate Factorial");
                Console.WriteLine("2. Calculate Fibonacci");
                Console.WriteLine("3. Calculate Sum of Natural Numbers");
                Console.WriteLine("4. Calculate Power");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");

                string? input = Console.ReadLine();  // Fixed: Added nullable annotation
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                if (choice == 5) break;

                switch (choice)
                {
                    case 1: // Factorial
                        Console.Write("Enter a non-negative integer: ");
                        if (int.TryParse(Console.ReadLine(), out int factNum))
                        {
                            try
                            {
                                Console.WriteLine($"\nCalculating {factNum}! using recursion...");
                                Console.WriteLine("Step-by-step execution:");
                                long factResult = CalculateFactorialWithSteps(factNum);
                                Console.WriteLine($"\nResult: {factNum}! = {factResult}");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        }
                        break;

                    case 2: // Fibonacci
                        Console.Write("Enter a non-negative integer: ");
                        if (int.TryParse(Console.ReadLine(), out int fibNum))
                        {
                            try
                            {
                                long[] memoArray = new long[fibNum + 1];
                                long fibResult2 = CalculateFibonacciMemoized(fibNum, memoArray);
                                Console.WriteLine($"Fibonacci({fibNum}) = {fibResult2}");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                        }
                        break;

                    case 3: // Sum of Natural Numbers
                        Console.Write("Enter a non-negative integer: ");
                        if (int.TryParse(Console.ReadLine(), out int sumNum))
                        {
                            int sumResult = SumOfNaturalNumbers(sumNum);
                            Console.WriteLine($"Sum of first {sumNum} natural numbers = {sumResult}");
                        }
                        break;

                    case 4: // Power
                        Console.Write("Enter base number: ");
                        if (double.TryParse(Console.ReadLine(), out double baseNum2))
                        {
                            Console.Write("Enter exponent (integer): ");
                            if (int.TryParse(Console.ReadLine(), out int expNum))
                            {
                                double powerResult = CalculatePower(baseNum2, expNum);
                                Console.WriteLine($"{baseNum2}^{expNum} = {powerResult}");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }

           
            // SUMMARY AND KEY CONCEPTS
            
            Console.WriteLine("\n\n=================================================================");
            Console.WriteLine("                    RECURSION - KEY CONCEPTS                    ");
            Console.WriteLine("=================================================================");
            Console.WriteLine("1. Base Case: The condition that stops recursion");
            Console.WriteLine("2. Recursive Case: The function calls itself with modified parameters");
            Console.WriteLine("3. Call Stack: Each recursive call is placed on the stack");
            Console.WriteLine("4. Stack Overflow: Occurs when recursion doesn't reach base case");
            Console.WriteLine("5. Memoization: Optimization technique to avoid redundant calculations");
            Console.WriteLine("\nAdvantages of Recursion:");
            Console.WriteLine("  ✓ Elegant and clean code for certain problems");
            Console.WriteLine("  ✓ Natural fit for tree/graph traversal");
            Console.WriteLine("  ✓ Easier to understand for mathematical problems");
            Console.WriteLine("\nDisadvantages of Recursion:");
            Console.WriteLine("  ✗ Can be slower due to function call overhead");
            Console.WriteLine("  ✗ Risk of stack overflow for deep recursion");
            Console.WriteLine("  ✗ May use more memory than iterative solutions");
            Console.WriteLine("=================================================================");

            Console.WriteLine("\nProgram ended. Press any key to exit...");
            Console.ReadKey();
        }
    }
}