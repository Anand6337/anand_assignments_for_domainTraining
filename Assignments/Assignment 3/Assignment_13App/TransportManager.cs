using System;

namespace Assignment_13App
{
    public class TransportManager
    {
        private List<TransportSchedule> schedules = new List<TransportSchedule>();

        public void AddSchedule(TransportSchedule schedule)
        {
            schedules.Add(schedule);
        }

        public IEnumerable<TransportSchedule> Search(string transportType = null, string route = null, DateTime? time = null)
        {
            return schedules.Where(s =>
                (string.IsNullOrEmpty(transportType) || s.TransportType.Equals(transportType, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(route) || s.Route.Equals(route, StringComparison.OrdinalIgnoreCase)) &&
                (!time.HasValue || s.DepartureTime.Date == time.Value.Date)
            );
        }

        public IEnumerable<IGrouping<string, TransportSchedule>> GroupByTransportType()
        {
            return schedules.GroupBy(s => s.TransportType);
        }

        public IEnumerable<TransportSchedule> OrderBy(string orderBy)
        {
            return orderBy.ToLower() switch
            {
                "departuretime" => schedules.OrderBy(s => s.DepartureTime),
                "price" => schedules.OrderBy(s => s.Price),
                "seatsavailable" => schedules.OrderBy(s => s.SeatsAvailable),
                _ => schedules
            };
        }

        public IEnumerable<TransportSchedule> Filter(int minSeats, DateTime startTime, DateTime endTime)
        {
            return schedules.Where(s =>
                s.SeatsAvailable >= minSeats &&
                s.DepartureTime >= startTime &&
                s.DepartureTime <= endTime
            );
        }

        public (int totalSeats, decimal averagePrice) AggregateData()
        {
            int totalSeats = schedules.Sum(s => s.SeatsAvailable);
            decimal averagePrice = schedules.Average(s => s.Price);
            return (totalSeats, averagePrice);
        }

        public IEnumerable<(string Route, DateTime DepartureTime)> GetRoutesAndDepartureTimes()
        {
            return schedules.Select(s => (s.Route, s.DepartureTime));
        }
    }
}