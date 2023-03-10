using CargoManagementService.Enums;
using CargoManagementService.Models;

namespace CargoManagementService.Interfaces
{
    internal interface IFlight
    {
        IPlane GetPlane();
        bool IsAtMaxCapacity();
        void AddOrder(Order order);
        AirportEnum GetDepartureLocation();
        AirportEnum GetArrivalLocation();
        DayEnum GetDayEnum();
        DateTime GetDepartureTime();
        bool HasOrder(Order order);
    }
}
