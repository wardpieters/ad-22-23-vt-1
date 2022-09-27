namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FirstChildNextSiblingNode<T> root;

        public IFirstChildNextSiblingNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            if (root == null)
            {
                return 0;
            }
            
            int size = 0;
            var node = root;
            
            while (node != null)
            {
                size++;

                if (IsEmpty(node.firstChild))
                {
                    size++;
                    node = node.nextSibling;
                } else {
                    node = node.firstChild;
                }
            }

            return size;
        }

        private bool IsEmpty(FirstChildNextSiblingNode<T> node)
        {
            return node?.firstChild == null && node?.nextSibling == null;
        }

        public void PrintPreOrder()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            if (root == null)
            {
                return "NIL";
            }
            
            return $"{root.data},FC({root.firstChild.data}),NS({root.nextSibling.data})";
        }
    }
}