namespace Zadanie5
{
    internal class Street
    {
        public string name { get; }
        private District district;
        public Coordinates start { get; }
        public Coordinates end { get; }
        public List<Car> cars { get; }

        internal Street(string name, Coordinates start, Coordinates end, District district) 
        {
            this.name = name;
            this.start = start;
            this.end = end;
            this.district = district;
            cars = new List<Car>();
        }
        internal string getDistrict()
        {
            return district.name;
        }

        internal void addCar(Car car)
        {
            cars.Add(car);
        }

        internal void removeCar(Car car)
        {
            cars.Remove(car);
        }
    }
}
