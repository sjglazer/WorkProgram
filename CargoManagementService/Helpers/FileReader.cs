using System.Text.Json;
using CargoManagementService.Enums;
using CargoManagementService.Models;

namespace CargoManagementService.Helpers
{
    internal class FileReader
    {
        public static IEnumerable<Order> GetOrders(string fileName)

        {
            var ret = new List<Order>();
            if (string.IsNullOrEmpty(fileName))
                return ret;
            
            
            // Could add more validation of the file contents(input source) in a real world scenario
            // but since I am working with a static file right now, I will leave it as is
            using StreamReader r = new StreamReader(fileName);
            string json = r.ReadToEnd();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var orders = JsonSerializer.Deserialize<Dictionary<string, OrderJson>>(json, options);
            if(orders is null)
                return ret;

            foreach (var order in orders)
            {
                if (Enum.TryParse<AirportEnum>(order.Value.Destination, out var destination))
                {
                    ret.Add(new Order(order.Key, AirportEnum.YUL, destination));
                }
            }

            return ret;
        }
    }
}
