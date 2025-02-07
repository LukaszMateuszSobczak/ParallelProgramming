
namespace TplLesson02
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            //DoTpl();

            Task<Bitmap> processBitmap = Task.Factory.StartNew<Bitmap>(() =>
            {
                string imagePath = "myimage.png";
                Console.WriteLine("process 1");
                return ApplyFilters(imagePath);
            });
            Task<Bitmap> processBitmap1 = Task.Factory.StartNew<Bitmap>(() =>
            {
                string imagePath = "myimage.png";
                Console.WriteLine("process 2");
                return ApplyFilters(imagePath);
            });


            await processBitmap1;
            




            //Task<Bitmap> processBitmap = new Task<Bitmap>(() =>
            //{
            //    string imagePath = "myimage.png";
            //    return ApplyFilters(imagePath);
            //});

            //processBitmap.Start();
            //processBitmap.Wait();
        }

        private static Bitmap ApplyFilters(string imagePath)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Processing is done");
            return new Bitmap() { Name = "randomName" };
        }

        private static async void DoTpl()  //główny wątek nie poczeka
        {
            Task<Bitmap> task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Process is done");
                return new Bitmap() { Name = "new" };
            });

            await task;
        }
    }
}
