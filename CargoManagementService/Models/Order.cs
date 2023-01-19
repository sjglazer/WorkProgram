using CargoManagementService.Enums;

namespace CargoManagementService.Models
{
    internal record Order
    {
       public Order(string name, AirportEnum departure, AirportEnum destination)
       {
            Departure = departure;
            Destination = destination;
            Name = name;
        }

        public AirportEnum Departure { get; }
        public AirportEnum Destination { get; }
        public string Name { get;} = string.Empty;
    }
}
