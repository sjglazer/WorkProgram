using CargoManagementService.Enums;
using CargoManagementService.Interfaces;


namespace CargoManagementService.Services
{
    internal class Flight : IFlight
    {
        public readonly AirportEnum DestinationLocation;
        public readonly AirportEnum DepartureLocation;
        public readonly DateTime DepartureTime;
        public readonly IPlane Plane;
        public readonly DayEnum DayEnum;

        private readonly int _maxCapacity;
        private int _currentCapacity;

        public Flight(
            AirportEnum departureLocation, 
            AirportEnum desinationLocation,
            DateTime departureTime,
            IPlane plane,
            int maxCapacity,
            DayEnum dayEnum)
        {
            DepartureLocation = departureLocation;
            DestinationLocation = desinationLocation;
            DepartureTime = departureTime;
            Plane = plane;
            _maxCapacity = maxCapacity;
            _currentCapacity = 0;
            DayEnum = dayEnum;
        }

        public bool IsAtMaxCapacity()
        {
            return _currentCapacity == _maxCapacity;
        }

        public void AddBox()
        {
            if(IsAtMaxCapacity())
            {
                throw new ArgumentOutOfRangeException();
            }
            
            Interlocked.Increment(ref _currentCapacity);
        }

       public IPlane GetPlane()
        {
            return Plane;
        }

        public AirportEnum GetDepartureLocation()
        {
            return DepartureLocation;
        }

        public AirportEnum GetArrivalLocation()
        {
            return DestinationLocation;
        }

        public DayEnum GetDayEnum()
        {
            return DayEnum;
        }
    }
}
