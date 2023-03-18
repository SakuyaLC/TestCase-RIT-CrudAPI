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

        private readonly IHoleRepository _holeRepository;

        public HolePointController(IHolePointRepository holePointRepository, IHoleRepository holeRepository, IMapper mapper)
        {
            _holePointRepository = holePointRepository;
            _holeRepository = holeRepository;
            _mapper = mapper;
        }

        //Получить все точки скважин
        [HttpGet("/get-holePoints")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HolePoint>))]
        async public Task<IActionResult> GetHolePoints()
        {
            var holePoints = _mapper.Map<List<HolePointDTO>>(await _holePointRepository.GetHolePoints());

            return Ok(holePoints);
        }

        //Получить определенную точку скважины по id
        [HttpGet("/get-holePoint")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HolePoint>))]
        async public Task<IActionResult> GetSpecificHolePoint(int Id)
        {
            bool exists = await _holePointRepository.HolePointExists(Id);
            if (!exists)
                return NotFound();

            var holePoint = _mapper.Map<HolePointDTO>(await _holePointRepository.GetSpecificHolePoint(Id));

            return Ok(holePoint);
        }

        //Создать точку скважины
        [HttpPost("/create-holePoint")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        async public Task<IActionResult> CreateHolePoint([FromQuery] HolePointDTO holePoint)
        {
            bool holeExists = await _holeRepository.HoleExists(holePoint.HoleId);
            if (!holeExists)
                return NotFound();

            if (holePoint == null) return BadRequest(ModelState);

            var holePointMap = _mapper.Map<HolePoint>(holePoint);
            if (holePointMap == null) return BadRequest(ModelState);

            bool result = await _holePointRepository.CreateHolePoint(holePointMap);

            if (!result)
                return BadRequest(ModelState);
            else
                return Ok("Hole point successfully created");
        }

        //Обновить информацию в точке скважины по id
        [HttpPut("/update-holePoint")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        async public Task<IActionResult> UpdateHolePoint([FromQuery] HolePointDTO holePoint)
        {
            bool holePointExists = await _holePointRepository.HolePointExists(holePoint.Id);
            if (!holePointExists)
                return NotFound();

            bool holeExists = await _holeRepository.HoleExists(holePoint.HoleId);
            if (!holeExists)
                return NotFound();

            var holePointForUpdate = await _holePointRepository.GetSpecificHolePoint(holePoint.Id);

            holePointForUpdate.HoleId = holePoint.HoleId;
            holePointForUpdate.X = holePoint.X;
            holePointForUpdate.Y = holePoint.Y;
            holePointForUpdate.Z = holePoint.Z;

            bool result = await _holePointRepository.UpdateHolePoint(holePointForUpdate);

            if (!result)
            {
                ModelState.AddModelError("", "Something went wrong when updating hole");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Hole point has been successfully updated");
        }

        //Удалить точку скважины по id
        [HttpDelete("/remove-holePoint")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        async public Task<IActionResult> DeleteHolePoint([Required] int Id)
        {
            bool exists = await _holePointRepository.HolePointExists(Id);
            if (!exists)
                return NotFound();

            var holeToDelete = await _holePointRepository.GetSpecificHolePoint(Id);

            bool result = await _holePointRepository.DeleteHolePoint(holeToDelete);

            if (!result)
            {
                ModelState.AddModelError("", "Something went wrong when updating hole point");
                return StatusCode(500, ModelState);
            }
            else
                return Ok("Hole point has been successfully deleted");

        }
    }
}
