using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreatePrice(PriceDto dto)
        {
            return Created("", dto);
        }
    }
}
