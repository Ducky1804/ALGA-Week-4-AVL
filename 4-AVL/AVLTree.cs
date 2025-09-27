using System;

namespace ALGA
{
    public class AVLTree
    {
        public Node root;

        public void insert(int number)
        {
            if (root == null)
                root = new Node(number);
            else
                root = root.insert(number);
        }

        public bool isBalanced()
        {
            if (root == null)
                return true;

            int balance = root.GetBalanceFactor();
            return balance >= -1 && balance <= 1;
        }

        public void prettyprint()
        {
            if (root != null)
            {
                root.prettyprint("→", " ");
            }
        }
    }
}
