using CargoManagementService.Enums;
using CargoManagementService.Models;

namespace CargoManagementService.Interfaces
{
    internal interface IFlightManager
    {
        IEnumerable<IFlight> GetOrderedFlights();

        void LoadBox(AirportEnum destination, Order order);
      
    }
}
