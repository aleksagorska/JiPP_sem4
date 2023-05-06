namespace Zadanie5
{
    internal class Car
    {
        public string plateNumber { get; }

        private double currentPosX;
        private double currentPosY;
        private double velocity; // W kilometrach na godzinę

        private Street street;

        private Coordinates previousLocation;
        public Coordinates destination { get; }

        public Car(string licencePlate, Street startingStreet, bool fromStartToEnd, double velocityInKph)
        {
            plateNumber = licencePlate;
            velocity = velocityInKph;

            street = startingStreet;
            if (fromStartToEnd) // True - samochód jedzie od punktu "start" do punktu "end" ulicy; False - odwrotnie
            {
                previousLocation = street.start;
                destination = street.end;
            }
            else
            {
                previousLocation = street.end;
                destination = street.start;
            }

            currentPosX = previousLocation.x;
            currentPosY = previousLocation.y;

            startingStreet.addCar(this);
        }

        // Zwraca true, jeśli samochód dojechał do bieżącego celu i trzeba mu ustawić nowy cel
        public bool moveCar()
        {
            double distanceTraveled = ((velocity / 3600) * 1000) / 30; // W metrach
            double distanceToDestination = Math.Sqrt(Math.Pow((destination.x - currentPosX), 2) 
                + Math.Pow((destination.y - currentPosY), 2)); // W metrach

            // Między 0 a 1 oznacza, że punkt jest na linii. Większe lub równe 1 oznacza, że albo dotarliśmy do celu, albo go "przestrzeliliśmy" 
            double ratio = distanceTraveled / distanceToDestination;
            bool reachedDestination = (ratio >= 1);
            if (reachedDestination)
            {
                currentPosX = destination.x;
                currentPosY = destination.y;
                return true;
            }
            else
            {
                currentPosX = ((1 - ratio) * currentPosX + ratio * destination.x);
                currentPosY = ((1 - ratio) * currentPosY + ratio * destination.y);
                return false;
            }
        }
        public void setNewStreet(Street street)
        {
            this.street.removeCar(this);
            this.street = street;

            previousLocation = destination;
            if (destination.x == street.start.x && destination.y == street.start.y)
            {
                destination.x = street.end.x;
                destination.y = street.end.y;
            }
            else
            {
                destination.x = street.start.x;
                destination.y = street.start.y;
            }
            street.addCar(this);

            Random rnd = new Random();
            velocity = rnd.NextDouble() * 80 + 20; // Wylosuj nową prędkość z zakresu 20 do 100 km/h
        }

        public void showCurrentStatus()
        {
            Console.WriteLine("Samochód: " + plateNumber +
                ", \tprędkość: " + String.Format("{0:0.00} km/h", velocity) +
                ", lokalizacja: (" + String.Format("{0:0.00}", currentPosX) + ", " + String.Format("{0:0.00}", currentPosY) + ")" +
                ", dzielnica: " + street.getDistrict() +
                ", ulica: " + street.name);
        }
    }
}
