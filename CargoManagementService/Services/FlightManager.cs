using CargoManagementService.Interfaces;
using CargoManagementService.Models;
using System.Collections.Concurrent;
using CargoManagementService.Enums;
using System.Collections.Generic;

namespace CargoManagementService.Services
{
    internal class FlightManager : IFlightManager
    {
        private readonly ConcurrentDictionary< (AirportEnum Departure, AirportEnum Arrival), List<IFlight>> _flights = new();
        private readonly List<Order> _notScheduledOrders = new List<Order>();

        public void AddFlight(Flight flight)
        {
            if (_flights.TryGetValue((flight.DepartureLocation, flight.DestinationLocation), out var flights))
                flights.Add(flight);
            else
            {
                var newFlightList = new List<IFlight>() { flight };
                _flights.TryAdd((flight.DepartureLocation , flight.DestinationLocation), newFlightList);
            }
        }

        public void LoadBox(Order order)
        {
            if (_flights.TryGetValue((order.Departure, order.Destination), out var flights))
            {

                // get the earliest available flight with room for the cargo and add the box
                var flightToLoad =
                    flights.Where(flight => !flight.IsAtMaxCapacity())
                        .MinBy(x => x.GetDepartureTime());

                if (flightToLoad == null) return;
                flightToLoad.AddOrder(order);
                return;
            }
        }

    public IEnumerable<IFlight> GetOrderedFlights()
    {
        var allFlights = _flights.Values.SelectMany(flights => flights)
            .OrderBy(flight => flight.GetDepartureTime()).ThenBy(x => x.GetPlane().Id);

        return allFlights;
    } }
}
