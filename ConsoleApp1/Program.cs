namespace TplLesson06
{
    internal class Program
    {
        public static object console = new object();

        static void Main(string[] args)
        {

            Console.WriteLine(PrintNumbers(10, 1));

        }

        public static string PrintNumbers(int n, int t)
        {

            string numbers = "";
            int progress = 0;
            Parallel.For(0, n, i =>
               {
                   Console.WriteLine(i);
                   Console.WriteLine
               });

            return numbers;
        }
    }
}
