namespace AD
{
    public partial class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T> where T : System.IComparable<T>
    {
        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public void Insert(T x)
        {
            if (root == null)
            {
                root = new BinaryNode<T> { data = x };
            } else Insert(x, root);
        }

        private void Insert(T x, BinaryNode<T> node)
        {
            if (x.Equals(node.data))
            {
                throw new BinarySearchTreeDoubleKeyException();
            }

            if (x.CompareTo(node.data) > 0)
            {
                if (node.right == null)
                {
                    node.right = new BinaryNode<T> {data = x};
                }
                else
                {
                    Insert(x, node.right);
                }
            }
            else
            {
                if (node.left == null)
                {
                    node.left = new BinaryNode<T> {data = x};
                }
                else
                {
                    Insert(x, node.left);
                }
            }
        }

        public T FindMin()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMin()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(T x)
        {
            throw new System.NotImplementedException();
        }

        public string InOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}