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
        
        private void RemoveMin(BinaryNode<T> node)
        {
            if (node.left.left == null)
            {
                node.left = node.left.right;
            }
            else
            {
                RemoveMin(node.left);
            }
        }

        public void Remove(T x)
        {
             Remove(x, root);
        }

        private void Remove(T x, BinaryNode<T> node)
        {
            if (node == null)
            {
                throw new BinarySearchTreeElementNotFoundException();
            }

            if (x.Equals(node.data))
            {
                if (node.right == null)
                {
                    node.right = node.left.right;
                    node.data = node.left.data;
                    node.left = node.left.left;
                }
                
                T min = FindMin(node.right);
                RemoveMin(node);

                node.data = min;
            }
            else
            {
                if (x.CompareTo(node.data) > 0)
                {
                    Remove(x, node.right);
                }
                else if (x.CompareTo(node.data) < 0)
                {
                    Remove(x, node.left);
                }
            }
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
