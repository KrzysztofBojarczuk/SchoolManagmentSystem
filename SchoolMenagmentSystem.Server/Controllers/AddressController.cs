using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagmentSystem.Server.Abstraction;
using SchoolManagmentSystem.Server.Dtos;
using SchoolManagmentSystem.Server.Models;
using SchoolMenagmentSystem.Server.Abstraction;

namespace SchoolManagmentSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly IAddressRepository _addressRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;

        public AddressController(IAddressRepository addressRepository, IMapper mapper, ISchoolRepository shopRepository = null)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _schoolRepository = shopRepository;
        }

        [HttpGet("{schoolId}")]
        public async Task<IActionResult> GetAddres(int schoolId)
        {
            var address = await _addressRepository.GetAddressForSchoolByIdAsync(schoolId);

            if (address == null)
            {
                return NotFound();
            }

            var addressMapped = _mapper.Map<AddressGetDto>(address);

            return Ok(addressMapped);
        }


        [HttpPost("{schoolId}")]
        public async Task<IActionResult> AddAddressToShop(int schoolId, [FromBody] AddressCreateDto addressDto)
        {
            var shop = await _schoolRepository.GetSchoolbyIdAsync(schoolId);

            if (shop == null)
            {
                return NotFound();
            }

            var addressMapped = _mapper.Map<Address>(addressDto);

            var addedAddress = await _addressRepository.CreateAddressToSchoolAsync(schoolId, addressMapped);

            if (addedAddress == null)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{schoolId}")]
        public async Task<IActionResult> UpdateAddress(int schoolId, [FromBody] AddressCreateDto addressDto)
        {
            var addressToUpdate = _mapper.Map<Address>(addressDto);

            var updatedAddress = await _addressRepository.UpdateAddressForSchoolAsync(schoolId, addressToUpdate);

            if (updatedAddress == null)
            {
                return NotFound();
            }

            var addressMapped = _mapper.Map<AddressGetDto>(updatedAddress);

            return Ok(addressMapped);
        }

        [HttpDelete("{schoolId}")]
        public async Task<IActionResult> DeleteAddressToShop(int schoolId)
        {
            var deleteAddress = await _addressRepository.DeleteAddressForSchoolAsync(schoolId);

            if (deleteAddress == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}