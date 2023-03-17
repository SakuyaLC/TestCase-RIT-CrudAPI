using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestCase_RIT_CrudAPI.Data.DTO;
using TestCase_RIT_CrudAPI.Data.Interfaces;
using TestCase_RIT_CrudAPI.Data.Repositories;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolePointController : Controller
    {
        private readonly IHolePointRepository _holePointRepository;
        private readonly IMapper _mapper;

        public HolePointController(IHolePointRepository holePointRepository, IMapper mapper)
        {
            _holePointRepository = holePointRepository;
            _mapper = mapper;
        }

        [HttpGet("/get-holePoints")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HolePoint>))]
        public IActionResult GetDrillBlocks()
        {
            var holePoints = _mapper.Map<List<HolePointDTO>>(_holePointRepository.GetHolePoints().Result);

            return Ok(holePoints);
        }

        [HttpGet("/get-holePoint/{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HolePoint>))]
        public IActionResult GetSpecifiedHolePoint(int Id)
        {
            var holePoint = _mapper.Map<HolePoint>(_holePointRepository.GetSpecificHolePoint(Id).Result);

            return Ok(holePoint);
        }

        [HttpPost("/create-holePoint")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateHole([FromQuery] HolePointDTO holePoint)
        {
            if (holePoint == null) return BadRequest(ModelState);

            var holePointMap = _mapper.Map<HolePoint>(holePoint);
            if (holePointMap == null) return BadRequest(ModelState);

            if (!_holePointRepository.CreateHolePoint(holePointMap).Result)
                return BadRequest(ModelState);
            else
                return Ok("Hole point successfully created");
        }

        [HttpPut("/update-holePoint")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateHolePoint([Required] int Id, [FromQuery] HolePointDTO holePoint)
        {
            if (!_holePointRepository.HolePointExists(Id).Result)
                return NotFound();

            var holePointForUpdate = _holePointRepository.GetSpecificHolePoint(Id).Result;

            holePointForUpdate.HoleId = holePoint.HoleId;
            holePointForUpdate.X = holePoint.X;
            holePointForUpdate.Y = holePoint.Y;
            holePointForUpdate.Z = holePoint.Z;

            if (!_holePointRepository.UpdateHolePoint(holePointForUpdate).Result)
            {
                ModelState.AddModelError("", "Something went wrong when updating hole");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Hole point has been successfully updated");
        }

        [HttpDelete("/remove-holePoint")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult DeleteHolePoint(int Id)
        {
            if (!_holePointRepository.HolePointExists(Id).Result)
                return NotFound();

            var holeToDelete = _holePointRepository.GetSpecificHolePoint(Id).Result;

            if (!_holePointRepository.DeleteHolePoint(holeToDelete).Result)
            {
                ModelState.AddModelError("", "Something went wrong when updating hole point");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Hole point has been successfully deleted");

        }
    }
}
