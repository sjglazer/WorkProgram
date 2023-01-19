using CargoManagementService.Enums;
using CargoManagementService.Services;

namespace CargoManagementService.Interfaces
{
    internal interface IFlight
    {
        IPlane GetPlane();
        bool IsAtMaxCapacity();
        void AddBox();
        AirportEnum GetDepartureLocation();
        AirportEnum GetArrivalLocation();
        DayEnum GetDayEnum();
    }
}
