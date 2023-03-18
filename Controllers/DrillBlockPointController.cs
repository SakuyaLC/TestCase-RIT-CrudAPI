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

        private readonly IDrillBlockRepository _drillBlockRepository;

        public DrillBlockPointController(IDrillBlockPointRepository drillBlockPointRepository, IDrillBlockRepository drillBlockRepository, IMapper mapper)
        {
            _drillBlockPointRepository = drillBlockPointRepository;
            _drillBlockRepository = drillBlockRepository;
            _mapper = mapper;
        }

        [HttpGet("/get-drillBlockPoints")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DrillBlockPoint>))]
        async public Task<IActionResult> GetDrillBlockPoints()
        {
            var drillBlockPoints = _mapper.Map<List<DrillBlockPointDTO>>(await _drillBlockPointRepository.GetDrillBlockPoints());

            return Ok(drillBlockPoints);
        }

        [HttpGet("/get-drillBlockPoint")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DrillBlockPoint>))]
        async public Task<IActionResult> GetSpecificDrillBlockPoint(int Id)
        {
            var drillBlockPoint = _mapper.Map<DrillBlockPointDTO>(await _drillBlockPointRepository.GetSpecificDrillBlockPoint(Id));

            return Ok(drillBlockPoint);
        }

        [HttpPost("/create-drillBlockPoint")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        async public Task<IActionResult> CreateDrillBlockPoint([FromQuery] DrillBlockPointDTO drillBlockPoint)
        {
            if (drillBlockPoint == null) return BadRequest(ModelState);

            bool exists = await _drillBlockRepository.DrillBlockExists(drillBlockPoint.DrillBlockId);
            if (!exists)
                return NotFound();

            var drillBlockPointMap = _mapper.Map<DrillBlockPoint>(drillBlockPoint);
            if (drillBlockPointMap == null) return BadRequest(ModelState);

            bool result = await _drillBlockPointRepository.CreateDrillBlockPoint(drillBlockPointMap);

            if (!result)
                return BadRequest(ModelState);
            else
                return Ok("Drill block point successfully created");
        }

        [HttpPut("/update-drillBlockPoint")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        async public Task<IActionResult> UpdateDrillBlockPoint([FromQuery] DrillBlockPointDTO drillBlockPoint)
        {
            bool drillBlockPointExists = await _drillBlockPointRepository.DrillBlockPointExists(drillBlockPoint.Id);
            if (!drillBlockPointExists)
                return NotFound();

            bool drillBlockExists = await _drillBlockRepository.DrillBlockExists(drillBlockPoint.DrillBlockId);
            if (!drillBlockExists)
                return NotFound();

            var drillBlockPointForUpdate = await _drillBlockPointRepository.GetSpecificDrillBlockPoint(drillBlockPoint.Id);

            drillBlockPointForUpdate.DrillBlockId = drillBlockPoint.DrillBlockId;
            drillBlockPointForUpdate.Sequence = drillBlockPoint.Sequence;
            drillBlockPointForUpdate.X = drillBlockPoint.X;
            drillBlockPointForUpdate.Y = drillBlockPoint.Y;
            drillBlockPointForUpdate.Z = drillBlockPoint.Z;

            bool result = await _drillBlockPointRepository.UpdateDrillBlockPoint(drillBlockPointForUpdate);

            if (!result)
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
        async public Task<IActionResult> DeleteDrillBlockPoint([Required] int Id)
        {
            bool exists = await _drillBlockPointRepository.DrillBlockPointExists(Id);
            if (!exists)
                return NotFound();

            var drillBlockPointToDelete = await _drillBlockPointRepository.GetSpecificDrillBlockPoint(Id);

            bool result = await _drillBlockPointRepository.DeleteDrillBlockPoint(drillBlockPointToDelete);

            if (!result)
            {
                ModelState.AddModelError("", "Something went wrong when updating drill block");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Drill block point has been successfully deleted");

        }
    }
}
