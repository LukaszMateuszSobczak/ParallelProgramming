namespace ExampleExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double>[] data = new List<double>[99];


            Parallel.For(0, 99, i =>
            {
                data[i] = Temps();
            });
            Task.WaitAll();

            int i = 1;
            foreach (var d in data)
            {
                Console.WriteLine($"City {i}");
                foreach (double x in d)
                {
                    Console.Write(x + ", ");
                }
                Console.WriteLine();
                i++;
            }


        }

        private static List<double> Temps()
        {
            List<double> list = new List<double>();
            Random random = new Random();
            for (int i = 0; i < 365; i++)
            {
                double temp = random.NextDouble() * 25;
                list.Add(Math.Round(temp, 1));
            }
            return list;
        }


    }
}
