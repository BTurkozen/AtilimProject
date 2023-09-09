using Atilim.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Atilim.Shared.CustomControllerBases
{
    public class CustomControllerBase : ControllerBase
    {
        public IActionResult CustomActionResult<T>(ResponseDto<T> reposne)
        {
            return new ObjectResult(reposne)
            {
                StatusCode = (int)reposne.HttpStatusCode
            };
        }
    }
}
