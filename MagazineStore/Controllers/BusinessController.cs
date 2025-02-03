using Microsoft.AspNetCore.Mvc;
using MagazineStore.BL.Interfaces;
using MagazineStore.Models.DTO;

namespace MagazineStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IMagazineBlService _magazineService;
        private readonly IAuthorService _authorService;

        public BusinessController(IMagazineBlService MagazineService, IAuthorService AuthorService)
        {
            _magazineService = MagazineService;
            _authorService = AuthorService;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllMagazineWithDetails")]
        public IActionResult GetAllMagazineWithDetails()
        {
            var result = _magazineService.GetDetailedMagazines();

            if (result == null || result.Count == 0)
            {
                return NotFound("No Magazines found");
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor([FromBody] Author Author)
        {
            _authorService.Add(Author);

            return Ok();
        }

    }
}
