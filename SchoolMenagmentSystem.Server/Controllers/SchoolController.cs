using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Server.Enums;
using SchoolMenagmentSystem.Server.Abstraction;
using SchoolMenagmentSystem.Server.Dtos;
using SchoolMenagmentSystem.Server.Models;
using System.Diagnostics.Metrics;

namespace SchoolMenagmentSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _shoolRepository;
        private readonly IMapper _mapper;

        public SchoolController(ISchoolRepository shoolRepository, IMapper mapper)
        {
            _shoolRepository = shoolRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlSchool(string searchTerm = null, [FromQuery] List<SchoolType> enumSchool = null)
        {
            var school = await _shoolRepository.GetAllSchoolAsync(searchTerm, enumSchool);

            var schoolGet =_mapper.Map<List<SchoolGetDto>>(school);

            return Ok(schoolGet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchool([FromBody] SchoolCreateDto school)
        {
            var schoolCreate = _mapper.Map<School>(school);

            await _shoolRepository.CreateSchoolAsync(schoolCreate);

            var schoolGet = _mapper.Map<SchoolGetDto>(schoolCreate);

            return CreatedAtAction(nameof(GetSchoolById), new { id = schoolGet.SchoolId }, schoolGet  );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchoolById(int id)
        {
            var school = await _shoolRepository.GetSchoolbyIdAsync(id);

            if(school == null) 
            {

                return NotFound();
            }

            var schoolGet = _mapper.Map<SchoolGetDto>(school);

            return Ok(schoolGet);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(int id, SchoolCreateDto school)
        {
            var toSchoolUpdate = _mapper.Map<School>(school);

            toSchoolUpdate.SchoolId = id;

            await _shoolRepository.UpdateSchoolAsync(toSchoolUpdate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var schoolToDelete = await _shoolRepository.DeleteSchooldAsync(id);

            if (schoolToDelete == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
