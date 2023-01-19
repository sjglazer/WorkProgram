using CargoManagementService.Enums;
using CargoManagementService.Services;

namespace CargoManagementService.Interfaces
{
    internal interface IFlight
    {
        IPlane GetPlane();
        bool IsAtMaxCapacity();
        void AddOrder(Order  order);
        AirportEnum GetDepartureLocation();
        AirportEnum GetArrivalLocation();
        DayEnum GetDayEnum();
    }
}
