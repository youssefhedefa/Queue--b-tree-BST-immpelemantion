using System;

namespace B__tree
{
    public class Globals
    {
        public int MAX = 3;
    }
    public class Node
    {        
        public bool IS_LEAF;
        public int size;
        public int[] key;
        public Node[] ptr;
        Globals M = new Globals();
        public Node()
        {
            key = new int[M.MAX];
            ptr = new Node[M.MAX + 1];
        }
    }
    //build tree and add elements
    class BPtree
    {
        Node parent;
        Node root;
        Globals M = new Globals();

        public void insert(int x)
        {
            // if root node is empty
            if (root == null)
            {
                root = new Node();     //the the new root node is created.
                root.key[0] = x;       // and its first element will be the value that passed.
                root.IS_LEAF = true;   //it is by defult because there are no another nodes. 
                root.size = 1;         // and the size increment by 1.
            }

            //else mean that the root node was created,root is leaf,size is at least 1
            else
            {
                Node cursor = root; //take a shallow copy from root to curser

                while (cursor.IS_LEAF == false)//that mean that the item is upgraded to a higher level 
                {
                    parent = cursor;
                    for (int i = 0; i < cursor.size; i++)
                    {
                        // to connect the perant node to its child
                        if (x < cursor.key[i])
                        {
                            cursor = cursor.ptr[i]; 
                            break;
                        }
                        if (i == cursor.size -1)
                        {
                            cursor = cursor.ptr[i + 1];
                            break;
                        }
                    }
                }

                if(cursor.size < M.MAX)    //check if there are space in the current node 
                {
                    int i = 0;
                    while(x > cursor.key[i] && i < cursor.size) //share in sorting the node and find free space 
                    {
                        i++;
                    }
                    for (int j = cursor.size; j > i; j--)//sort the node
                    {
                        cursor.key[j] = cursor.key[j - 1]; //shifting the elements to store the smaller values
                    }
                    cursor.key[i] = x; //the value stored in free space
                    cursor.size++; // the size increment by 1
                    cursor.ptr[cursor.size] = cursor.ptr[cursor.size - 1];
                    cursor.ptr[cursor.size - 1] = null; //store only last node to contect them together
                }
                // else create another node
                else
                {
                    Node newLeaf = new Node(); // take another object
                    int[] virtualNode = new int[M.MAX + 1]; // container to store the keys
                    int i;
                    for (i = 0; i < M.MAX; i++)
                    {
                        virtualNode[i] = cursor.key[i]; // store the keys
                    }
                    i = 0;
                    int j;
                    while (x > virtualNode[i] && i < M.MAX) //share in the sorting,find free space
                    {
                        i++;
                    }
                    for (j = M.MAX + 1; j > i; j--)//sort the node
                    {
                        virtualNode[j-1] = virtualNode[j - 2]; //shifting the elements to store the smaller values
                    }
                    virtualNode[i] = x;  // store the value in the array
                    newLeaf.IS_LEAF = true; // make the node leaf
                    cursor.size = (M.MAX + 1) / 2;
                    newLeaf.size = M.MAX + 1 - (M.MAX + 1) / 2;
                    cursor.ptr[cursor.size] = newLeaf; //connecting the nodes with each others
                    newLeaf.ptr[newLeaf.size] = cursor.ptr[M.MAX];
                    cursor.ptr[M.MAX] = null;
                    for (i = 0; i < cursor.size; i++)
                    {
                        cursor.key[i] = virtualNode[i]; //store the values in original node
                    }
                    for (i = 0, j = cursor.size; i < newLeaf.size; i++, j++)
                    {
                        newLeaf.key[i] = virtualNode[j]; //store the values in original node,and to do another operations
                    }
                    if (cursor == root)
                    {
                        Node newRoot = new Node();
                        newRoot.key[0] = newLeaf.key[0];
                        newRoot.ptr[0] = cursor;
                        newRoot.ptr[1] = newLeaf;
                        newRoot.IS_LEAF = false;
                        newRoot.size = 1;
                        root = newRoot;
                    }
                    else
                    {
                        insertInternal(newLeaf.key[0], parent, newLeaf);
                    }

                }
            }
        }

        public void insertInternal(int x, Node cursor, Node child)
        {
            if (cursor.size < M.MAX)
            {
                int i = 0;
                while (x > cursor.key[i] && i < cursor.size)//find free space
                {
                    i++;
                }
                for (int j = cursor.size; j > i; j--)
                {
                    cursor.key[j] = cursor.key[j - 1];
                }
                for (int j = cursor.size + 1; j > i + 1; j--)
                {
                    cursor.ptr[j] = cursor.ptr[j - 1];
                }
                cursor.key[i] = x;
                cursor.size++;
                cursor.ptr[i + 1] = child;
            }
            else
            {
                Node newInternal = new Node();
                int[] virtualKey = new int[M.MAX + 1];
                Node[] virtualPtr = new Node[M.MAX + 2];
                int i;
                for (i = 0; i < M.MAX; i++)
                {
                    virtualKey[i] = cursor.key[i];
                }
                for (i = 0; i < M.MAX + 1; i++)
                {
                    virtualPtr[i] = cursor.ptr[i];
                }
                i = 0;
                int j;
                while (x > virtualKey[i] && i < M.MAX)
                {
                    i++;
                }
                for (j = M.MAX + 1; j > i; j--)
                {
                    virtualKey[j-1] = virtualKey[j - 2];
                }
                virtualKey[i] = x;
                for (j = M.MAX + 2; j > i + 1; j--)
                {
                    virtualPtr[j-1] = virtualPtr[j - 2];
                }
                virtualPtr[i + 1] = child; // connect the node to its pointer.
                newInternal.IS_LEAF = false;
                cursor.size = (M.MAX + 1) / 2;
                newInternal.size = M.MAX - (M.MAX + 1) / 2;
                //take copies
                for (i = 0, j = cursor.size + 1; i < newInternal.size; i++, j++)
                {
                    newInternal.key[i] = virtualKey[j];
                }
                for (i = 0, j = cursor.size + 1; i < newInternal.size + 1; i++, j++)
                {
                    newInternal.ptr[i] = virtualPtr[j];
                }
                if (cursor == root)
                {
                    Node newRoot = new Node();
                    newRoot.key[0] = cursor.key[cursor.size];
                    newRoot.ptr[0] = cursor;
                    newRoot.ptr[1] = newInternal;
                    newRoot.IS_LEAF = false;
                    newRoot.size = 1;
                    root = newRoot;
                }
                else
                {
                    insertInternal(cursor.key[cursor.size], findParent(root, cursor), newInternal);
                }
            }
        }

        public Node findParent(Node cursor, Node child)
        {
            //Node parent
            if (cursor.IS_LEAF || (cursor.ptr[0]).IS_LEAF)
            {
                return null;
            }
            for (int i = 0; i < cursor.size + 1; i++)
            {
                if (cursor.ptr[i] == child)
                {
                    parent = cursor;
                    return parent;
                }
                else
                {
                    parent = findParent(cursor.ptr[i], child);
                    if (parent != null)
                    {
                        return parent;
                    }
                }
            }
            return parent;
        }

        public void search(int x)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty\n");
            }
            else
            {
                Node cursor = root;
                while (cursor.IS_LEAF == false)
                {
                    for (int i = 0; i < cursor.size; i++) //search for the node
                    {
                        if (x < cursor.key[i])
                        {
                            cursor = cursor.ptr[i];
                            break;
                        }
                        if (i == cursor.size - 1)
                        {
                            cursor = cursor.ptr[i + 1];
                            break;
                        }
                    }
                }
                for (int i = 0; i < cursor.size; i++) //search for the value
                {
                    if (cursor.key[i] == x)
                    {
                        Console.WriteLine("Found\n");
                        return;
                    }
                }
                Console.WriteLine("Not found\n");
            }
        }

        public void display(Node cursor)
        {
            if (cursor != null)
            {
                for (int i = 0; i < cursor.size; i++)
                {
                    Console.Write(cursor.key[i]);
                    Console.Write(" ");
                }
                Console.WriteLine("\n"+"-----------------------");
                if (cursor.IS_LEAF != true)
                {
                    for (int i = 0; i < cursor.size + 1; i++)
                    {
                        display(cursor.ptr[i]);
                    }
                }
            }
        }

        public Node getRoot()
        {
            return root;
        }
    }
    class Program
    {
        static void Main()
        {
            BPtree myTree = new BPtree();
            
            myTree.insert(5);
            myTree.insert(15);
            myTree.insert(25);
            myTree.insert(35);
            myTree.insert(45);
            myTree.insert(55);
            myTree.insert(40);
            myTree.insert(30);
            myTree.insert(20);
            myTree.display(myTree.getRoot());
            myTree.search(15);
        }
    }
}