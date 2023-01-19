using CargoManagementService.Enums;
using CargoManagementService.Interfaces;


namespace CargoManagementService.Services
{
    internal class Flight : IFlight
    {
        public readonly AirportEnum DestinationLocation;
        public readonly DateTime DepartureTime;
        
        private readonly int _maxCapacity;
        private readonly AirportEnum _departureLocation;
        private readonly IPlane _plane;

        private int _currentCapacity;

        public Flight(
            AirportEnum departureLocation, 
            AirportEnum desinationLocation,
            DateTime departureTime,
            IPlane plane,
            int maxCapacity)
        {
            _departureLocation = departureLocation;
            DestinationLocation = desinationLocation;
            DepartureTime = departureTime;
            _plane = plane;
            _maxCapacity = maxCapacity;
            _currentCapacity = 0;
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
    }
}
