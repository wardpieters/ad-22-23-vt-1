namespace AD
{
    public partial class FirstChildNextSiblingNode<T> : IFirstChildNextSiblingNode<T>
    {
        public FirstChildNextSiblingNode<T> firstChild;
        public FirstChildNextSiblingNode<T> nextSibling;
        public T data;

        public FirstChildNextSiblingNode(T _data, FirstChildNextSiblingNode<T> _firstChild, FirstChildNextSiblingNode<T> _nextSibling): this(_data, _firstChild)
        {
            nextSibling = _nextSibling;
        }

        public FirstChildNextSiblingNode(T _data, FirstChildNextSiblingNode<T> _firstChild): this(_data)
        {
            firstChild = _firstChild;
        }

        public FirstChildNextSiblingNode(T _data)
        {
            data = _data;
        }

        public T GetData()
        {
            return data;
        }

        public FirstChildNextSiblingNode<T> GetFirstChild()
        {
            return firstChild;
        }

        public FirstChildNextSiblingNode<T> GetNextSibling()
        {
            return nextSibling;
        }
    }
}