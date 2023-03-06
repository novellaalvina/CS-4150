using System.IO;
using System.Collections.Generic;
using System;

namespace PS24
{
    public class Program
    {
        public static string path = "";

        public class Node
        {
            public int val;
            public int id;
            public Node left;
            public Node right;

            public Node(int val, int id, Node left, Node right)
            {
                this.val = val;
                this.id = id;
                this.left = left;
                this.right = right;
            }
        }

        public static Node insert(Node root, int counter, int node)
        {
            if (root == null)
            {
                path += counter;
                return new Node(node, counter, null, null);
            }

            else
            {
                if (root.val == node)
                {
                    return root;
                }

                if (node < root.val)
                {
                    counter = 2 * root.id + 1;
                    root.left = insert(root.left, counter, node);
                }

                else if (node > root.val)
                {
                    counter = 2 * root.id + 2;
                    root.right = insert(root.right, counter, node);
                }

            }
            return root;
        }

        public static void Main(string[] args)
        {
            string nk_str;
            nk_str = Console.ReadLine();

            string[] nk_str_sp = nk_str.Split();

            int[] nk = Array.ConvertAll(nk_str_sp, int.Parse);

            int n = nk[0];
            int k = nk[1];

            int[,] tree_list = new int[n, k];

            HashSet<string> shapes = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string tree_read = Console.ReadLine();
                string[] tree_lst = tree_read.Split();
                int[] tree_lst_int = Array.ConvertAll(tree_lst, int.Parse);

                Node root = new Node(tree_lst_int[0], 0, null, null);

                for (int j = 1; j < k; j++)
                {
                    root = insert(root, 0, tree_lst_int[j]);
                }

                char[] charArray = path.ToCharArray();
                Array.Sort(charArray);
                shapes.Add(new string(charArray));
                path = "";
            }

            Console.WriteLine(shapes.Count);
        }
    }

}

