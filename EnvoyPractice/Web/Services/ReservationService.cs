using System.Text.Json;
using Web.Data;
using Web.Services.Interfaces;

namespace Web.Services
{
    public class ReservationService : IReservationService
    {
        private readonly HttpClient _httpClient;

        public ReservationService(HttpClient httpClient)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _httpClient = new HttpClient(clientHandler);
        }

        public async Task<ReservationDto> CreateReservation(CreateReservationDto request)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateReservationDto>("/r", request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dto = JsonSerializer.Deserialize<ReservationDto>(content);
                return dto;
            }
            return null;
        }

        public async Task<List<ReservationDto>> GetAllReservation()
        {
            var response = await _httpClient.GetAsync("/r");
            var content = await response.Content.ReadFromJsonAsync<List<ReservationDto>>();
            return content;
        }
    }
}
