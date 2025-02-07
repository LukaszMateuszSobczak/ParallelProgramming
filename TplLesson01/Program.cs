namespace TplLesson01
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Task mysTask = new Task(() =>       //action base task
            {

            });

            mysTask.Start();

            Task myTask2 = new Task<int>(() =>      //func base task
            {
                Thread.Sleep(2000);
                return 10;
            });

            myTask2.Start();

        }

    }
}
