using Atilim.Presentations.WebApplication.Services.Interfaces;
using Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels;
using Atilim.Shared.Dtos;
using Atilim.Shared.Settings.Interfaces;

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

        public async Task<CurriculumViewModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_clientInfos.URL}/curriculums/curriculum/{id}");

            var result = await response.Content.ReadFromJsonAsync<ResponseDto<CurriculumViewModel>>();

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

            // TODO =>BURAK Bakılacak  Post işleminde 404 geliyor.
            var response = await _httpClient.PostAsJsonAsync($"{_clientInfos.URL}/curriculums/InsertCurriculumWithLesson", curriculumWithLessonViewModel);

            var result = await response.Content.ReadFromJsonAsync<ResponseDto<int>>();

            return result.Data;
        }

        public async Task<bool> UpdateAsync(CurriculumViewModel curriculumViewModel)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_clientInfos.URL}/curriculums", curriculumViewModel);

            var result = await response.Content.ReadFromJsonAsync<ResponseDto<bool>>();

            return result.Data;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteFromJsonAsync<ResponseDto<bool>>($"{_clientInfos.URL}/curriculums/{id}");

            return response.Data;
        }
    }
}