namespace AD
{
    //
    // This class offers static methods to create datastructures.
    // It is called by unit tests.
    //
    public partial class DSBuilder
    {
        public static IFirstChildNextSibling<string> CreateFirstChildNextSibling_Empty ()
        {
            FirstChildNextSibling<string> tree = new FirstChildNextSibling<string> ();
            return tree;
        }

        public static IFirstChildNextSibling<string> CreateFirstChildNextSibling_Small ()
        {
            FirstChildNextSibling<string> tree = new FirstChildNextSibling<string> ();

            FirstChildNextSiblingNode<string> e = new FirstChildNextSiblingNode<string>("e");
            FirstChildNextSiblingNode<string> d = new FirstChildNextSiblingNode<string>("d");
            FirstChildNextSiblingNode<string> c = new FirstChildNextSiblingNode<string>("c", null, d);
            FirstChildNextSiblingNode<string> b = new FirstChildNextSiblingNode<string>("b", e, c);
            FirstChildNextSiblingNode<string> a = new FirstChildNextSiblingNode<string>("a", b, null);

            tree.root = a;

            return tree;
        }

        public static IFirstChildNextSibling<string> CreateFirstChildNextSibling_SmallV2()
        {
            FirstChildNextSibling<string> tree = new FirstChildNextSibling<string> ();

            FirstChildNextSiblingNode<string> l = new FirstChildNextSiblingNode<string>("l");
            FirstChildNextSiblingNode<string> k = new FirstChildNextSiblingNode<string>("k", null, l);
            FirstChildNextSiblingNode<string> j = new FirstChildNextSiblingNode<string>("j", null, k);
            FirstChildNextSiblingNode<string> i = new FirstChildNextSiblingNode<string>("i", null, j);
            FirstChildNextSiblingNode<string> h = new FirstChildNextSiblingNode<string>("h", i);
            FirstChildNextSiblingNode<string> g = new FirstChildNextSiblingNode<string>("g", h);
            FirstChildNextSiblingNode<string> f = new FirstChildNextSiblingNode<string>("f", g);
            FirstChildNextSiblingNode<string> e = new FirstChildNextSiblingNode<string>("e", null, f);
            FirstChildNextSiblingNode<string> d = new FirstChildNextSiblingNode<string>("d", e);
            FirstChildNextSiblingNode<string> c = new FirstChildNextSiblingNode<string>("c", d);
            FirstChildNextSiblingNode<string> b = new FirstChildNextSiblingNode<string>("b", c);
            FirstChildNextSiblingNode<string> a = new FirstChildNextSiblingNode<string>("a", b);

            tree.root = a;

            return tree;
        }

        public static IFirstChildNextSibling<string> CreateFirstChildNextSibling_18_3 ()
        {
            throw new System.NotImplementedException();
        }
    }
}