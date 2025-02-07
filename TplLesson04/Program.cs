namespace TplLesson04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = new CancellationToken();


            Task<string> task = Task.Run<string>(() => PrintNumbers(14), token);
            
            string input = Console.ReadLine();

            if (input == "q" || input == "Q")
            {
                cts.Cancel();
            }


            if (!cts.IsCancellationRequested)
            {
                Console.WriteLine(task.Result);
            }
            else
            {
                Console.WriteLine("Terminated");
            }

        }

        public static void PrintNumbers()
        {
            PrintNumbers(10);
        }

        public static string PrintNumbers(int n)
        {

            string numbers = "";
            int progress = 0;
            for (int i = 0; i < n; i++)
            {
                //Console.Clear();
                numbers = numbers + i + ", ";
                progress = progress + (100 / n);
                Console.Write($"\rProgress in task: {progress} %");
                Thread.Sleep(500);
            }
            Console.WriteLine();
            return numbers;
        }
    }

}
