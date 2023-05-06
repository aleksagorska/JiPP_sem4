namespace Zadanie5
{
    internal class District
    {
        public string name { get; }
        public List<Street> streets { get; }

        public District(string name)
        {
            this.name = name;
            this.streets = new List<Street>();
        }

        public void addStreet(Street street)
        {
            streets.Add(street);
        }
    }
}
