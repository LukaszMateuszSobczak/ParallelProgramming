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
            for (int i = 0; i < 365; i++)
            {
                Thread thread = new Thread(() =>
                {
                    lock (temperatures)
                    {
                        temperatures.Add(RandomTemperature());
                    }
                });
                thread.Start();
            }
        }

        private double RandomTemperature()
        {
            Random random = new Random();
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
