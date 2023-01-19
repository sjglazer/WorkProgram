using CargoManagementService.Enums;
using CargoManagementService.Interfaces;
using CargoManagementService.Models;
using System.Xml.Linq;

namespace CargoManagementService.Services
{
    internal class Flight : IFlight
    {
        public readonly AirportEnum DestinationLocation;
        public readonly AirportEnum DepartureLocation;
        public readonly DateTime DepartureTime;
        public readonly IPlane Plane;
        public readonly DayEnum DayEnum;
        
        private readonly List<Order> _orders = new List<Order>();
        private readonly int _maxCapacity;
       

        public Flight(
            AirportEnum departureLocation,
            AirportEnum destinationLocation,
            DateTime departureTime,
            IPlane plane,
            int maxCapacity,
            DayEnum dayEnum)
        {
            DepartureLocation = departureLocation;
            DestinationLocation = destinationLocation;
            DepartureTime = departureTime;
            Plane = plane;
            _maxCapacity = maxCapacity;
            DayEnum = dayEnum;
        }

        public bool IsAtMaxCapacity()
        {
            return _orders.Count == _maxCapacity;
        }

        public void AddOrder(Order order)
        {
            if (IsAtMaxCapacity())
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

        public DateTime GetDepartureTime()
        {
            return DepartureTime;
        }

        public bool HasOrder(Order order)
        {
            return _orders.Any(currentOrder =>
                string.Equals(currentOrder.Name, order.Name, StringComparison.OrdinalIgnoreCase));
        }

        public override string ToString()
        {
            return
                $"Flight: {Plane.Id}, departure: {DepartureLocation}, arrival: {DestinationLocation}, Day: {(int)DayEnum}";
        }
    }
}
