namespace AD
{
    public partial class Hoger1000
    {
        public static int ZoekHoger1000(int n)
        {
            if (n > 1000)
            {
                return n;
            }

            return ZoekHoger1000(n * 7);
        }

        static void Main(string[] args)
        {
            int[] values = { 1, 4, 12, 143, 500, 1000, 1001 };
            foreach (int val in values)
                System.Console.WriteLine($"ZoekHoger1000({val,4}) = {ZoekHoger1000(val)}");

        }
    }
}
