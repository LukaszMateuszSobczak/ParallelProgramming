namespace ThreadPoolLesson
{

    class ThreadPoolExample
    {
        private void PrintNumbers(object obj)
        {
            //int nmb = Convert.ToInt32(state);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + ", ");
            }

            ((ManualResetEvent)obj).Set();  //Powiadomienie o zakończeniu wątku
        }

        public void RunParallel()
        {
            Console.WriteLine("Start task");

            ManualResetEvent doneEvent1 = new ManualResetEvent(false);  //dzieki temu czekamy na wątek
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintNumbers), doneEvent1);
            doneEvent1.WaitOne(); //czeka na zakonczenie wątka
            
            Console.WriteLine("End task");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var tp = new ThreadPoolExample();
            tp.RunParallel();
        }
    }
}
