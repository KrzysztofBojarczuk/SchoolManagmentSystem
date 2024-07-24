using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Server.Abstraction;
using SchoolManagmentSystem.Server.Dtos;
using SchoolManagmentSystem.Server.Models;

namespace SchoolManagmentSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassController(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        [HttpGet("school/{schoolId}")]
        public async Task<IActionResult> ListSchoolClasses(int schoolId)
        {
            var classes = await _classRepository.ListSchoolClassesAsync(schoolId);

            var classesGetDto = _mapper.Map<List<ClassGetDto>>(classes);

            return Ok(classesGetDto);
        }

        [HttpGet("school/class/{classId}")]
        public async Task<IActionResult> GetSchoolClassById( int classId)
        {
            var schoolClass = await _classRepository.GetSchoolClassByIdAsync(classId);

            if (schoolClass == null)
            {
                return NotFound();
            }

            var classGetDto = _mapper.Map<ClassGetDto>(schoolClass);

            return Ok(classGetDto);
        }

        [HttpPost("school/{schoolId}")]
        public async Task<IActionResult> CreateSchoolClass(int schoolId, [FromBody] ClassCreateDto classCreateDto)
        {
            var classToCreate = _mapper.Map<Class>(classCreateDto);

            var createdClass = await _classRepository.CreateSchoolClassAsync(schoolId, classToCreate);

            var classGetDto = _mapper.Map<ClassGetDto>(createdClass);

            return CreatedAtAction(nameof(GetSchoolClassById), new { schoolId = schoolId, classId = classGetDto.ClassId }, classGetDto);
        }

        [HttpPut("school/{schoolId}/class/{classId}")]
        public async Task<IActionResult> UpdateSchoolClass(int schoolId, int classId, [FromBody] ClassCreateDto classUpdateDto)
        {
            var classToUpdate = _mapper.Map<Class>(classUpdateDto);
            classToUpdate.ClassId = classId;
            classToUpdate.SchoolId = schoolId;

            await _classRepository.UpdateSchoolClassAsync(schoolId, classToUpdate);
     
            return NoContent();
        }

        [HttpDelete("school/{schoolId}/class/{classId}")]
        public async Task<IActionResult> DeleteSchoolClass(int schoolId, int classId)
        {
            var deletedClass = await _classRepository.DeleteSchoolClassAsync(schoolId, classId);

            if (deletedClass == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("getNumberOfSchool")]
        public async Task<IActionResult> GetNumberOfClassesBySchooldById(int schoolId)
        {
            var numberOfClasses = await _classRepository.GetNumberOfClassesBySchoolByIdAsync(schoolId);

            if (numberOfClasses == null)
            {

                return NotFound();
            }

            return Ok(numberOfClasses);
        }
    }
}
