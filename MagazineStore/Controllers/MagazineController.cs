using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MagazineStore.BL.Interfaces;
using MagazineStore.Models.DTO;
using MagazineStore.Models.Requests;

namespace MagazineStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MagazinesController : ControllerBase
    {
        private readonly IMagazineService _magazineService;
        private readonly IMapper _mapper;
        private readonly ILogger<MagazinesController> _logger;

        public MagazinesController(
            IMagazineService MagazineService,
            IMapper mapper, 
            ILogger<MagazinesController> logger)
        {
            _magazineService = MagazineService;
            _mapper = mapper;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _magazineService.GetAllMagazines();

            if (result == null || result.Count == 0)
            {
                return NotFound("No Magazines found");
            }

            return Ok(result);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id can't be null or empty");
            }

            var result = _magazineService.GetById(id);

            if (result == null)
            {
                return NotFound($"Magazine with ID:{id} not found");
            }

            return Ok(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(AddMagazineRequest magazine)
        {
            try
            {
                var magazineDto = _mapper.Map<Magazine>(magazine);

                if (magazineDto == null)
                {
                    return BadRequest("Can't convert Magazine to Magazine DTO");
                }

                _magazineService.AddMagazine(magazineDto);

                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error adding Magazine with");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be greater than 0");
            }

            //_magazineService.Delete(id);


            return Ok();
        }
    }
}
