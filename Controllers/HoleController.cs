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
    public class HoleController : Controller
    {
        private readonly IHoleRepository _holeRepository;
        private readonly IMapper _mapper;

        public HoleController(IHoleRepository holeRepository, IMapper mapper)
        {
            _holeRepository = holeRepository;
            _mapper = mapper;
        }

        [HttpGet("/get-holes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hole>))]
        async public Task<IActionResult> GetHoles()
        {
            var holes = _mapper.Map<List<HoleDTO>>(await _holeRepository.GetHoles());

            return Ok(holes);
        }

        [HttpGet("/get-hole/{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hole>))]
        async public Task<IActionResult> GetSpecifiedHole(int Id)
        {
            var hole = _mapper.Map<Hole>(await _holeRepository.GetSpecificHole(Id));

            return Ok(hole);
        }

        [HttpPost("/create-hole")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        async public Task<IActionResult> CreateHole([FromQuery] HoleDTO hole)
        {
            if (hole == null) return BadRequest(ModelState);

            var holeMap = _mapper.Map<Hole>(hole);
            if (holeMap == null) return BadRequest(ModelState);

            bool result = await _holeRepository.CreateHole(holeMap);
            if (!result)
                return BadRequest(ModelState);
            else
                return Ok("Hole successfully created");
        }

        [HttpPut("/update-hole")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        async public Task<IActionResult> UpdateHole([Required] int Id, [FromQuery] HoleDTO hole)
        {
            bool exists = await _holeRepository.HoleExists(Id);
            if (!exists)
                return NotFound();

            var holeForUpdate = await _holeRepository.GetSpecificHole(Id);

            holeForUpdate.Name = hole.Name;
            holeForUpdate.DrillBlockId = hole.DrillBlockId;
            holeForUpdate.Depth = hole.Depth;

            bool result = await _holeRepository.UpdateHole(holeForUpdate);
            if (!result)
            {
                ModelState.AddModelError("", "Something went wrong when updating hole");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Hole has been successfully updated");
        }

        [HttpDelete("/remove-hole")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        async public Task<IActionResult> DeleteHole(int Id)
        {
            bool exists = await _holeRepository.HoleExists(Id);
            if (!exists)
                return NotFound();

            var holeToDelete = await _holeRepository.GetSpecificHole(Id);

            bool result = await _holeRepository.DeleteHole(holeToDelete);
            if (!result)
            {
                ModelState.AddModelError("", "Something went wrong when updating hole");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Hole has been successfully deleted");

        }
    }
}
