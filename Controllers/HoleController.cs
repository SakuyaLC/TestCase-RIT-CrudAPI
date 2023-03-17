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
        public IActionResult GetHoles()
        {
            var holes = _mapper.Map<List<HoleDTO>>(_holeRepository.GetHoles().Result);

            return Ok(holes);
        }

        [HttpGet("/get-hole/{Id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hole>))]
        public IActionResult GetSpecifiedHole(int Id)
        {
            var hole = _mapper.Map<Hole>(_holeRepository.GetSpecificHole(Id).Result);

            return Ok(hole);
        }

        [HttpPost("/create-hole")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateHole([FromQuery] HoleDTO hole)
        {
            if (hole == null) return BadRequest(ModelState);

            var holeMap = _mapper.Map<Hole>(hole);
            if (holeMap == null) return BadRequest(ModelState);

            if (!_holeRepository.CreateHole(holeMap).Result)
                return BadRequest(ModelState);
            else
                return Ok("Hole successfully created");
        }

        [HttpPut("/update-hole")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult UpdateHole([Required] int Id, [FromQuery] HoleDTO hole)
        {
            if (!_holeRepository.HoleExists(Id).Result)
                return NotFound();

            var holeForUpdate = _holeRepository.GetSpecificHole(Id).Result;

            holeForUpdate.Name = hole.Name;
            holeForUpdate.DrillBlockId = hole.DrillBlockId;
            holeForUpdate.Depth = hole.Depth;

            if (!_holeRepository.UpdateHole(holeForUpdate).Result)
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
        public IActionResult DeleteHole(int Id)
        {
            if (!_holeRepository.HoleExists(Id).Result)
                return NotFound();

            var holeToDelete = _holeRepository.GetSpecificHole(Id).Result;

            if (!_holeRepository.DeleteHole(holeToDelete).Result)
            {
                ModelState.AddModelError("", "Something went wrong when updating hole");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Hole has been successfully deleted");

        }
    }
}
