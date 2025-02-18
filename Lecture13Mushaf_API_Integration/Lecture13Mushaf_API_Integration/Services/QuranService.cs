using Lecture13Mushaf_API_Integration.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Lecture13Mushaf_API_Integration.Services
{
 
public class QuranService
    {
        private readonly HttpClient _httpClient;

        public QuranService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Surah>> GetAllSurahsAsync()
        {
            var response = await _httpClient.GetAsync("https://api.alquran.cloud/v1/surah");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<QuranResponse>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result?.Data ?? new List<Surah>();
            }

            return new List<Surah>();
        }

        public async Task<SurahDetails> GetSurahDetailsAsync(int surahNumber)
        {
            var response = await _httpClient.GetAsync($"https://api.alquran.cloud/v1/surah/{surahNumber}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<SurahDetailsResponse>(jsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result?.Data;
            }

            return null;
        }
    }
}
