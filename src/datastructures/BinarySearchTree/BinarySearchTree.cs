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
            return FindMin(root);
        }

        private T FindMin(BinaryNode<T> node)
        {
            if (node == null)
            {
                throw new BinarySearchTreeEmptyException();
            }
            
            if (node.left == null)
            {
                return node.data;
            }
            
            return FindMin(node.left);
        }

        public void RemoveMin()
        {
            if (root == null)
            {
                throw new BinarySearchTreeEmptyException();
            }

            if (root.left == null)
            {
                root = root.right;
            }
            else
            {
                RemoveMin(root);
            }
        }
        
        private BinaryNode<T> RemoveMin(BinaryNode<T> node)
        {
            if (node.left == null && node.right == null)
            {
                return null;
            }

            if (node.left == null)
            {
                return node.right;
            }

            node.left = RemoveMin(node.left);

            return node;
        }

        public void Remove(T x)
        {
             root = Remove(x, root);
        }

        private BinaryNode<T> Remove(T x, BinaryNode<T> node)
        {
            if (node == null)
            {
                throw new BinarySearchTreeElementNotFoundException();
            }

            if (x.Equals(node.data))
            {
                return RemoveThisNode(node);
            }

            if (x.CompareTo(node.data) > 0)
            {
                node.right = Remove(x, node.right);
            }

            if (x.CompareTo(node.data) < 0)
            {
                node.left = Remove(x, node.left);
            }

            return node;
        }
        
        private BinaryNode<T> RemoveThisNode(BinaryNode<T> node)
        {
            if (node.left == null && node.right == null)
            {
                return null;
            }

            if (node.left == null)
            {
                return node.right;
            }

            if (node.right == null)
            {
                return node.left;
            }

            return new BinaryNode<T>(FindMin(node.right), node.left, RemoveMin(node.right));
        }

        public string InOrder()
        {
            return InOrder(root);
        }

        private string InOrder(BinaryNode<T> node)
        {
            if (node == null)
            {
                return "";
            }

            return $"{InOrder(node.left)} {node.data} {InOrder(node.right)}".Trim();
        }

        public override string ToString()
        {
            return InOrder();
        }
    }
}
