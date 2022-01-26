using System;

namespace LinkedListNode
/*
 * Recreate Linked List Functionality for fun and learning!   
 */
{
    public class Node 
    {
        int value;
        Node nextNode;

    public Node(int value)
        {
            this.value = value;
            this.nextNode = null;
        }

        public Node (int value, Node passedNode)
        {
            this.value = value;
            this.nextNode = passedNode;
        }

        public Node getNext()
        {
            return this.nextNode;
        }

        public void setNext(Node passedNode)
        {
            this.nextNode = passedNode;
        }

        public int getValue()
        {
            return this.value;
        }
    
    }

    public class LinkList
    {
        private Node head;
        public LinkList(int head)
        {
            this.head = new Node(head);
        }

        public void addLast(int value, Node startPoint)
        {
            if (startPoint.getNext() != null)
            {
                addLast(value, startPoint.getNext());
            }
            else
            {
                startPoint.setNext(new Node(value));
            }
        }

        public void addFirst(int value)
        {
            this.head = new Node(value, this.head);
        }

        public Node getHead()
        {
            return this.head;
        }

        public int findValue(int passedValue)
        {
            int index = 0;
            if (this.head.getValue() == passedValue)
            {
                return 0;
            }
            bool go = true;
            Node currentNode = this.head.getNext();
            while (go)
            {
                index++;
                if (currentNode.getValue() == passedValue)
                {
                    return index;
                }
                else if (currentNode.getNext() == null)
                {
                    go = false;
                }
                currentNode = currentNode.getNext();
            }
            return 0;
        }


        public void print()
        {
            Node current = this.head;
            while (current.getNext() != null)
            {
                Console.Write(current.getValue());
                current = current.getNext();
            }
            Console.WriteLine(current.getValue());
        }
    }

    class Program
    {

        public 
        static void Main(string[] args)
        {
            LinkList myList = new LinkList(0);
            while (true)
            {
                Console.WriteLine("(A)dd a number to the start, Add a number to the (E)nd, (N)umber location, or (Q)uit?");
                string input = Console.ReadLine().ToLower();
                switch (input[0])
                {
                    case 'a':
                        Console.WriteLine("Enter a value to add to the beginning.");
                        int firstValue = Int32.Parse(Console.ReadLine());
                        myList.addFirst(firstValue);
                        myList.print();
                        break;
                    case 'e':
                        Console.WriteLine("Enter a value to add to the end.");
                        int lastValue = Int32.Parse(Console.ReadLine());
                        myList.addLast(lastValue, myList.getHead());
                        myList.print();
                        break;
                    case 'n':
                        Console.WriteLine("Enter a value to add to the end.");
                        int findValue = Int32.Parse(Console.ReadLine());
                        Console.WriteLine(myList.findValue(findValue));
                        break;
                    case 'q':
                        System.Environment.Exit(0);
                        break;
                }

            }
        }
    }
}
