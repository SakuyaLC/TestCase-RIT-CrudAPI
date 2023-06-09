﻿using AutoMapper;
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

        private readonly IDrillBlockRepository _drillBlockRepository;

        public HoleController(IHoleRepository holeRepository, IDrillBlockRepository drillBlockRepository, IMapper mapper)
        {
            _holeRepository = holeRepository;
            _drillBlockRepository = drillBlockRepository;
            _mapper = mapper;
        }

        //Получить все скважины
        [HttpGet("/get-holes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hole>))]
        async public Task<IActionResult> GetHoles()
        {
            var holes = _mapper.Map<List<HoleDTO>>(await _holeRepository.GetHoles());

            return Ok(holes);
        }

        //Получить определенную скважину по id
        [HttpGet("/get-hole")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hole>))]
        async public Task<IActionResult> GetSpecificHole(int Id)
        {
            bool exists = await _holeRepository.HoleExists(Id);
            if (!exists)
                return NotFound();

            var hole = _mapper.Map<HoleDTO>(await _holeRepository.GetSpecificHole(Id));

            return Ok(hole);
        }

        //Создать скважину
        [HttpPost("/create-hole")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        async public Task<IActionResult> CreateHole([FromQuery] HoleDTO hole)
        {
            if (hole == null) return BadRequest(ModelState);

            bool exists = await _drillBlockRepository.DrillBlockExists(hole.DrillBlockId);
            if (!exists)
                return NotFound();

            var holeMap = _mapper.Map<Hole>(hole);
            if (holeMap == null) return BadRequest(ModelState);

            bool result = await _holeRepository.CreateHole(holeMap);
            if (!result)
                return BadRequest(ModelState);
            else
                return Ok("Hole successfully created");
        }

        //Обновить скважину по id
        [HttpPut("/update-hole")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        async public Task<IActionResult> UpdateHole([FromQuery] HoleDTO hole)
        {
            bool holeExists = await _holeRepository.HoleExists(hole.Id);
            if (!holeExists)
                return NotFound();

            bool drillBlockExists = await _drillBlockRepository.DrillBlockExists(hole.DrillBlockId);
            if (!drillBlockExists)
                return NotFound();

            var holeForUpdate = await _holeRepository.GetSpecificHole(hole.Id);

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

        //Удалить скважину по id
        [HttpDelete("/remove-hole")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        async public Task<IActionResult> DeleteHole([Required] int Id)
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
