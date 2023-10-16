using BrightAkademi.Shared.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace BrightAkademi.Shared.ControllerBases
{
    public class CustomControllerBase : ControllerBase
    {
        public IActionResult CreateActionResult<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}