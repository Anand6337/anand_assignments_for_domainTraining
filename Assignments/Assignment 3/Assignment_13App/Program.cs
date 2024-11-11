using System;
using System.Collections.Generic;

namespace Assignment_13App
{
    public class Program
    {
            static void Main(string[] args)
            {
                TransportManager manager = new TransportManager();

                manager.AddSchedule(new TransportSchedule { TransportType = "bus", Route = "Route A", DepartureTime = DateTime.Now.AddHours(2), ArrivalTime = DateTime.Now.AddHours(4), Price = 200, SeatsAvailable = 20 });
                manager.AddSchedule(new TransportSchedule { TransportType = "flight", Route = "Route B", DepartureTime = DateTime.Now.AddHours(1), ArrivalTime = DateTime.Now.AddHours(3), Price = 1500, SeatsAvailable = 50 });
                manager.AddSchedule(new TransportSchedule { TransportType = "bus", Route = "Route C", DepartureTime = DateTime.Now.AddHours(5), ArrivalTime = DateTime.Now.AddHours(7), Price = 300, SeatsAvailable = 15 });

                Console.WriteLine("Search Results:");
                foreach (var schedule in manager.Search(transportType: "bus"))
                {
                    Console.WriteLine($"{schedule.TransportType} - {schedule.Route} - {schedule.DepartureTime}");
                }

                Console.WriteLine("\nGroup By Transport Type:");
                foreach (var group in manager.GroupByTransportType())
                {
                    Console.WriteLine($"{group.Key}:");
                    foreach (var schedule in group)
                    {
                        Console.WriteLine($"  {schedule.Route} - {schedule.DepartureTime}");
                    }
                }

                Console.WriteLine("\nOrder By Price:");
                foreach (var schedule in manager.OrderBy("price"))
                {
                    Console.WriteLine($"{schedule.Route} - {schedule.Price}");
                }

                Console.WriteLine("\nFiltered by Seats and Time:");
                DateTime startTime = DateTime.Now;
                DateTime endTime = DateTime.Now.AddHours(6);
                foreach (var schedule in manager.Filter(minSeats: 10, startTime: startTime, endTime: endTime))
                {
                    Console.WriteLine($"{schedule.Route} - {schedule.SeatsAvailable} seats - {schedule.DepartureTime}");
                }

                var (totalSeats, averagePrice) = manager.AggregateData();
                Console.WriteLine($"\nTotal Seats: {totalSeats}, Average Price: {averagePrice}");

                Console.WriteLine("\nRoutes and Departure Times:");
                foreach (var item in manager.GetRoutesAndDepartureTimes())
                {
                    Console.WriteLine($"{item.Route} - {item.DepartureTime}");
                }

                Console.ReadLine();
            }
    }
}
