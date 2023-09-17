using Atilim.Presentations.WebApplication.Services.Interfaces;
using Atilim.Presentations.WebApplication.ViewModels.StudentViewModels;
using Atilim.Shared.Dtos;
using Atilim.Shared.Settings.Interfaces;

namespace Atilim.Presentations.WebApplication.Services.Concrates
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;
        private readonly IClientInfos _clientInfos;

        public StudentService(HttpClient httpClient, IClientInfos clientInfos)
        {
            _httpClient = httpClient;
            _clientInfos = clientInfos;
        }

        public async Task<List<StudentViewModel>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<StudentViewModel>>>($"{_clientInfos.URL}/students");

            return response.Data;
        }

        public async Task<StudentViewModel> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDto<StudentViewModel>>($"{_clientInfos.URL}/students/{id}");

            return response.Data;
        }

    }
}
