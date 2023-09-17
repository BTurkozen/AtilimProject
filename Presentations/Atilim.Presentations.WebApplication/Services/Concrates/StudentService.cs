using Atilim.Presentations.WebApplication.Services.Interfaces;
using Atilim.Presentations.WebApplication.ViewModels.StudentViewModels;
using Atilim.Shared.Dtos;
using Atilim.Shared.Settings.Interfaces;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

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

        public async Task<int> InsertAsync(CreateStudentViewModel createStudentViewModel)
        {
            var jsonData = JsonSerializer.Serialize(createStudentViewModel);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_clientInfos.URL}/students/", content);

            var result = await response.Content.ReadFromJsonAsync<ResponseDto<int>>();

            return result.Data;
        }
    }
}
