namespace TplLesson05
{
    internal class Program
    {
        static object consoleLock = new object();

        static void Main(string[] args)
        {
            Task<string> t1 = Task.Run(() => PrintNumbers(10, 1));
            Task<string> t2 = Task.Run(() => PrintNumbers(10, 2));
            Task<string> t3 = Task.Run(() => PrintNumbers(10, 3));
            

            var task = Task.WhenAll<string>(new Task<string>[] {t1, t2, t3 });
            Console.WriteLine(task.Result[0]);
            Console.WriteLine(task.Result[1]);
            Console.WriteLine(task.Result[2]);
        }

        public static string PrintNumbers(int n, int t)
        {

            string numbers = "";
            int progress = 0;
            for (int i = 0; i < n; i++)
            {
                
                numbers = numbers + i + ", ";
                progress = progress + (100 / n);
                lock (consoleLock)
                {
                    Console.SetCursorPosition(0, t-1);
                    Console.Write($"\rProgress in {t}: {progress} %");
                }
                
                Thread.Sleep(500 * t);
            }
            Console.WriteLine();
            return numbers;
        }
    }
}
