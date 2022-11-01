namespace AD
{
    public partial class KwadratenStrings
    {
        public static string KwadratenString(int n)
        {
            if(n < 0) return "_";
            
            return KwadratenString(n - 1) + (n * n) + "_";
        }
        
        static void Main(string[] args)
        {
            int[] values = { -9, -1, 0, 1, 3, 9, 12 };
            foreach (int val in values)
                System.Console.WriteLine($"KwadratenString({val,2}) = {KwadratenString(val)}");
        }
    }
}
