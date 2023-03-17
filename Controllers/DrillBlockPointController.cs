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
    public class DrillBlockPointController : Controller
    {
        private readonly IDrillBlockPointRepository _drillBlockPointRepository;
        private readonly IMapper _mapper;

        public DrillBlockPointController(IDrillBlockPointRepository drillBlockPointRepository, IMapper mapper)
        {
            _drillBlockPointRepository = drillBlockPointRepository;
            _mapper = mapper;
        }

        [HttpGet("/get-drillBlockPoints")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DrillBlockPoint>))]
        public IActionResult GetDrillBlockPoints()
        {
            var drillBlockPoints = _mapper.Map<List<DrillBlockPointDTO>>(_drillBlockPointRepository.GetDrillBlockPoints().Result);

            return Ok(drillBlockPoints);
        }

        [HttpGet("/get-drillBlockPoint/{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DrillBlockPoint>))]
        public IActionResult GetSpecifiedDrillBlockPoint(int Id)
        {
            var drillBlockPoint = _mapper.Map<DrillBlockPointDTO>(_drillBlockPointRepository.GetSpecificDrillBlockPoint(Id).Result);

            return Ok(drillBlockPoint);
        }

        [HttpPost("/create-drillBlockPoint")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateDrillBlockPoint([FromQuery] DrillBlockPointDTO drillBlockPoint)
        {
            if (drillBlockPoint == null) return BadRequest(ModelState);

            var drillBlockPointMap = _mapper.Map<DrillBlockPoint>(drillBlockPoint);
            if (drillBlockPointMap == null) return BadRequest(ModelState);

            if (!_drillBlockPointRepository.CreateDrillBlockPoint(drillBlockPointMap).Result)
                return BadRequest(ModelState);
            else
                return Ok("Drill block point successfully created");
        }

        [HttpPut("/update-drillBlockPoint/{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateDrillBlockPoint([Required] int Id, [FromQuery] DrillBlockPointDTO drillBlockPoint)
        {
            if (!_drillBlockPointRepository.DrillBlockPointExists(Id).Result)
                return NotFound();

            var drillBlockPointForUpdate = _drillBlockPointRepository.GetSpecificDrillBlockPoint(Id).Result;

            drillBlockPointForUpdate.DrillBlockId = drillBlockPoint.DrillBlockId;
            drillBlockPointForUpdate.Sequence = drillBlockPoint.Sequence;
            drillBlockPointForUpdate.X = drillBlockPoint.X;
            drillBlockPointForUpdate.Y = drillBlockPoint.Y;
            drillBlockPointForUpdate.Z = drillBlockPoint.Z;

            if (!_drillBlockPointRepository.UpdateDrillBlockPoint(drillBlockPointForUpdate).Result)
            {
                ModelState.AddModelError("", "Something went wrong when updating drill block");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Drill block point has been successfully updated");
        }

        [HttpDelete("/remove-drillBlockPoint")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult DeleteDrillBlockPoint(int Id)
        {
            if (!_drillBlockPointRepository.DrillBlockPointExists(Id).Result)
                return NotFound();

            var drillBlockPointToDelete = _drillBlockPointRepository.GetSpecificDrillBlockPoint(Id).Result;

            if (!_drillBlockPointRepository.DeleteDrillBlockPoint(drillBlockPointToDelete).Result)
            {
                ModelState.AddModelError("", "Something went wrong when updating drill block");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Drill block point has been successfully deleted");

        }
    }
}
