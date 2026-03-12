using System;

namespace StackDataStructure
{
    
    // CLASS: CustomStack<T>
    // DESCRIPTION: Generic stack implementation using array
    // OPERATIONS: Push, Pop, Peek, Size, and additional helper methods
    public class CustomStack<T>
    {
        private T[] elements;      // Array to store stack elements
        private int top;            // Index of the top element
        private int capacity;       // Maximum capacity of the stack
        private const int DefaultCapacity = 10;

        // Constructor with default capacity
        public CustomStack() : this(DefaultCapacity)
        {
        }

        // Constructor with specified capacity
        public CustomStack(int capacity)
        {
            this.capacity = capacity;
            elements = new T[capacity];
            top = -1;  // Stack is empty when top is -1
        }

        // Constructor to initialize stack with initial elements
        public CustomStack(T[] initialElements) : this(initialElements.Length * 2)
        {
            foreach (T element in initialElements)
            {
                Push(element);
            }
        }

        
        // OPERATION 1: Push - Add element at the top of the stack
        
        public void Push(T item)
        {
            // Check if stack is full
            if (IsFull())
            {
                Console.WriteLine($"Stack is full! Cannot push {item}. Consider increasing capacity.");
                return;
            }

            // Increment top and add element
            elements[++top] = item;
            
            Console.WriteLine($"Pushed: {item} to the top of stack");
            DisplayStackStatus();
        }

       
        // OPERATION 2: Pop - Remove and return the top element from the stack
        public T? Pop()  // Made return type nullable with ?
        {
            // Check if stack is empty
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty! Cannot pop.");
                return default(T);  // default(T) is fine
            }

            T item = elements[top--];
            
            Console.WriteLine($"Popped: {item} from the top of stack");
            DisplayStackStatus();
            return item;
        }

        // OPERATION 3: Peek - Return the top element without removing it
        public T? Peek()  // Made return type nullable with ?
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty! No top element.");
                return default(T);  // default(T) is fine
            }

            Console.WriteLine($"Peek (top element): {elements[top]}");
            return elements[top];
        }

        // OPERATION 4: Size - Returns the number of elements in the stack
        public int Size()
        {
            int size = top + 1;
            Console.WriteLine($"Stack size: {size}");
            return size;
        }

        // Helper Method: Check if stack is empty
        public bool IsEmpty()
        {
            bool empty = top == -1;
            Console.WriteLine($"Stack is {(empty ? "empty" : "not empty")}");
            return empty;
        }

        // Helper Method: Check if stack is full
        public bool IsFull()
        {
            return top == capacity - 1;
        }

        // Helper Method: Get current capacity
        public int GetCapacity()
        {
            return capacity;
        }

        // Helper Method: Display all elements in the stack
        public void DisplayAllElements()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty - no elements to display");
                return;
            }

            Console.Write("Stack elements (top to bottom): ");
            for (int i = top; i >= 0; i--)
            {
                Console.Write(elements[i]);
                if (i > 0)
                    Console.Write(" -> ");
            }
            Console.WriteLine();
        }

        // Helper Method: Display stack from bottom to top
        public void DisplayStackBottomToTop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty");
                return;
            }

            Console.Write("Stack elements (bottom to top): ");
            for (int i = 0; i <= top; i++)
            {
                Console.Write(elements[i]);
                if (i < top)
                    Console.Write(" -> ");
            }
            Console.WriteLine();
        }

        // Helper Method: Display stack status
        private void DisplayStackStatus()
        {
            Console.WriteLine($"  Status: Top={top}, Size={Size()}, Capacity={capacity}");
        }

        // Helper Method: Clear all elements from stack
        public void Clear()
        {
            top = -1;
            Console.WriteLine("Stack cleared!");
        }

        // Helper Method: Search for an element in the stack
        public int Search(T item)
        {
            for (int i = top; i >= 0; i--)
            {
                if (elements[i] != null && elements[i]!.Equals(item))  // Added null check with !
                {
                    int position = top - i + 1; // Position from top (1-based)
                    Console.WriteLine($"Element {item} found at position {position} from top");
                    return position;
                }
            }
            Console.WriteLine($"Element {item} not found in stack");
            return -1;
        }
    }

    // CLASS: Program
    // DESCRIPTION: Main program to demonstrate all stack operations
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("           STACK DATA STRUCTURE IMPLEMENTATION            ");
            Console.WriteLine("==========================================================");
            Console.WriteLine();

            // Given array
            int[] givenArray = { 5, 8, 7, 2, 1, 9, 4, 3 };
            
            Console.WriteLine("Given array elements: [{0}]", string.Join(", ", givenArray));
            Console.WriteLine();

            // DEMONSTRATION 1: Create and Initialize Stack with Given Array
            Console.WriteLine("DEMONSTRATION 1: CREATING STACK WITH GIVEN ARRAY");
            Console.WriteLine("--------------------------------------------------");
            
            // Create stack with the given array
            CustomStack<int> stack = new CustomStack<int>(givenArray);
            
            Console.WriteLine("Stack created with all array elements:");
            stack.DisplayAllElements();
            stack.DisplayStackBottomToTop();
            Console.WriteLine();

            // DEMONSTRATION 2: Basic Stack Operations
            Console.WriteLine("DEMONSTRATION 2: BASIC STACK OPERATIONS");
            Console.WriteLine("----------------------------------------");

            // Size operation
            Console.WriteLine("\n1. SIZE OPERATION (Number of elements):");
            int size = stack.Size();

            // Peek operation
            Console.WriteLine("\n2. PEEK OPERATION (View top element without removing):");
            stack.Peek();

            // Push operation
            Console.WriteLine("\n3. PUSH OPERATION (Add element at top):");
            Console.WriteLine("Current stack:");
            stack.DisplayAllElements();
            stack.Push(10);  // Push new element
            stack.Push(15);  // Push another element

            // Pop operation
            Console.WriteLine("\n4. POP OPERATION (Remove top element):");
            Console.WriteLine("Before pop:");
            stack.DisplayAllElements();
            int? popped = stack.Pop();  // Made nullable with ?
            if (popped.HasValue)
            {
                Console.WriteLine($"Removed element: {popped}");
            }
            Console.WriteLine("After pop:");
            stack.DisplayAllElements();

            // Multiple pops
            Console.WriteLine("\n5. MULTIPLE POP OPERATIONS:");
            Console.WriteLine("Popping 3 elements:");
            stack.Pop();
            stack.Pop();
            stack.Pop();

            // DEMONSTRATION 3: Stack with Original Elements
            Console.WriteLine("\n\nDEMONSTRATION 3: WORKING WITH ORIGINAL ELEMENTS");
            Console.WriteLine("--------------------------------------------------");
            
            // Create a new stack with the original array
            CustomStack<int> originalStack = new CustomStack<int>(givenArray);
            
            Console.WriteLine("Original stack with all elements:");
            originalStack.DisplayAllElements();
            
            // Perform operations in sequence
            Console.WriteLine("\nPerforming operations on original stack:");
            
            Console.WriteLine("Peek at top:");
            originalStack.Peek();  // Should show 3 (last element)
            
            Console.WriteLine("\nPop top element:");
            originalStack.Pop();    // Removes 3
            
            Console.WriteLine("\nPush new element 6:");
            originalStack.Push(6);  // Add 6
            
            Console.WriteLine("\nFinal stack:");
            originalStack.DisplayAllElements();
            
            Console.WriteLine("\nStack from bottom to top:");
            originalStack.DisplayStackBottomToTop();

            // DEMONSTRATION 4: Stack Underflow/Empty Stack Operations
            Console.WriteLine("\n\nDEMONSTRATION 4: STACK UNDERFLOW (Empty Stack)");
            Console.WriteLine("--------------------------------------------------");
            
            CustomStack<int> emptyStack = new CustomStack<int>(3);
            
            Console.WriteLine("Working with empty stack:");
            emptyStack.IsEmpty();
            emptyStack.Size();
            emptyStack.Peek();  // Try to peek empty stack
            emptyStack.Pop();    // Try to pop empty stack

            
            // DEMONSTRATION 5: Stack Overflow (Full Stack)
            Console.WriteLine("\n\nDEMONSTRATION 5: STACK OVERFLOW (Full Stack)");
            Console.WriteLine("------------------------------------------------");
            
            CustomStack<int> smallStack = new CustomStack<int>(3);
            Console.WriteLine($"Small stack created with capacity: {smallStack.GetCapacity()}");
            
            // Fill the stack
            smallStack.Push(100);
            smallStack.Push(200);
            smallStack.Push(300);
            
            Console.WriteLine("\nStack is now full:");
            smallStack.DisplayAllElements();
            
            // Try to push to full stack
            Console.WriteLine("\nAttempting to push to full stack:");
            smallStack.Push(400);  // This should show stack full message

            
            // DEMONSTRATION 6: Search Operation
            
            Console.WriteLine("\n\nDEMONSTRATION 6: SEARCH OPERATION");
            Console.WriteLine("-----------------------------------");
            
            CustomStack<int> searchStack = new CustomStack<int>(givenArray);
            searchStack.DisplayAllElements();
            
            Console.WriteLine("\nSearching for element 7:");
            searchStack.Search(7);
            
            Console.WriteLine("\nSearching for element 1:");
            searchStack.Search(1);
            
            Console.WriteLine("\nSearching for element 99 (not in stack):");
            searchStack.Search(99);

           
            // DEMONSTRATION 7: Interactive Menu
           
            Console.WriteLine("\n\n==========================================================");
            Console.WriteLine("           INTERACTIVE STACK DEMONSTRATION            ");
            Console.WriteLine("==========================================================");
            
            CustomStack<int> interactiveStack = new CustomStack<int>(givenArray);
            
            Console.WriteLine("Initial stack with given array [{0}]", string.Join(", ", givenArray));
            interactiveStack.DisplayAllElements();
            
            while (true)
            {
                Console.WriteLine("\n--- STACK OPERATIONS MENU ---");
                Console.WriteLine("1. Push - Add element at top");
                Console.WriteLine("2. Pop - Remove top element");
                Console.WriteLine("3. Peek - View top element");
                Console.WriteLine("4. Size - Get number of elements");
                Console.WriteLine("5. Empty - Check if stack is empty");
                Console.WriteLine("6. Display - Show all elements (top to bottom)");
                Console.WriteLine("7. Display (Bottom to Top)");
                Console.WriteLine("8. Search - Find element position");
                Console.WriteLine("9. Clear - Clear all elements");
                Console.WriteLine("10. Reset - Reset to original array");
                Console.WriteLine("11. Exit");
                Console.Write("Enter your choice (1-11): ");

                string? input = Console.ReadLine();  // Made nullable with ?
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Push
                        Console.Write("Enter an integer to push: ");
                        string? pushInput = Console.ReadLine();  // Made nullable
                        if (int.TryParse(pushInput, out int pushValue))
                        {
                            interactiveStack.Push(pushValue);
                            interactiveStack.DisplayAllElements();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter an integer.");
                        }
                        break;

                    case 2: // Pop
                        interactiveStack.Pop();
                        interactiveStack.DisplayAllElements();
                        break;

                    case 3: // Peek
                        interactiveStack.Peek();
                        break;

                    case 4: // Size
                        interactiveStack.Size();
                        break;

                    case 5: // Empty
                        interactiveStack.IsEmpty();
                        break;

                    case 6: // Display
                        Console.WriteLine("\nStack (top to bottom):");
                        interactiveStack.DisplayAllElements();
                        break;

                    case 7: // Display Bottom to Top
                        Console.WriteLine("\nStack (bottom to top):");
                        interactiveStack.DisplayStackBottomToTop();
                        break;

                    case 8: // Search
                        Console.Write("Enter element to search: ");
                        string? searchInput = Console.ReadLine();  // Made nullable
                        if (int.TryParse(searchInput, out int searchValue))
                        {
                            interactiveStack.Search(searchValue);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter an integer.");
                        }
                        break;

                    case 9: // Clear
                        interactiveStack.Clear();
                        break;

                    case 10: // Reset to original array
                        interactiveStack = new CustomStack<int>(givenArray);
                        Console.WriteLine("Stack reset to original array:");
                        interactiveStack.DisplayAllElements();
                        break;

                    case 11: // Exit
                        Console.WriteLine("Exiting interactive demonstration...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please enter 1-11.");
                        break;
                }

                if (choice == 11) break;
            }

           
            // SUMMARY OF STACK OPERATIONS
            
            Console.WriteLine("\n\n==========================================================");
            Console.WriteLine("                 STACK OPERATIONS SUMMARY                  ");
            Console.WriteLine("==========================================================");
            Console.WriteLine("| Operation | Description                          |");
            Console.WriteLine("|-----------|--------------------------------------|");
            Console.WriteLine("| Push      | Add element to the TOP of the stack  |");
            Console.WriteLine("| Pop       | Remove and return TOP element        |");
            Console.WriteLine("| Peek      | View TOP element without removing    |");
            Console.WriteLine("| Size      | Get number of elements in stack      |");
            Console.WriteLine("| Empty     | Check if stack is empty              |");
            Console.WriteLine("| Full      | Check if stack is full               |");
            Console.WriteLine("| Search    | Find position of element from top    |");
            Console.WriteLine("| Clear     | Remove all elements from stack       |");
            Console.WriteLine("==========================================================");
            Console.WriteLine("\nStack follows LIFO (Last-In-First-Out) principle");
            Console.WriteLine("Elements are added and removed from the TOP only");
            Console.WriteLine("==========================================================");
            
            // Display final state with original array
            Console.WriteLine("\nFinal stack with original array elements:");
            Console.WriteLine($"Original array: [{string.Join(", ", givenArray)}]");
            CustomStack<int> finalStack = new CustomStack<int>(givenArray);
            Console.WriteLine("Stack (top to bottom):");
            finalStack.DisplayAllElements();
            Console.WriteLine("Stack (bottom to top):");
            finalStack.DisplayStackBottomToTop();

            Console.WriteLine("\nProgram ended. Press any key to exit...");
            Console.ReadKey();
        }
    }
}