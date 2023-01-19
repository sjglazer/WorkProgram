using CargoManagementService.Factories;
using CargoManagementService.Helpers;
using CargoManagementService.Services;
using CargoManagementService.Enums;

// Please Note:
// For the sake of simplicity (and time) I did not code around future probable use cases such as:
// Loading multiple orders at once, varied order input streams, order wieght restrictions, contraband orders,
// order cancellation, varied max cargo limits, etc
// I tried to keep the code simple and concise :)



var planeFactory = new PlaneFactory();

var plane1 = planeFactory.GetPlane(1);
var plane2 = planeFactory.GetPlane(2);
var plane3 = planeFactory.GetPlane(3);

// random day 1
var day1 = new DateTime(2025, 11, 25, 12, 0, 0);
var day2 = day1.AddDays(1);

var flightManger = new FlightManager();
var maxCapacity = 20;

// day 1 flights...
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YYZ, day1, plane1, maxCapacity));
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YYC, day1, plane2, maxCapacity));
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YVR, day1, plane3, maxCapacity));

// day 2 flights...
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YYZ, day2, plane1, maxCapacity));
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YYC, day2, plane2, maxCapacity));
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YVR, day2, plane3, maxCapacity));


var orders = FileReader.GetOrders("coding-assigment-orders.json");
foreach (var order in orders)
{
    flightManger.LoadBox(order.Destination);
    Console.WriteLine(order.Name + " " + order.Destination);
}



