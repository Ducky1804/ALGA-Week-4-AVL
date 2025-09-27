using System;
using System.Xml.Serialization.Configuration;

namespace ALGA
{
    public class Node
    {
        public int number;

        public Node left, right;

        public Node(int number)
        {
            this.number = number;
        }

        public Node rotateLeft()
        {
            Node pivot = right;
            right = pivot.left;
            pivot.left = this;
            return pivot;
        }

        public Node rotateRight()
        {
            Node pivot = left;
            left = pivot.right;
            pivot.right = this;
            return pivot;
        }

        public void prettyprint(String firstPrefix, String prefix)
        {
            Console.WriteLine(firstPrefix + number);

            if (right == null)
            {
                Console.WriteLine(prefix + "├── .");
            }
            else
            {
                right.prettyprint(prefix + "├── ", prefix + "|   ");
            }

            if (left == null)
            {
                Console.WriteLine(prefix + "└── .");
            }
            else
            {
                left.prettyprint(prefix + "└── ", prefix + "    ");
            }
        }
        
        public int GetBalanceFactor()
        {
            int leftDepth = left?.GetDepth() ?? 0;
            int rightDepth = right?.GetDepth() ?? 0;
            return leftDepth - rightDepth;
        }

        public int GetDepth()
        {
            int leftDepth = left?.GetDepth() ?? 0;
            int rightDepth = right?.GetDepth() ?? 0;
            return Math.Max(leftDepth, rightDepth) + 1;
        }

        public Node insert(int number)
        {
            if (number == this.number)
                return this;
            
            if (number < this.number)
            {
                left = left != null ? left.insert(number) : new Node(number);
            }
            else
            {
                right = right != null ? right.insert(number) : new Node(number);
            }
            
            int balance = GetBalanceFactor();
            if (balance > 1)
            {
                if (number < left.number)
                    return rotateRight();
                else
                {
                    left = left.rotateLeft();
                    return rotateRight();
                }
            }
            if (balance < -1)
            {
                if (number > right.number)
                    return rotateLeft();
                else
                {
                    right = right.rotateRight();
                    return rotateLeft();
                }
            }

            return this;
        }
    }
}
