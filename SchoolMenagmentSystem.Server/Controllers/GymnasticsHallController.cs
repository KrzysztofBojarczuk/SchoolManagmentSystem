using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Server.Abstraction;
using SchoolManagmentSystem.Server.Dtos;
using SchoolManagmentSystem.Server.Models;
using SchoolManagmentSystem.Server.Repositories;

namespace SchoolManagmentSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymnasticsHallController : ControllerBase
    {
        private readonly IGymnasticsHallRepository _hallRepository;
        private readonly IMapper _mapper;

        public GymnasticsHallController(IGymnasticsHallRepository hallRepository, IMapper mapper)
        {
            _hallRepository = hallRepository;
            _mapper = mapper;
        }

        [HttpGet("school/{schoolId}")]
        public async Task<IActionResult> ListGymnasticsHalls(int schoolId)
        {
            var halls = await _hallRepository.ListGymnasticsHallsAsync(schoolId);
            var hallsDto = _mapper.Map<List<GymnasticsHallGetDto>>(halls);
            return Ok(hallsDto);
        }

        [HttpGet("school/hall/{hallId}")]
        public async Task<IActionResult> GetGymnasticsHallById( int hallId)
        {
            var hall = await _hallRepository.GetGymnasticsHallByIdAsync(hallId);
            if (hall == null)
            {
                return NotFound();
            }
            var hallDto = _mapper.Map<GymnasticsHallGetDto>(hall);
            return Ok(hallDto);
        }

        [HttpPost("school/{schoolId}")]
        public async Task<IActionResult> CreateGymnasticsHall(int schoolId, [FromBody] GymnasticsHallPostPutDto hallCreateDto)
        {
            var hallToCreate = _mapper.Map<GymnasticsHall>(hallCreateDto);
            var createdHall = await _hallRepository.CreateGymnasticsHallAsync(schoolId, hallToCreate);
            if (createdHall == null)
            {
                return BadRequest();
            }
            var hallDto = _mapper.Map<GymnasticsHallGetDto>(createdHall);

            return CreatedAtAction(nameof(GetGymnasticsHallById), new { schoolId = schoolId, hallId = hallDto.GymnasticsHallId }, hallDto);
        }

        [HttpPut("school/{schoolId}/hall/{hallId}")]
        public async Task<IActionResult> UpdateGymnasticsHall(int schoolId, int hallId, [FromBody] GymnasticsHallPostPutDto hallUpdateDto)
        {
            var hallToUpdate = _mapper.Map<GymnasticsHall>(hallUpdateDto);

            hallToUpdate.GymnasticsHallId = hallId;
            hallToUpdate.SchoolId = schoolId;

            var updatedHall = await _hallRepository.UpdateGymnasticsHallAsync(schoolId, hallToUpdate);
            if (updatedHall == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("school/{schoolId}/hall/{hallId}")]
        public async Task<IActionResult> DeleteGymnasticsHall(int schoolId, int hallId)
        {
            var deletedHall = await _hallRepository.DeleteGymnasticsHallAsync(schoolId, hallId);
            if (deletedHall == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("getNumberOfGymnasticsHalls")]
        public async Task<IActionResult> GetNumberOfGymnasticsHallsBySchoolById(int schoolId)
        {
            var numberOfHalls = await _hallRepository.GetNumberOfGymnasticsHallsBySchoolByIdAsync(schoolId);
            if (numberOfHalls == 0)
            {
                return NotFound();
            }

            return Ok(numberOfHalls);
        }
    }
}
