using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Simulation.Events;

namespace Simulation.Proxies
{
    public class HttpTrafficControlService : ITrafficControlService
    {
        private HttpClient _httpClient;

        public HttpTrafficControlService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendVehicleEntryAsync(VehicleRegistered vehicleRegistered)
        {
            var message = JsonContent.Create<VehicleRegistered>(vehicleRegistered);  
            _httpClient.PostAsync("http://localhost:6000/entrycam", message).Wait();
        }

        public async Task SendVehicleExitAsync(VehicleRegistered vehicleRegistered)
        {
            var message = JsonContent.Create<VehicleRegistered>(vehicleRegistered);
            _httpClient.PostAsync("http://localhost:6000/exitcam", message).Wait();
        }
    }
}