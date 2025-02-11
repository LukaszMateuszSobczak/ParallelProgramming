namespace ExampleExercise01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CityTemp> cities = new List<CityTemp>();

            int steps = 99;
            int completedSteps = 0;

            Parallel.For(0, 99, i =>
            {
                cities.Add(new CityTemp());
                int progress = Interlocked.Increment(ref completedSteps);
                Console.Write($"\rProgress of creating new data: {progress}%");
            });

            Task.WaitAll();
            Console.Clear();
            completedSteps = 0;

            Parallel.ForEach(cities, elem =>
            {
                elem.ProcessData();
                int progress = Interlocked.Increment(ref completedSteps);
                Console.Write($"\rProgress of analyzing data: {progress}%");
                Thread.Sleep(1000);
            });

            Task.WaitAll();
            Console.Clear();



            int i = 1;
            foreach (var city in cities)
            {
                Console.Write($"City {i} temps: ");
                foreach (var temp in city.temperatures)
                {
                    Console.Write($" {temp}| ");
                }
                Console.WriteLine();
                Console.WriteLine($"Mediana: {Math.Round(city.mediana, 2)}");
                Console.WriteLine($"Max temp: {city.maxTemp}");
                Console.WriteLine($"Min temp: {city.minTemp}");
                Console.WriteLine();
                Console.WriteLine("============================================");
                i++;
            }
        }


    }
}
