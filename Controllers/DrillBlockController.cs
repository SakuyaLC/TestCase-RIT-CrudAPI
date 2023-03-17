using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TestCase_RIT_CrudAPI.Data.DTO;
using TestCase_RIT_CrudAPI.Data.Interfaces;
using TestCase_RIT_CrudAPI.Model;

namespace TestCase_RIT_CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrillBlockController : Controller
    {
        private readonly IDrillBlockRepository _drillBlockRepository;
        private readonly IMapper _mapper;

        public DrillBlockController(IDrillBlockRepository drillBlockRepository, IMapper mapper)
        {
            _drillBlockRepository = drillBlockRepository;
            _mapper = mapper;
        }

        [HttpGet("/get-drillBlocks")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DrillBlock>))]
        public IActionResult GetDrillBlocks()
        {
            var drillBlocks = _mapper.Map<List<DrillBlockDTO>>(_drillBlockRepository.GetDrillBlocks().Result);

            return Ok(drillBlocks);
        }

        [HttpGet("/get-drillBlock/{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DrillBlock>))]
        public IActionResult GetSpecifiedDrillBlock(int Id)
        {
            var drillBlock = _mapper.Map<DrillBlockDTO>(_drillBlockRepository.GetSpecificDrillBlock(Id).Result);

            return Ok(drillBlock);
        }

        [HttpPost("/create-drillBlock")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateDrillBlock([FromQuery] DrillBlockDTO drillBlock)
        {
            if (drillBlock == null) return BadRequest(ModelState);

            var drillBlockMap = _mapper.Map<DrillBlock>(drillBlock);
            if (drillBlockMap == null) return BadRequest(ModelState);

            drillBlockMap.UpdateDate = DateTime.Now;

            if (!_drillBlockRepository.CreateDrillBlock(drillBlockMap).Result)
                return BadRequest(ModelState);
            else
                return Ok("Drillblock successfully created");
        }

        [HttpPut("/update-drillBlock/{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateDrillBlock([Required] int Id, [FromQuery] DrillBlockDTO drillBlock)
        {
            if (!_drillBlockRepository.DrillBlockExists(Id).Result)
                return NotFound();

            var drillBlockForUpdate = _drillBlockRepository.GetSpecificDrillBlock(Id).Result;

            drillBlockForUpdate.Name = drillBlock.Name;

            drillBlockForUpdate.UpdateDate = drillBlock.UpdateDate;

            if (!_drillBlockRepository.UpdateDrillBlock(drillBlockForUpdate).Result)
            {
                ModelState.AddModelError("", "Something went wrong when updating drill block");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Drill block has been successfully updated");
        }

        [HttpDelete("/remove-drillBlock")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult DeleteDrillBlock(int Id)
        {
            if (!_drillBlockRepository.DrillBlockExists(Id).Result)
                return NotFound();

            var drillBlockToDelete = _drillBlockRepository.GetSpecificDrillBlock(Id).Result;

            if (!_drillBlockRepository.DeleteDrillBlock(drillBlockToDelete).Result)
            {
                ModelState.AddModelError("", "Something went wrong when updating drill block");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Drill block has been successfully deleted");

        }
    }
}
