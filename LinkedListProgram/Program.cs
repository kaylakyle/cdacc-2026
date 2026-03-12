using System;

class Node
{
    public int data;
    public Node? next;  // make next nullable

    public Node(int value)
    {
        data = value;
        next = null;
    }
}

class LinkedList
{
    Node? head;  // make head nullable

    // Insert node at end (to create list)
    public void Insert(int value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = newNode;
    }

    // Delete node at the front
    public void DeleteFront()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        head = head.next;
    }

    // Delete node at the end
    public void DeleteEnd()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        if (head.next == null)
        {
            head = null;
            return;
        }

        Node temp = head;

        while (temp.next!.next != null) // ! tells compiler temp.next is not null
        {
            temp = temp.next;
        }

        temp.next = null;
    }

    // Delete node at specific position
    public void DeletePosition(int position)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        if (position == 1)
        {
            head = head.next;
            return;
        }

        Node temp = head;

        for (int i = 1; temp.next != null && i < position - 1; i++)
        {
            temp = temp.next;
        }

        if (temp.next == null)
        {
            Console.WriteLine("Position not valid");
            return;
        }

        temp.next = temp.next.next;
    }

    // Display list
    public void Display()
    {
        Node? temp = head;

        while (temp != null)
        {
            Console.Write(temp.data + " -> ");
            temp = temp.next;
        }

        Console.WriteLine("NULL");
    }
}

class Program
{
    static void Main()
    {
        LinkedList list = new LinkedList();

        list.Insert(10);
        list.Insert(20);
        list.Insert(30);
        list.Insert(40);
        list.Insert(50);

        Console.WriteLine("Original List:");
        list.Display();

        list.DeleteFront();
        Console.WriteLine("After deleting front node:");
        list.Display();

        list.DeleteEnd();
        Console.WriteLine("After deleting last node:");
        list.Display();

        list.DeletePosition(2);
        Console.WriteLine("After deleting node at position 2:");
        list.Display();
    }
}