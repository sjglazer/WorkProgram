using CargoManagementService.Enums;
using CargoManagementService.Interfaces;
namespace CargoManagementService.Services

{
    internal class FlightManager : IFlightManager
    {
        // Definitely some concurrency issues here if we were in a 
        // multi-threaded environment
        private readonly List<Flight> _flights = new List<Flight>();

        public void AddFlight(Flight flight)
        {
            _flights.Add(flight);
        }

        public void LoadBox(AirportEnum destination)
        {
            // get the earliest available flight with room for the cargo and add the box
            var flight =
                _flights.Where(flight => flight.DestinationLocation == destination && !flight.IsAtMaxCapacity())
                .OrderBy(x => x.DepartureTime)
                .FirstOrDefault();
            
            if(flight != null)
            {
                flight.AddBox();
            }
        }

        public IEnumerable<IFlight> GetOrderedFlights()
        {
            return _flights.OrderBy(flight => flight.DepartureTime).ThenBy(x => x.GetPlane().Id);
        }
    }
}
