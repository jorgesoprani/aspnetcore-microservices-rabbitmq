using MicroRabbitMQ.MVC.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroRabbitMQ.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;
        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Transfer(TransferDTO transferDTO)
        {
            var uri = "https://localhost:5001/api/Banking";//TO DO: Move to appsettings
            var content = new StringContent(
                JsonConvert.SerializeObject(transferDTO),
                System.Text.Encoding.UTF8,
                "application/json"
                );
            var response = await _apiClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
