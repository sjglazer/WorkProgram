using CargoManagementService.Enums;

namespace CargoManagementService.Models
{
    internal record ScheduledOrder
    {
        public AirportEnum Departure { get; set; }
        public AirportEnum Destination { get; set; }
        public string Name { get; set; } = string.Empty;
        public int FlightNumber { get; set; }  
        public DayEnum Day { get; set; }
        public bool WasLoaded { get; set; }

        public override string ToString()
        {
            return
                $"Order: {Name}, flightNumber: {FlightNumber}, departure: {Departure}, arrival: {Destination}, day: {(int)Day}";
        }
    }
}
