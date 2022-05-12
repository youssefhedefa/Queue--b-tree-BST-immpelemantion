using System;
using System.Collections;

namespace queue_with_array_list
{
    class Queue
    {
        int head, tail;
        int count = 0;
        ArrayList queue;

        public Queue()
        {
            head = -1;
            tail = -1;
            queue = new ArrayList();
        }

        public void Enqueue(int value)
        {
            if (head == -1)
            {
                head++;
                tail++;
            }
            queue.Add(value);
            tail++;
            count++;
        }
        public void Dequeue()
        {
            if (tail == -1)
            {
                Console.WriteLine("The queue is empty");
                Environment.Exit(0);
            }
            else
            {
                queue.RemoveAt(head);
                tail--;
                count--;
            }
        }
        public int Count()
        {
            return count;
        }
        public void Display()
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of element that you want to store : ");
            int size = int.Parse(Console.ReadLine());

            Queue myQueue = new Queue();

            Console.WriteLine("Enter your element :- ");
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter element number {0} : ", i + 1);
                int element = int.Parse(Console.ReadLine());
                myQueue.Enqueue(element);
            }
            Console.WriteLine("number of elements in the queue is {0}", myQueue.Count() + "\n");
            myQueue.Display();


            Console.Write("How many element do you want to dequeue : ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                myQueue.Dequeue();
            }

            Console.WriteLine("number of elements in the queue is {0}", myQueue.Count() + "\n");
            myQueue.Display();
        }
    }
}