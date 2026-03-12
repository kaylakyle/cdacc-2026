using System;

namespace LinkedListDeletionDemo
{
    // Node class representing each element in the linked list
    public class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }  // Made nullable with ?

        public Node(int data)
        {
            Data = data;
            Next = null;  // Now this is fine since Next is nullable
        }
    }

    // LinkedList class with all deletion operations
    public class LinkedList
    {
        private Node? head; // Made nullable with ?

        public LinkedList()
        {
            head = null;  // Now this is fine since head is nullable
        }

        // Method to insert a node at the end (for building the list)
        public void InsertAtEnd(int data)
        {
            Node newNode = new Node(data);

            // If list is empty, make new node as head
            if (head == null)
            {
                head = newNode;
                return;
            }

            // Traverse to the last node
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            // Add new node at the end
            current.Next = newNode;
        }

        // METHOD 1: Delete node from the front (beginning)
        public void DeleteFromFront()
        {
            // Check if list is empty
            if (head == null)
            {
                Console.WriteLine("List is empty. Cannot delete from front.");
                return;
            }

            // Store the node to be deleted
            Node temp = head;
            
            // Move head to next node
            head = head.Next;
            
            // The old head will be garbage collected
            Console.WriteLine($"Deleted node with data {temp.Data} from the front.");
        }

        // METHOD 2: Delete node from the end
        public void DeleteFromEnd()
        {
            // Check if list is empty
            if (head == null)
            {
                Console.WriteLine("List is empty. Cannot delete from end.");
                return;
            }

            // If only one node exists
            if (head.Next == null)
            {
                int deletedData = head.Data;
                head = null;
                Console.WriteLine($"Deleted node with data {deletedData} from the end.");
                return;
            }

            // Traverse to the second last node
            Node current = head;
            while (current.Next != null && current.Next.Next != null)
            {
                current = current.Next;
            }

            // Store the data of node to be deleted
            int data = current.Next!.Data; // Using null-forgiving operator since we know Next isn't null
            
            // Remove the last node
            current.Next = null;
            
            Console.WriteLine($"Deleted node with data {data} from the end.");
        }

        // METHOD 3: Delete node from a specified position (0-based index)
        public void DeleteFromPosition(int position)
        {
            // Check if list is empty
            if (head == null)
            {
                Console.WriteLine("List is empty. Cannot delete from position.");
                return;
            }

            // Check if position is valid
            if (position < 0)
            {
                Console.WriteLine("Invalid position. Position must be >= 0.");
                return;
            }

            // If deleting the head node (position 0)
            if (position == 0)
            {
                DeleteFromFront();
                return;
            }

            // Traverse to the node just before the target position
            Node? current = head; // Made nullable
            int count = 0;

            while (current != null && count < position - 1)
            {
                current = current.Next;
                count++;
            }

            // Check if position is valid (within list bounds)
            if (current == null || current.Next == null)
            {
                Console.WriteLine($"Invalid position {position}. Position exceeds list length.");
                return;
            }

            // Store the node to be deleted
            Node nodeToDelete = current.Next;
            int deletedData = nodeToDelete.Data;
            
            // Skip the node to be deleted
            current.Next = nodeToDelete.Next;
            
            Console.WriteLine($"Deleted node with data {deletedData} from position {position}.");
        }

        // Method to display the linked list
        public void DisplayList()
        {
            if (head == null)
            {
                Console.WriteLine("List is empty.");
                return;
            }

            Console.Write("Linked List: ");
            Node? current = head; // Made nullable
            while (current != null)
            {
                Console.Write(current.Data);
                if (current.Next != null)
                    Console.Write(" -> ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // Method to get the length of the list
        public int GetLength()
        {
            int count = 0;
            Node? current = head; // Made nullable
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            int choice = 0, data = 0, position = 0; // Initialize variables

            // Create initial list with some nodes for demonstration
            Console.WriteLine("=== SINGLY LINKED LIST DELETION OPERATIONS ===\n");
            
            // Insert some initial nodes
            Console.WriteLine("Creating initial linked list with nodes: 10, 20, 30, 40, 50\n");
            list.InsertAtEnd(10);
            list.InsertAtEnd(20);
            list.InsertAtEnd(30);
            list.InsertAtEnd(40);
            list.InsertAtEnd(50);
            
            list.DisplayList();
            Console.WriteLine($"Current list length: {list.GetLength()}\n");

            // Menu-driven program
            do
            {
                Console.WriteLine("\n--- LINKED LIST DELETION MENU ---");
                Console.WriteLine("1. Delete from Front");
                Console.WriteLine("2. Delete from End");
                Console.WriteLine("3. Delete from Specific Position");
                Console.WriteLine("4. Display List");
                Console.WriteLine("5. Insert New Node (at end)");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");
                
                string? input = Console.ReadLine(); // Made nullable
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Delete from front
                        Console.WriteLine("\n--- Deleting from Front ---");
                        list.DisplayList();
                        list.DeleteFromFront();
                        Console.WriteLine("After deletion:");
                        list.DisplayList();
                        Console.WriteLine($"New list length: {list.GetLength()}");
                        break;

                    case 2: // Delete from end
                        Console.WriteLine("\n--- Deleting from End ---");
                        list.DisplayList();
                        list.DeleteFromEnd();
                        Console.WriteLine("After deletion:");
                        list.DisplayList();
                        Console.WriteLine($"New list length: {list.GetLength()}");
                        break;

                    case 3: // Delete from specific position
                        Console.WriteLine("\n--- Deleting from Specific Position ---");
                        list.DisplayList();
                        Console.Write("Enter position to delete (0-based index): ");
                        string? posInput = Console.ReadLine(); // Made nullable
                        if (int.TryParse(posInput, out position))
                        {
                            list.DeleteFromPosition(position);
                            Console.WriteLine("After deletion:");
                            list.DisplayList();
                            Console.WriteLine($"New list length: {list.GetLength()}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid position input!");
                        }
                        break;

                    case 4: // Display list
                        Console.WriteLine("\n--- Current Linked List ---");
                        list.DisplayList();
                        Console.WriteLine($"List length: {list.GetLength()}");
                        break;

                    case 5: // Insert new node
                        Console.Write("Enter data for new node: ");
                        string? dataInput = Console.ReadLine(); // Made nullable
                        if (int.TryParse(dataInput, out data))
                        {
                            list.InsertAtEnd(data);
                            Console.WriteLine($"Node with data {data} inserted at the end.");
                            list.DisplayList();
                        }
                        else
                        {
                            Console.WriteLine("Invalid data input!");
                        }
                        break;

                    case 6: // Exit
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please enter 1-6.");
                        break;
                }

            } while (choice != 6);

            Console.WriteLine("\nProgram ended. Press any key to exit...");
            Console.ReadKey();
        }
    }
}