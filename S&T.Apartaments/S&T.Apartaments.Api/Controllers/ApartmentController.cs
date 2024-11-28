using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S_T.Apartaments.Application.Common.DTOs.ApartmentDto;
using S_T.Apartaments.Application.Common.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace S_T.Apartaments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApartmentController : BaseController
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [HttpGet("get-apartments")]
        public async Task<IActionResult> GetAllApartments()
        {
            try
            {
                var result = await _apartmentService.GetAllApartmentsAsync();
                if (!result.IsSuccessfull) { return BadRequest(string.Join(", ", result.Errors)); }
                return Response(result);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("apartment-byId")]
        public async Task<IActionResult> GetApartmentById(int id)
        {
            try
            {
                var response = await _apartmentService.GetApartmentByIdAsync(id);
                if (!response.IsSuccessfull) { return NotFound(string.Join(", ", response.Errors)); }
                return Response(response);  
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("add-apartment")]
        public async Task<IActionResult> AddNewApartment([FromBody] BaseApartmentDto dto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identified");
                
                var response = await _apartmentService.AddNewApartmentAsync(userId,dto);
                if(!response.IsSuccessfull) { return BadRequest(string.Join(", ", response.Errors)); }
                return Ok(response);
            }
            catch (DbUpdateException dbEx)
            {
                var innerMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                return StatusCode(500, $"Database Update Error: {innerMessage}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("delete-apartment/{id}")]
        public async Task<IActionResult> DeleteApartment (int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identified");
                var response = await _apartmentService.DeleteApartmentAsync(userId, id);

                if (!response.IsSuccessfull) { return BadRequest(string.Join(", ", response.Errors)); }
                return Response(response);  
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("update-apartment/{id}")]
        public async Task<IActionResult> UpdateApartment(int id, UpdateApartmentDto dto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null) return BadRequest("No user identified");
                var response = await _apartmentService.UpdateApartmentAsync(userId, id,dto);

                if (!response.IsSuccessfull) { return BadRequest(string.Join(", ", response.Errors)); }
                return Response(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  
    }
}
