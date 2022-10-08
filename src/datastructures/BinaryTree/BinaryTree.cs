using System;

namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(T rootItem)
        {
            root = new BinaryNode<T> {data = rootItem};
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            return Size(root);
        }

        private int Size(BinaryNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return Size(node.left) + Size(node.right) + 1;
        }

        public int Height()
        {
            return Height(root) - 1;
        }

        private int Height(BinaryNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            
            int lDepth = Height(node.left);
            int rDepth = Height(node.right);

            // Return the biggest of the both
            return Math.Max(lDepth, rDepth) + 1;
        }

        public void MakeEmpty()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            root = new BinaryNode<T>( rootItem, t1.root, t2.root );
        }
        
        public string ToPrefixString()
        {
            return ToPrefixString(root);
        }
        
        private string ToPrefixString(BinaryNode<T> node)
        {
            if (node == null)
            {
                return "NIL";
            }

            return $"[ {node.data.ToString()} {ToPrefixString(node.left)} {ToPrefixString(node.right)} ]";
        }

        public string ToInfixString()
        {
            return ToInfixString(root);
        }

        public string ToInfixString(BinaryNode<T> node)
        {
            if (node == null)
            {
                return "NIL";
            }
            
            return $"[ {ToInfixString(node.left)} {node.data.ToString()} {ToInfixString(node.right)} ]";
        }

        public string ToPostfixString()
        {
            return ToPostfixString(root);
        }

        private string ToPostfixString(BinaryNode<T> node)
        {
            if (node == null)
            {
                return "NIL";
            }
            
            return $"[ {ToPostfixString(node.left)} {ToPostfixString(node.right)} {node.data.ToString()} ]";
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            return NumberOfLeaves(root);
        }
        
        private int NumberOfLeaves(BinaryNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.left == null && node.right == null)
            {
                return 1;
            }

            return NumberOfLeaves(node.left) + NumberOfLeaves(node.right);
        }

        public int NumberOfNodesWithOneChild()
        {
            return NumberOfNodesWithOneChild(root);
        }
        
        private int NumberOfNodesWithOneChild(BinaryNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.left == null && node.right != null)
            {
                return 1 + NumberOfNodesWithOneChild(node.right);
            }

            if (node.left != null && node.right == null)
            {
                return 1 + NumberOfNodesWithOneChild(node.left);
            }

            return NumberOfNodesWithOneChild(node.left) + NumberOfNodesWithOneChild(node.right);
        }

        public int NumberOfNodesWithTwoChildren()
        {
            return NumberOfNodesWithTwoChildren(root);
        }
        
        private int NumberOfNodesWithTwoChildren(BinaryNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.left != null && node.right != null)
            {
                return 1 + NumberOfNodesWithTwoChildren(node.left) + NumberOfNodesWithTwoChildren(node.right);
            }

            return NumberOfNodesWithTwoChildren(node.left) + NumberOfNodesWithTwoChildren(node.right);
        }
    }
}