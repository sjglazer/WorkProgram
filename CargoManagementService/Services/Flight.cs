using CargoManagementService.Enums;
using CargoManagementService.Interfaces;
using CargoManagementService.Models;

namespace CargoManagementService.Services
{
    internal class Flight : IFlight
    {
        public readonly AirportEnum DestinationLocation;
        public readonly AirportEnum DepartureLocation;
        public readonly DateTime DepartureTime;
        public readonly IPlane Plane;
        public readonly DayEnum DayEnum;
        public readonly List<Order> _orders = new List<Order>();

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
            return _orders.Count == _maxCapacity;
        }

        public void AddOrder( Order order)
        {
            if(IsAtMaxCapacity())
            {
                throw new ArgumentOutOfRangeException();
            }

            _orders.Add(order);
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

        public List<Order> GetOrders()
        {
            return _orders.OrderBy<order>(order => order.) 
    }
}
