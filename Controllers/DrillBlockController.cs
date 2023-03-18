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
        async public Task<IActionResult> GetDrillBlocks()
        {
            var drillBlocks = _mapper.Map<List<DrillBlockDTO>>(await _drillBlockRepository.GetDrillBlocks());

            return Ok(drillBlocks);
        }

        [HttpGet("/get-drillBlock/{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DrillBlock>))]
        async public Task<IActionResult> GetSpecificDrillBlock(int Id)
        {
            var drillBlock = _mapper.Map<DrillBlockDTO>(await _drillBlockRepository.GetSpecificDrillBlock(Id));

            return Ok(drillBlock);
        }

        [HttpPost("/create-drillBlock")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        async public Task<IActionResult> CreateDrillBlock([FromQuery] DrillBlockDTO drillBlock)
        {
            if (drillBlock == null) return BadRequest(ModelState);

            var drillBlockMap = _mapper.Map<DrillBlock>(drillBlock);
            if (drillBlockMap == null) return BadRequest(ModelState);

            drillBlockMap.UpdateDate = DateTime.Now;

            bool result = await _drillBlockRepository.CreateDrillBlock(drillBlockMap);

            if (!result)
                return BadRequest(ModelState);
            else
                return Ok("Drillblock successfully created");
        }

        [HttpPut("/update-drillBlock/{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        async public Task<IActionResult> UpdateDrillBlock([Required] int Id, [FromQuery] DrillBlockDTO drillBlock)
        {
            bool exists = await _drillBlockRepository.DrillBlockExists(Id);
            if (!exists)
                return NotFound();

            var drillBlockForUpdate = await _drillBlockRepository.GetSpecificDrillBlock(Id);

            drillBlockForUpdate.Name = drillBlock.Name;

            drillBlockForUpdate.UpdateDate = drillBlock.UpdateDate;

            bool result = await _drillBlockRepository.UpdateDrillBlock(drillBlockForUpdate);

            if (!result)
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
        async public Task<IActionResult> DeleteDrillBlock(int Id)
        {
            bool exists = await _drillBlockRepository.DrillBlockExists(Id);
            if (!exists)
                return NotFound();

            var drillBlockToDelete = await _drillBlockRepository.GetSpecificDrillBlock(Id);

            bool result = await _drillBlockRepository.DeleteDrillBlock(drillBlockToDelete);

            if (!result)
            {
                ModelState.AddModelError("", "Something went wrong when updating drill block");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Drill block has been successfully deleted");

        }
    }
}
