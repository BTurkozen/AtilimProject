using Atilim.Services.Identity.Application.Dtos.StudentDtos;
using Atilim.Shared.Dtos;

namespace Atilim.Services.Identity.Application.Features.Queries.StudentQueries
{
    public interface IGetAllStudentQueryHandler
    {
        Task<ResponseDto<List<StudentDto>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken);
    }
}