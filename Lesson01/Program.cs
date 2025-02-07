namespace Lesson01
{

    class ThreadExample
    {
        private void PrintNumber(object a)
        {
            int b = Convert.ToInt32(a);
            for (int i = 0; i < b; i++)
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine();
        }

        public void RunParellel()
        {
            Console.WriteLine("Run paralell task");

            var threadStart = new ParameterizedThreadStart(PrintNumber);
            Thread thread = new Thread(threadStart);
            thread.Start(12);
            Console.WriteLine("End parallel task");

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var te = new ThreadExample();
            te.RunParellel();
        }
    }
}
