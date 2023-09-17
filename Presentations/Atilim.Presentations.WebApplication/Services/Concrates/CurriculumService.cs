using Atilim.Presentations.WebApplication.Services.Interfaces;
using Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels;
using Atilim.Shared.Dtos;
using Atilim.Shared.Settings.Interfaces;
using System.Text;
using System.Text.Json;

namespace Atilim.Presentations.WebApplication.Services.Concrates
{
    public class CurriculumService : ICurriculumService
    {
        private readonly HttpClient _httpClient;
        private readonly IClientInfos _clientInfos;

        public CurriculumService(HttpClient httpClient, IClientInfos clientInfos)
        {
            _httpClient = httpClient;
            _clientInfos = clientInfos;
        }

        public async Task<List<CurriculumViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"{_clientInfos.URL}/curriculums/curriculums");

            var result = await response.Content.ReadFromJsonAsync<ResponseDto<List<CurriculumViewModel>>>();

            return result.Data;
        }

        public async Task<CurriculumWithLessonViewModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_clientInfos.URL}/curriculums/curriculum/{id}");

            var result = await response.Content.ReadFromJsonAsync<ResponseDto<CurriculumWithLessonViewModel>>();

            return result.Data;
        }

        public async Task<CurriculumWithLessonViewModel> GetCurriculumWithLessonsByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDto<CurriculumWithLessonViewModel>>($"{_clientInfos.URL}/curriculums/curriculum-with-lessons-by-id/{id}");

            return response.Data;
        }

        public async Task<List<CurriculumWithLessonViewModel>> GetCurriculumWithLessonsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<CurriculumWithLessonViewModel>>>($"{_clientInfos.URL}/curriculums/curriculum-with-lessons");

            return response.Data;
        }


        public async Task<int> InsertAsync(CurriculumWithLessonViewModel curriculumWithLessonViewModel)
        {
            var jsonData = JsonSerializer.Serialize(curriculumWithLessonViewModel);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_clientInfos.URL}/curriculums", content);

            var result = await response.Content.ReadFromJsonAsync<ResponseDto<int>>();

            return result.Data;
        }

        public async Task<bool> UpdateAsync(CurriculumWithLessonViewModel curriculumWithLessonViewModel)
        {
            var jsonData = JsonSerializer.Serialize(curriculumWithLessonViewModel);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_clientInfos.URL}/curriculums", content);

            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_clientInfos.URL}/curriculums/{id}");

            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    }
}