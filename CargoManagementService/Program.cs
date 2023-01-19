using CargoManagementService.Factories;
using CargoManagementService.Helpers;
using CargoManagementService.Services;
using CargoManagementService.Enums;
using CargoManagementService.Models;


// Please Note:
// For the sake of simplicity (and time) I did not code around future probable use cases such as:
// Loading multiple orders at once, varied order input streams, order weight restrictions, contraband orders,
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

// User Story #1 create flight schedule
// day 1 flights...
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YYZ, day1, plane1, maxCapacity,DayEnum.Day1));
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YYC, day1, plane2, maxCapacity, DayEnum.Day1));
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YVR, day1, plane3, maxCapacity, DayEnum.Day1));

// day 2 flights...
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YYZ, day2, plane1, maxCapacity, DayEnum.Day2));
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YYC, day2, plane2, maxCapacity, DayEnum.Day2));
flightManger.AddFlight(
    new Flight(AirportEnum.YUL, AirportEnum.YVR, day2, plane3, maxCapacity, DayEnum.Day2));


// Expected Output
var flights = flightManger.GetOrderedFlights();

Console.WriteLine("Flight itinerary start:");
Console.WriteLine();
foreach (var flight in flights)
{
    var output = $"Flight: {flight.GetPlane().Id}, departure: {flight.GetDepartureLocation()}, arrival: {flight.GetArrivalLocation()}, Day: {(int)flight.GetDayEnum()}";
    Console.WriteLine(output);
}
Console.WriteLine();
Console.WriteLine("Flight itinerary end");

// User Story #2 use input file to load cargo onto most recent flight avaialble

// get order from file
var orders = FileReader.GetOrders("coding-assigment-orders.json");

//load each or on the earliest flight available
var ordersArray = orders as Order[] ?? orders.ToArray();
foreach (var order in ordersArray)
{
    flightManger.LoadBox(order);
}

// print out order information

Console.WriteLine("Order summary start:");
Console.WriteLine();
foreach (var ordr in ordersArray)
{
    // Please note the orders with destination YYE
    // ex: "order-049" don't show up as unscheduled orders
    // because I filter them out during the order validation 
    // process
    var order = flightManger.GetScheduledOrder(ordr);
    Console.WriteLine(order.WasLoaded
        ? order.ToString() 
        : $"order: {ordr.Name}, flightNumber: not scheduled");
}
Console.WriteLine();
Console.WriteLine("Order summary end");




//foreach (var flight in flights)
//{
//    var output = $"order: {flight.GetPlane().Id}, departure: {flight.GetDepartureLocation()}, arrival: {flight.GetArrivalLocation()}, Day: {(int)flight.GetDayEnum()}";

Console.Read();







