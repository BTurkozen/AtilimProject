using Atilim.Presentations.WebApplication.Services.Interfaces;
using Atilim.Presentations.WebApplication.ViewModels.LessonViewModels;
using Atilim.Shared.Dtos;
using Atilim.Shared.Settings.Interfaces;

namespace Atilim.Presentations.WebApplication.Services.Concrates
{
    public class LessonService : ILessonService
    {
        private readonly HttpClient _httpClient;
        private readonly IClientInfos _clientInfos;

        public LessonService(HttpClient httpClient, IClientInfos clientInfos)
        {
            _httpClient = httpClient;
            _clientInfos = clientInfos;
        }

        public async Task<List<LessonViewModel>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<LessonViewModel>>>($"{_clientInfos.URL}/Lessons/");

            return response.Data;
        }

        public async Task<LessonViewModel> GetById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDto<LessonViewModel>>($"{_clientInfos.URL}/Lessons/{id}");

            return response.Data;
        }
    }
}
