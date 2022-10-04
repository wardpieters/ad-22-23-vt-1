using System;

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
            var result = Traverse(root);

            return result;
        }

        private int Traverse(FirstChildNextSiblingNode<T> node, int count = 0)
        {
            if (node == null) return count;

            while (node != null)
            {
                var newCount = count + 1;
                
                if (node.firstChild != null)
                {
                    newCount = Traverse(node.firstChild, count + 1);
                }

                count = newCount;
                
                node = node.nextSibling;
            }

            return count;
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

            return ToString(root);
        }
        
        private string ToString(FirstChildNextSiblingNode<T> node)
        {
            if (node == null) return "";

            string output = $"{node.data}";
            if (node.firstChild != null)
            {
                output += $",FC({ToString(node.firstChild)})";
            }
            if (node.nextSibling != null)
            {
                output += $",NS({ToString(node.nextSibling)})";
            }

            return output; }
    }
}