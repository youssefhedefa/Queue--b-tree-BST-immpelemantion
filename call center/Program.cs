using System;
using System.Collections;

namespace call_center
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue myQueue = new Queue();

            Console.Write("Enter number of customers : ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter the name of customer number {0}  : ",(i+1));
                string name = Console.ReadLine();
                myQueue.Enqueue(name);
            }

            Console.WriteLine("Next one is {0}", myQueue.Dequeue());
            Console.WriteLine("You still have {0} customer ", myQueue.Count);
            Console.Write("Do you need more {Y for yes , any key for for no} ? ");
            char answer = char.Parse(Console.ReadLine().ToUpper());

            if(answer == 'Y')
            {
                while(myQueue.Count > 0)
                {
                    Console.WriteLine("You still have {0} customer ", myQueue.Count);
                    Console.WriteLine("Next one is {0}", myQueue.Dequeue());

                    Console.Write("Do you need more {Y for yes , any key for for no} ? ");
                    char answer2 = char.Parse(Console.ReadLine().ToUpper());

                    if (answer2 != 'Y')
                    {
                        break;
                    }
                }

            }
            Console.WriteLine("Take a break");
        }
    }
}
