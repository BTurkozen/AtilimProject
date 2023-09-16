using Atilim.Presentations.WebApplication.Services.Interfaces;
using Atilim.Presentations.WebApplication.ViewModels.CurriculumViewModels;
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

            return new List<CurriculumViewModel>();
        }

        public Task<CurriculumViewModel> GetByIdAsync(int id)
        {

            // curriculum/
            throw new NotImplementedException();
        }
    }
}
