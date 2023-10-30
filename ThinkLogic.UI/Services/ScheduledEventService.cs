using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using ThinkLogic.Common.InputOutput;
using ThinkLogic.Common.Models;

namespace ThinkLogic.UI.Services
{
    public class ScheduledEventService
    {
        private readonly HttpClient _httpCLient;
        private readonly string baseUrl = $"https://localhost:7245/api/ScheduledEvent";
        public ScheduledEventService(HttpClient httpCLient)
        {
            _httpCLient = httpCLient;
        }

        public async Task<TLResponse<int>?> InsertAsync(ScheduledEvent model)
        {
            var result = await _httpCLient.PostAsJsonAsync($"{baseUrl}", model);
            return await result.Content.ReadFromJsonAsync<TLResponse<int>>();
        }

        public async Task<TLResponse<int>?> UpdateAsync(ScheduledEvent model)
        {
            var result = await _httpCLient.PutAsJsonAsync($"{baseUrl}", model);
            return await result.Content.ReadFromJsonAsync<TLResponse<int>>();
        }

        public async Task<TLResponse<int>?> DeleteAsync(int Id)
        {
            var result = await _httpCLient.DeleteAsync($"{baseUrl}/{Id}");
            return await result.Content.ReadFromJsonAsync<TLResponse<int>>();
        }

        public async Task<TLListResponse<ScheduledEvent>?> GetByRequestAsync(TLRequest<ScheduledEvent> request )
        {

            var result = await _httpCLient.PostAsJsonAsync($"{baseUrl}/ByRequest", request);
            return await result.Content.ReadFromJsonAsync< TLListResponse<ScheduledEvent>>();
        }
    }
}
