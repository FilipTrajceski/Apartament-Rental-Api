using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S_T.Apartaments.Shared.Responses;

namespace S_T.Apartaments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Response<TResult>(CustomResponse<TResult> response) where TResult : new()
        {
            if (!response.IsSuccessfull)
                return BadRequest(response);
            return Ok(response.Result);
        }

        protected IActionResult Response(CustomResponse response)
        {
            if (!response.IsSuccessfull)
                return BadRequest(response);
            return Ok();
        }
    }
}

