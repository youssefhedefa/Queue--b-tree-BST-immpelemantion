using System;
using System.Collections;
using System.Collections.Generic;


namespace BST
{
    class Node
    {
        public int value;
        public Node right_node;
        public Node left_node;

        public Node(int x)
        {
            value = x;
        }
    }
    class Tree
    {
        public Node head;
        public int count;
        public ArrayList values = new ArrayList();


        public void Add(int x)
        {
            if(head == null)
            {
                head = new Node(x);
            }
            else
            {
                Addto(head, x);
            }
            count++;
        }
        private void Addto(Node node,int x)
        {
            if(x < node.value)
            {
                if (node.left_node == null)
                {
                    node.left_node = new Node(x);
                }
                else
                {
                    Addto(node.left_node, x);
                }
            }
            else
            {
                if (node.right_node == null)
                {
                    node.right_node = new Node(x);
                }
                else
                {
                    Addto(node.right_node, x);
                }
            }
        }

        public void Pre_order()
        {
            Pre_order(head);
        }
        private void Pre_order(Node node)
        {
            if(node != null)
            {
                Console.WriteLine(node.value);
                Pre_order(node.left_node);
                Pre_order(node.right_node);
            }
        }

        public void In_order()
        {
            In_order(head);
        }
        private void In_order(Node node)
        {
            if (node != null)
            {
                In_order(node.left_node);
                Console.WriteLine(node.value);
                In_order(node.right_node);
            }
        }

        public void Post_order()
        {
            Post_order(head);
        }
        private void Post_order(Node node)
        {
            if (node != null)
            {
                Post_order(node.left_node);
                Post_order(node.right_node);
                Console.WriteLine(node.value);
            }
        }

        public bool Is_contain(int x)
        {
            Node current = head;
            while(current != null)
            {
                if(x < current.value)
                {
                    current = current.left_node;
                }
                else if (x > current.value)
                {
                    current = current.right_node;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void BFS()
        {
            Bfs_traversal(head);
        }

        private void Bfs_traversal(Node node)
        {

            Queue<Node> myQueue = new Queue<Node>();
            myQueue.Enqueue(node);

            while (myQueue.Count > 0)
            {
                node = myQueue.Dequeue();
                Console.Write(node.value+"  ");

                if(node.left_node != null)
                {
                    myQueue.Enqueue(node.left_node);
                }
                if (node.right_node != null)
                {
                    myQueue.Enqueue(node.right_node);
                }
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree myTree = new Tree();

            myTree.Add(8);
            myTree.Add(25);
            myTree.Add(4);
            myTree.Add(5);
            myTree.Add(50);
            myTree.Add(7);
            myTree.Add(3);
            myTree.Add(2);
            myTree.Add(70);

            Console.WriteLine("Is the tree contain {0} ? {1} ",7,myTree.Is_contain(7));

            myTree.Pre_order();
            Console.WriteLine("--------------");
            myTree.In_order();
            Console.WriteLine("--------------");
            myTree.Post_order();
            Console.WriteLine("--------------");
            myTree.BFS();
            Console.WriteLine("--------------");
        }
    }
}
