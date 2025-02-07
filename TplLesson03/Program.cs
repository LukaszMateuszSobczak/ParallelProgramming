namespace TplLesson03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task<string> task = Task.Run(() => PrintNumbers(100000), token);

            cts.Cancel();

            if (!task.IsCanceled)
            {
                Console.WriteLine(task.Result);
            }
        }

        private static string PrintNumbers(int a)
        {
            string text = "";
            for (int i = 0; i < a; i++)
            {
                text = text + i;
            }
            return text;
        }
    }
}
