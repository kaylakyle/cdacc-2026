using System;

class StackArray
{
    private int[] stackArray; // Array to store stack elements
    private int top;          // Index of the top element
    private int capacity;     // Maximum capacity of the stack

    // Constructor to initialize the stack with given array
    public StackArray(int[] initialArray)
    {
        capacity = initialArray.Length;
        stackArray = new int[capacity];
        top = -1; // Stack is initially empty

        // Push initial elements into stack
        foreach (int item in initialArray)
        {
            Push(item);
        }
    }

    // Push: add element at the top
    public void Push(int value)
    {
        if (top == capacity - 1)
        {
            Console.WriteLine("Stack overflow! Cannot push " + value);
            return;
        }

        top++;
        stackArray[top] = value;
        Console.WriteLine($"{value} pushed onto stack.");
    }

    // Pop: remove and return top element
    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack underflow! Cannot pop.");
            return -1;
        }

        int popped = stackArray[top];
        top--;
        Console.WriteLine($"{popped} popped from stack.");
        return popped;
    }

    // Peek: return top element without removing
    public int Peek()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty. Nothing to peek.");
            return -1;
        }

        return stackArray[top];
    }

    // Size: return number of elements in stack
    public int Size()
    {
        return top + 1;
    }

    // Check if stack is empty
    public bool IsEmpty()
    {
        return top == -1;
    }

    // Display stack elements
    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty.");
            return;
        }

        Console.Write("Stack elements (top to bottom): ");
        for (int i = top; i >= 0; i--)
        {
            Console.Write(stackArray[i] + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Initial array for the stack
        int[] initialArray = { 5, 8, 7, 2, 1, 9, 4, 3 };

        // Create stack object
        StackArray stack = new StackArray(initialArray);

        Console.WriteLine("\nInitial stack:");
        stack.Display();

        // Demonstrate stack operations
        stack.Push(10); // Push new element
        stack.Display();

        stack.Pop(); // Remove top element
        stack.Display();

        Console.WriteLine($"Top element (Peek): {stack.Peek()}");

        Console.WriteLine($"Current stack size: {stack.Size()}");
    }
}

// How the Program Works
//5 pushed onto stack.
//8 pushed onto stack.
//7 pushed onto stack.
//2 pushed onto stack.
//1 pushed onto stack.

// Initial stack:
//Stack elements (top to bottom): 3 4 9 1 2 7 8 5

//10 pushed onto stack.
//Stack elements (top to bottom): 10 3 4 9 1 2 7 8 5

//10 popped from stack.
//Stack elements (top to bottom): 3 4 9 1 2 7 8 5

//Top element (Peek): 3
//Current stack size: 8
