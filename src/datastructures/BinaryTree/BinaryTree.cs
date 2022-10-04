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
            return Size() == 0;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {
            var merged = MergeBinaryNodes(t1.GetRoot(), t2.GetRoot());
            root = new BinaryNode<T>( rootItem, merged.left, merged.right );
        }
        
        private BinaryNode<T> MergeBinaryNodes(BinaryNode<T> t1, BinaryNode<T> t2)
        {
            if (t1 == null)
            {
                return t2;
            }
            
            if (t2 == null)
            {
                return t1;
            }
            
            t1.left = MergeBinaryNodes(t1.left, t2.left);
            t1.right = MergeBinaryNodes(t1.right, t2.right);
            return t1;
        }

        public string ToPrefixString()
        {
            if (root == null)
            {
                return "NIL";
            }
            
            throw new System.NotImplementedException();
        }

        public string ToInfixString()
        {
            if (root == null)
            {
                return "NIL";
            }
            
            throw new System.NotImplementedException();
        }

        public string ToPostfixString()
        {
            if (root == null)
            {
                return "NIL";
            }
            
            throw new System.NotImplementedException();
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            throw new System.NotImplementedException();
        }

        public int NumberOfNodesWithOneChild()
        {
            throw new System.NotImplementedException();
        }

        public int NumberOfNodesWithTwoChildren()
        {
            throw new System.NotImplementedException();
        }
    }
}