using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyAPI.IRepository;
using ParkyAPI.Models;
using ParkyAPI.Models.DTOs;

namespace ParkyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly ITrailRepository _trailRepository;
        private readonly IMapper _mapper;

        public TrailsController(ITrailRepository trailRepository, IMapper mapper)
        {
            _trailRepository = trailRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTrails()
        {
            var trails = _trailRepository.GetTrails();
            var trailDto = new List<TrailDto>();
            foreach (var trail in trails)
            {
                trailDto.Add(_mapper.Map<TrailDto>(trail));
            }

            return Ok(trailDto);
        }

        [HttpGet]
        [Route("{trailId:int}", Name = "GetTrail")]
        public IActionResult GetTrail(int trailId)
        {
            var trail = _trailRepository.GetTrail(trailId);
            if (trail == null) return NotFound();
            var trailDto = _mapper.Map<TrailDto>(trail);
            return Ok(trailDto);

        }

        [HttpPost]
        public IActionResult CreateTrail([FromBody] TrailCreateDto trailDto)
        {
            if (trailDto == null) return BadRequest(ModelState);
            if (_trailRepository.TrailExists(trailDto.Name))
            {
                ModelState.AddModelError("", "Trail Exists");
                return StatusCode(404, ModelState);
            }


            var trail = _mapper.Map<Trail>(trailDto);

            if (!_trailRepository.CreateTrail(trail))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {trail.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetTrail", new { trailId = trail.Id }, trail);
        }

        [HttpPut]
        [Route("{trailId:int}", Name = "UpdateTrail")]
        public IActionResult UpdateTrail(int trailId, [FromBody] TrailUpdateDto trailDto)
        {

            if (trailDto == null || trailDto.Id != trailId) return BadRequest(ModelState);

            var trail = _mapper.Map<Trail>(trailDto);

            if (!_trailRepository.UpdateTrail(trail))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {trail.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{trailId:int}", Name = "DeleteTrail")]
        public IActionResult DeleteTrail(int trailId)
        {

            if (!_trailRepository.TrailExists(trailId))
            {
                return NotFound();
            }

            if (!_trailRepository.DeleteTrail(_trailRepository.GetTrail(trailId)))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
