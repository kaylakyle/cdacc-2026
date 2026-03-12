using System;

namespace QueueDataStructure
{
    // ============================================================================
    // CLASS: CustomQueue<T>
    // DESCRIPTION: Generic queue implementation using array
    // OPERATIONS: Front, Rear, Empty, Pop (Dequeue), Push (Enqueue)
    // ============================================================================
    public class CustomQueue<T>
    {
        private T[] elements;      // Array to store queue elements
        private int front;          // Index of the front element
        private int rear;           // Index of the rear element
        private int size;           // Current number of elements
        private int capacity;       // Maximum capacity of the queue

        // Constructor
        public CustomQueue(int capacity = 10)
        {
            this.capacity = capacity;
            elements = new T[capacity];
            front = 0;
            rear = -1;
            size = 0;
        }

        // ========================================================================
        // OPERATION 1: Push (Enqueue) - Add element to the rear of the queue
        // ========================================================================
        public void Push(T item)
        {
            // Check if queue is full
            if (IsFull())
            {
                Console.WriteLine($"Queue is full! Cannot push {item}. Consider increasing capacity.");
                return;
            }

            // Circular increment of rear index
            rear = (rear + 1) % capacity;
            elements[rear] = item;
            size++;
            
            Console.WriteLine($"Pushed: {item} to the rear of queue");
            DisplayQueueStatus();
        }

        // ========================================================================
        // OPERATION 2: Pop (Dequeue) - Remove and return element from the front
        // ========================================================================
        public T Pop()
        {
            // Check if queue is empty
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty! Cannot pop.");
                return default(T);
            }

            T item = elements[front];
            
            // Circular increment of front index
            front = (front + 1) % capacity;
            size--;
            
            Console.WriteLine($"Popped: {item} from the front of queue");
            DisplayQueueStatus();
            return item;
        }

        // ========================================================================
        // OPERATION 3: Front - View the front element without removing it
        // ========================================================================
        public T Front()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty! No front element.");
                return default(T);
            }

            Console.WriteLine($"Front element: {elements[front]}");
            return elements[front];
        }

        // ========================================================================
        // OPERATION 4: Rear - View the rear element without removing it
        // ========================================================================
        public T Rear()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty! No rear element.");
                return default(T);
            }

            Console.WriteLine($"Rear element: {elements[rear]}");
            return elements[rear];
        }

        // ========================================================================
        // OPERATION 5: Empty - Check if the queue is empty
        // ========================================================================
        public bool IsEmpty()
        {
            bool empty = size == 0;
            Console.WriteLine($"Queue is {(empty ? "empty" : "not empty")}");
            return empty;
        }

        // ========================================================================
        // Helper Method: Check if queue is full
        // ========================================================================
        public bool IsFull()
        {
            return size == capacity;
        }

        // ========================================================================
        // Helper Method: Get current size of queue
        // ========================================================================
        public int GetSize()
        {
            Console.WriteLine($"Current queue size: {size}");
            return size;
        }

        // ========================================================================
        // Helper Method: Display all elements in the queue
        // ========================================================================
        public void DisplayAllElements()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty - no elements to display");
                return;
            }

            Console.Write("Queue elements (front to rear): ");
            for (int i = 0; i < size; i++)
            {
                int index = (front + i) % capacity;
                Console.Write(elements[index]);
                if (i < size - 1)
                    Console.Write(" <- ");
            }
            Console.WriteLine();
        }

        // ========================================================================
        // Helper Method: Display queue status
        // ========================================================================
        private void DisplayQueueStatus()
        {
            Console.WriteLine($"  Status: Size={size}, Front={front}, Rear={rear}, Capacity={capacity}");
        }

        // ========================================================================
        // Helper Method: Clear all elements from queue
        // ========================================================================
        public void Clear()
        {
            front = 0;
            rear = -1;
            size = 0;
            Console.WriteLine("Queue cleared!");
        }
    }

    // ============================================================================
    // CLASS: Program
    // DESCRIPTION: Main program to demonstrate all queue operations
    // ============================================================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("           QUEUE DATA STRUCTURE IMPLEMENTATION            ");
            Console.WriteLine("==========================================================");
            Console.WriteLine();

            // Create a queue of integers with capacity 5
            CustomQueue<int> queue = new CustomQueue<int>(5);

            // ========================================================================
            // DEMONSTRATION 1: Basic Queue Operations
            // ========================================================================
            Console.WriteLine("DEMONSTRATION 1: BASIC QUEUE OPERATIONS");
            Console.WriteLine("----------------------------------------");

            // Initially check if queue is empty
            Console.WriteLine("\n1. Checking if queue is empty:");
            queue.IsEmpty();

            // Demonstrate Push (Enqueue) operations
            Console.WriteLine("\n2. Demonstrating PUSH (Enqueue) operations:");
            queue.Push(10);  // Add 10 to queue
            queue.Push(20);  // Add 20 to queue
            queue.Push(30);  // Add 30 to queue
            queue.Push(40);  // Add 40 to queue
            queue.Push(50);  // Add 50 to queue

            // Display all elements
            Console.WriteLine("\n3. Current queue after pushes:");
            queue.DisplayAllElements();

            // Demonstrate Front operation
            Console.WriteLine("\n4. Demonstrating FRONT operation (view front element):");
            queue.Front();

            // Demonstrate Rear operation
            Console.WriteLine("\n5. Demonstrating REAR operation (view rear element):");
            queue.Rear();

            // Demonstrate Pop (Dequeue) operations
            Console.WriteLine("\n6. Demonstrating POP (Dequeue) operations:");
            queue.Pop();     // Remove 10
            queue.Pop();     // Remove 20

            // Display after pops
            Console.WriteLine("\n7. Queue after two pops:");
            queue.DisplayAllElements();

            // Check front and rear after pops
            Console.WriteLine("\n8. Checking front and rear after pops:");
            queue.Front();
            queue.Rear();

            // ========================================================================
            // DEMONSTRATION 2: Queue Full Condition
            // ========================================================================
            Console.WriteLine("\n\nDEMONSTRATION 2: QUEUE FULL CONDITION");
            Console.WriteLine("----------------------------------------");

            // Try to push beyond capacity
            Console.WriteLine("Attempting to push to a full queue:");
            queue.Push(60);  // This should show queue is full

            // ========================================================================
            // DEMONSTRATION 3: Queue Empty Condition
            // ========================================================================
            Console.WriteLine("\n\nDEMONSTRATION 3: QUEUE EMPTY CONDITION");
            Console.WriteLine("----------------------------------------");

            // Pop all elements
            Console.WriteLine("Popping all elements:");
            while (!queue.IsEmpty())
            {
                queue.Pop();
            }

            // Try to pop from empty queue
            Console.WriteLine("\nAttempting to pop from empty queue:");
            queue.Pop();

            // Try to view front/rear of empty queue
            Console.WriteLine("\nAttempting to view front of empty queue:");
            queue.Front();

            Console.WriteLine("\nAttempting to view rear of empty queue:");
            queue.Rear();

            // ========================================================================
            // DEMONSTRATION 4: Circular Queue Behavior
            // ========================================================================
            Console.WriteLine("\n\nDEMONSTRATION 4: CIRCULAR QUEUE BEHAVIOR");
            Console.WriteLine("----------------------------------------");

            // Create a new queue
            CustomQueue<string> stringQueue = new CustomQueue<string>(3);

            Console.WriteLine("Demonstrating circular nature of queue:");
            stringQueue.Push("A");
            stringQueue.Push("B");
            stringQueue.Push("C");
            stringQueue.DisplayAllElements();

            Console.WriteLine("\nPop one element (makes space for new element):");
            stringQueue.Pop();
            stringQueue.DisplayAllElements();

            Console.WriteLine("\nPush new element 'D' (should go to rear in circular fashion):");
            stringQueue.Push("D");
            stringQueue.DisplayAllElements();

            // ========================================================================
            // DEMONSTRATION 5: Queue with Different Data Types
            // ========================================================================
            Console.WriteLine("\n\nDEMONSTRATION 5: QUEUE WITH DIFFERENT DATA TYPES");
            Console.WriteLine("----------------------------------------");

            // Queue of strings
            Console.WriteLine("String Queue:");
            CustomQueue<string> namesQueue = new CustomQueue<string>(4);
            namesQueue.Push("Alice");
            namesQueue.Push("Bob");
            namesQueue.Push("Charlie");
            namesQueue.DisplayAllElements();
            namesQueue.Front();
            namesQueue.Rear();

            // Queue of doubles
            Console.WriteLine("\nDouble Queue:");
            CustomQueue<double> doubleQueue = new CustomQueue<double>(3);
            doubleQueue.Push(3.14);
            doubleQueue.Push(2.718);
            doubleQueue.Push(1.618);
            doubleQueue.DisplayAllElements();

            // ========================================================================
            // DEMONSTRATION 6: Interactive Menu
            // ========================================================================
            Console.WriteLine("\n\n==========================================================");
            Console.WriteLine("           INTERACTIVE QUEUE DEMONSTRATION            ");
            Console.WriteLine("==========================================================");
            
            CustomQueue<int> interactiveQueue = new CustomQueue<int>(5);
            
            while (true)
            {
                Console.WriteLine("\n--- QUEUE OPERATIONS MENU ---");
                Console.WriteLine("1. Push (Enqueue) - Add element to rear");
                Console.WriteLine("2. Pop (Dequeue) - Remove element from front");
                Console.WriteLine("3. Front - View front element");
                Console.WriteLine("4. Rear - View rear element");
                Console.WriteLine("5. Empty - Check if queue is empty");
                Console.WriteLine("6. Size - Get queue size");
                Console.WriteLine("7. Display - Show all elements");
                Console.WriteLine("8. Clear - Clear the queue");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice (1-9): ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Push
                        Console.Write("Enter an integer to push: ");
                        if (int.TryParse(Console.ReadLine(), out int value))
                        {
                            interactiveQueue.Push(value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input! Please enter an integer.");
                        }
                        break;

                    case 2: // Pop
                        interactiveQueue.Pop();
                        break;

                    case 3: // Front
                        interactiveQueue.Front();
                        break;

                    case 4: // Rear
                        interactiveQueue.Rear();
                        break;

                    case 5: // Empty
                        interactiveQueue.IsEmpty();
                        break;

                    case 6: // Size
                        interactiveQueue.GetSize();
                        break;

                    case 7: // Display
                        interactiveQueue.DisplayAllElements();
                        break;

                    case 8: // Clear
                        interactiveQueue.Clear();
                        break;

                    case 9: // Exit
                        Console.WriteLine("Exiting interactive demonstration...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please enter 1-9.");
                        break;
                }

                if (choice == 9) break;
            }

            // ========================================================================
            // SUMMARY OF QUEUE OPERATIONS
            // ========================================================================
            Console.WriteLine("\n\n==========================================================");
            Console.WriteLine("                 QUEUE OPERATIONS SUMMARY                  ");
            Console.WriteLine("==========================================================");
            Console.WriteLine("| Operation | Description                          |");
            Console.WriteLine("|-----------|--------------------------------------|");
            Console.WriteLine("| Push      | Add element to the REAR of the queue |");
            Console.WriteLine("| Pop       | Remove element from the FRONT        |");
            Console.WriteLine("| Front     | View FRONT element without removing  |");
            Console.WriteLine("| Rear      | View REAR element without removing   |");
            Console.WriteLine("| Empty     | Check if queue is empty              |");
            Console.WriteLine("| Full      | Check if queue is full               |");
            Console.WriteLine("| Size      | Get number of elements in queue      |");
            Console.WriteLine("| Clear     | Remove all elements from queue       |");
            Console.WriteLine("==========================================================");
            Console.WriteLine("\nQueue follows FIFO (First-In-First-Out) principle");
            Console.WriteLine("Elements are added at the REAR and removed from the FRONT");
            Console.WriteLine("==========================================================");

            Console.WriteLine("\nProgram ended. Press any key to exit...");
            Console.ReadKey();
        }
    }
}