using System;

namespace queue_with_linked_list
{
    class Node
    {
        public int data;
        public Node next;
    }
    class Myqueue
    {
        Node head;
        Node current;
        int counter;

        public Myqueue()
        {
            head = new Node();
            current = head;
        }
        public void Enqueue(int value)
        {
            Node newNode = new Node();
            newNode.data = value;
            current.next = newNode;
            current = newNode;
            counter++;
        }
        public void Dequeue()
        {
            if(counter <= 0)
            {
                Console.WriteLine("Your queue is empty ");
            }
            else
            {
                int value;
                value = head.next.data;
                head.next = head.next.next;
                counter--;
                Console.WriteLine("the element that Dequeued is : {0}",value);
            }
        }
        public void Display()
        {
            Node priNode = head;
            while (priNode.next != null)
            {
                priNode = priNode.next;
                Console.Write(priNode.data+"\t");
            }
            Console.WriteLine();
        }
        public void Counter()
        {
            Console.WriteLine("number of element in the queue is {0}",counter);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Myqueue queue = new Myqueue();

            Console.Write("number of element that do you want to enqueue : ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.Write("enter element number {0} : ",i+1);
                int element = int.Parse(Console.ReadLine());
                queue.Enqueue(element);
            }
            queue.Counter();
            queue.Display();


            Console.Write("number of element that do you want to dequeue : ");
            int numToDequeue = int.Parse(Console.ReadLine());
            for (int i = 0; i < numToDequeue; i++)
            {
                queue.Dequeue();
            }
            queue.Counter();
            queue.Display();

        }
    }
}
