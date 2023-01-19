using CargoManagementService.Enums;

namespace CargoManagementService.Models
{
    internal record Order
    {
       public Order(string name, AirportEnum destination) 
        {
            Destination = destination;
            Name = name;
        }
        
        public AirportEnum Destination { get; }
        public string Name { get;} = string.Empty;
    }
}
