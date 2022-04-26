using System;

namespace queue_with_array
{
    class Queue
    {
        int head, tail , capacity;
        int count = 0;
        int[] queue;

        public Queue(int size)
        {
            head = -1;
            tail = -1;
            capacity = size;
            queue = new int[capacity];
        }

        public int getTail()
        {
            int currentTail = tail;
            currentTail++;
            return currentTail;
        }

        public void Enqueue(int value)
        {
            if (tail == capacity)
            {
                Console.WriteLine("The queue is full");
            }
            else
            {
                if (head == -1)
                {
                    head++;
                    tail++;
                }
                queue[tail] = value;
                tail++;
                count++;
            }
        }

        public void Dequeue()
        {
            int value;
            if (tail == -1)
            {
                Console.WriteLine("The queue is empty");
                Environment.Exit(0);
            }
            else
            {
                value = queue[head];

                for(int i = head; i < tail-1; i++)
                {
                    queue[i] = queue[i + 1];
                }

                Console.WriteLine(value);
                Console.WriteLine();

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
            for(int i = head; i < tail; i++)
            {
                Console.Write(queue[i] + "\t");
            }
            Console.WriteLine();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your queue capacity : ");
            int size = int.Parse(Console.ReadLine());

            Queue myQueue = new Queue(size);

            if (size == myQueue.getTail())
            {
                Console.WriteLine("The queue is full");
                Environment.Exit(0);
            }

            Console.WriteLine("Enter your element : ");
            for(int i = 0; i<size; i++)
            {
                Console.Write("Enter element number {0} : ",i+1);
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

            Console.WriteLine("number of elements in the queue is {0}", myQueue.Count()+"\n");
            myQueue.Display();

        }
    }
}
