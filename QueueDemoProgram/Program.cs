using System;
using System.Collections.Generic;

class QueueDemo
{
    private List<int> queue; // List to store queue elements

    public QueueDemo()
    {
        queue = new List<int>();
    }

    // Push: Add element at the rear
    public void Push(int value)
    {
        queue.Add(value);
        Console.WriteLine($"{value} added to queue.");
    }

    // Pop: Remove element from the front
    public void Pop()
    {
        if (Empty())
        {
            Console.WriteLine("Queue is empty. Cannot pop.");
            return;
        }

        int removed = queue[0];
        queue.RemoveAt(0);
        Console.WriteLine($"{removed} removed from queue.");
    }

    // Front: Get the element at the front
    public void Front()
    {
        if (Empty())
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Console.WriteLine($"Front element: {queue[0]}");
    }

    // Rear: Get the element at the rear
    public void Rear()
    {
        if (Empty())
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Console.WriteLine($"Rear element: {queue[queue.Count - 1]}");
    }

    // Empty: Check if queue is empty
    public bool Empty()
    {
        return queue.Count == 0;
    }

    // Display: show all elements
    public void Display()
    {
        if (Empty())
        {
            Console.WriteLine("Queue is empty.");
            return;
        }

        Console.Write("Queue elements: ");
        foreach (int item in queue)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        QueueDemo q = new QueueDemo();

        // Demonstrate push
        q.Push(10);
        q.Push(20);
        q.Push(30);

        // Display queue
        q.Display();

        // Show front and rear
        q.Front();
        q.Rear();

        // Pop an element
        q.Pop();
        q.Display();

        // Check front and rear after pop
        q.Front();
        q.Rear();

        // Pop all elements
        q.Pop();
        q.Pop();
        q.Pop(); // Attempt pop on empty queue
    }
}

// How the Program Works
//10 added to queue.
//20 added to queue.
//30 added to queue.
//Queue elements: 10 20 30
//Front element: 10
//Rear element: 30
//10 removed from queue.
//Queue elements: 20 30
//Front element: 20
//Rear element: 30
//20 removed from queue.
//30 removed from queue.
//Queue is empty. Cannot pop.


//Explanation of Operations
//Operation	What It Does in Code
//Push	Adds an element to the end of the queue (queue.Add(value))
//Pop	Removes element from the front of the queue (queue.RemoveAt(0))
//Front	Shows the first element in the queue (queue[0])
//Rear	Shows the last element in the queue (queue[queue.Count - 1])
//Empty	Checks if the queue has no elements (queue.Count == 0)