namespace Zadanie5
{
    internal class Controller
    {
        private List<District> districts;
        private List<Car> cars;
        
        public Controller() 
        {
            districts = new List<District>();

            // Tworzymy dzielnice i ulice
            District district = new District("Dzielnica kolorowa");
            district.addStreet(new Street("Długa", new Coordinates(130, 800), new Coordinates(320, 750), district));
            district.addStreet(new Street("Długa", new Coordinates(320, 750), new Coordinates(710, 590), district));
            district.addStreet(new Street("Krótka", new Coordinates(210, 550), new Coordinates(320, 750), district));
            district.addStreet(new Street("Krótka", new Coordinates(320, 750), new Coordinates(450, 920), district));
            district.addStreet(new Street("Gdańska", new Coordinates(330, 300), new Coordinates(710, 590), district));
            district.addStreet(new Street("Gdańska", new Coordinates(710, 590), new Coordinates(1210, 870), district));
            districts.Add(district);

            district = new District("Dzielnica morska");
            district.addStreet(new Street("Warcka", new Coordinates(320, 0), new Coordinates(330, 300), district));
            district.addStreet(new Street("Rzeczna", new Coordinates(330, 300), new Coordinates(1200, 340), district));
            district.addStreet(new Street("Murarska", new Coordinates(320, 0), new Coordinates(1720, 0), district));
            district.addStreet(new Street("Zamkowa", new Coordinates(1200, 340), new Coordinates(1210, 870), district));
            districts.Add(district);

            district = new District("Bałuty");
            district.addStreet(new Street("Kilińskiego", new Coordinates(1210, 870), new Coordinates(1690, 830), district));
            district.addStreet(new Street("Biała", new Coordinates(1200, 340), new Coordinates(1720, 330), district));
            district.addStreet(new Street("Biała", new Coordinates(1720, 330), new Coordinates(1960, 290), district));
            district.addStreet(new Street("Puławskiego", new Coordinates(1690, 830), new Coordinates(1720, 330), district));
            district.addStreet(new Street("Puławskiego", new Coordinates(1720, 330), new Coordinates(1720, 0), district));
            districts.Add(district);

            // Tworzymy samochody, ustawiamy je na losowych ulicach z losową prędkością
            cars = new List<Car>();
            List<string> licencePlates = new List<string>{ 
                "ESI 48866", 
                "EL 314US", 
                "EL 9AE12", 
                "WB 9AD11", 
                "DW 1E94", 
                "EPD A445", 
                "WW E129A",
                "E1 TEST",
                "EL 12KK1",
                "EZD 9S99"};
            Random rnd = new Random();
            for(int i = 0; i < licencePlates.Count; i++)
            {
                // Losujemy ulicę
                int index = rnd.Next(getAllStreets().Count);
                Street street = getAllStreets()[index];

                // Losujemy kierunek
                bool direction = (rnd.Next(2) == 0);

                // Losujemy prędkość
                double velocity = rnd.NextDouble() * 80 + 20; // Od 20 do 100

                cars.Add(new Car(licencePlates[i], street, direction, velocity));
            }
        }

        internal void runSimulation()
        {
            int licznik = 0;
            while(true)
            {
                // W całym programie zakładamy około 30 "klatek" na sekundę
                Thread.Sleep(1000 / 30); 

                moveAllCars();

                // Raz na sekundę pokaż dane
                licznik++;
                if (licznik == 30)
                {
                    Console.Clear();

                    // Pokaż dzielnice i ulice z największą i najmniejszą ilością samochodów
                    showDistrictsWithMostAndLeastCars();
                    showStreetsWithMostAndLeastCars();

                    // Pokaż status wszystkich samochodów po tablicy rejestracyjnej
                    showCarStatus("ESI 12345");
                    showCarStatus("EL A951S");
                    showCarStatus("EL 9AE12");
                    showCarStatus("WB 9AD11");
                    showCarStatus("DW 1E94");
                    showCarStatus("EPD A445");
                    showCarStatus("WW E129A");
                    showCarStatus("E1 TEST");
                    showCarStatus("EL 12KK1");
                    showCarStatus("EZD 9S99");

                    licznik = 0;
                }
            }
        }

        private void moveAllCars()
        {
            foreach (Car c in cars)
            {
                if (c.moveCar())
                {
                    // Stwórz listę ulic, które wybiegają z danego skrzyżowania
                    List<Street> potentialStreets = new List<Street>();
                    foreach (Street s in getAllStreets())
                    {
                        if ((s.start.x == c.destination.x && s.start.y == c.destination.y) ||
                            (s.end.x == c.destination.x && s.end.y == c.destination.y))
                        {
                            potentialStreets.Add(s);
                        }
                    }

                    // Wybierz losowo nową ulicę, w którą samochód "skręci"
                    Random rnd = new Random();
                    int index = rnd.Next(potentialStreets.Count);
                    c.setNewStreet(potentialStreets[index]);
                }
            }
        }

        internal void showCarStatus(string licencePlate)
        {
            Car car = cars.Where(c => c.plateNumber == licencePlate).First();
            car.showCurrentStatus();
        }

        internal void showStreetsWithMostAndLeastCars()
        {
            List<Street> streets = getAllStreets();
            Street mostCarsStreet = streets.OrderBy(s => s.cars.Count).Last();
            Street leastCarsStreet = streets.OrderBy(s => s.cars.Count).First();
            Console.WriteLine("Ulica z największą ilością samochodów: " + mostCarsStreet.name + " (" + mostCarsStreet.cars.Count + ")");
            Console.WriteLine("Ulica z najmniejszą ilością samochodów: " + leastCarsStreet.name + " (" + leastCarsStreet.cars.Count + ")");
        }
        internal void showDistrictsWithMostAndLeastCars()
        {
            District leastCarsDistrict = new District("UNKNOWN");
            District mostCarsDistrict = new District("UNKNOWN");
            int leastCars = cars.Count();
            int mostCars = 0;
            foreach (District d in districts)
            {
                int carsTotal = 0;
                foreach (Street s in d.streets)
                {
                    carsTotal += s.cars.Count();
                }

                if (carsTotal > mostCars)
                {
                    mostCars = carsTotal;
                    mostCarsDistrict = d;
                }
                
                if (carsTotal < leastCars)
                {
                    leastCars = carsTotal;
                    leastCarsDistrict = d;
                }
            }

            Console.WriteLine("Dzielnica z największą ilością samochodów: " + mostCarsDistrict.name + " (" + mostCars + ")");
            Console.WriteLine("Dzielnica z najmniejszą ilością samochodów: " + leastCarsDistrict.name + " (" + leastCars + ")");
        }

        private List<Street> getAllStreets()
        {
            List<Street> streets = new List<Street>();
            foreach (District d in districts)
            {
                streets.AddRange(d.streets);
            }
            return streets;
        }
    }
}
