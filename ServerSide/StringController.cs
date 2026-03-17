using Microsoft.AspNetCore.Mvc;
using StringChangeLibrary;

namespace ServerSide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringController : ControllerBase
    {
        private readonly StringClass _libraryObject;

        public StringController(StringClass libraryObject)
        {
            _libraryObject = libraryObject;
        }

        [HttpGet(Name = "FindLongestWord")]
        public IActionResult FindLongestWord(string value)
        {
            var res = _libraryObject.FindLongestWord(value);

            if (string.IsNullOrEmpty(res))
            {
                return StatusCode(500, "Не вдалося визначити найдовше слово.");
            }

            return Ok(res);
        }
    }
}