using CargoManagementService.Enums;

namespace CargoManagementService.Interfaces
{
    internal interface IFlightManager
    {
        IEnumerable<IFlight> GetOrderedFlights();

        void LoadBox(AirportEnum destination);
      
    }
}
