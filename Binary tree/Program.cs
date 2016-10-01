using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{

    class Program
    {

        static BinaryTree treeHead = new BinaryTree();

        static void Main(string[] args)
        {

            string input;

            do
            {

                input = Console.ReadLine();
                if (input[0] == 'a')
                {

                    input = input.Substring(1);
                    treeHead.insertValue(int.Parse(input));

                }

                else if (input[0] == 'd')
                {

                    input = input.Substring(1);
                    treeHead.removeValue(int.Parse(input));

                }

                else if (input[0] == 'h')
                {

                    Console.WriteLine("Highest value: " + treeHead.getHighestNode().value);

                }

                else if (input[0] == 'l')
                {

                    Console.WriteLine("Lowest value: " + treeHead.getLowestNode().value);

                }

            }
            while (true);

        }

        static void printTree(BinaryTree tree)
        {



        }

    }

}
