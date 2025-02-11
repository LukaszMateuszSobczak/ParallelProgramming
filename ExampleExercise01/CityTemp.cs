namespace ExampleExercise01
{
    internal class CityTemp
    {

        public List<double> temperatures;
        public double mediana;
        public double minTemp;
        public double maxTemp;


        public CityTemp()
        {
            InitializeTemperatures();
        }

        public void ProcessData()
        {
            mediana = CalcualteMediana();
            maxTemp = MaxValue();
            minTemp = MinValue();
        }

        private void InitializeTemperatures()
        {
            temperatures = new List<double>();

            Parallel.For(0, 365, i =>
            {
                lock (temperatures)
                {
                    Random random = new Random();
                    temperatures.Add(RandomTemperature(random));
                }
            });


        }

        private double RandomTemperature(Random random)
        {

            double temp = random.NextDouble() * 40 - 10;
            temp = Math.Round(temp, 1);
            return temp;
        }

        private double CalcualteMediana()
        {
            int middleElement = temperatures.Count / 2;
            if (temperatures.Count % 2 != 0)
            {
                return temperatures[middleElement];
            }
            else
            {
                double tmp = (temperatures[middleElement] + temperatures[middleElement - 1]) / 2;
                return tmp;
            }
        }

        private double MinValue()
        {
            return temperatures.Min();
        }

        private double MaxValue()
        {
            return temperatures.Max();
        }





    }
}
