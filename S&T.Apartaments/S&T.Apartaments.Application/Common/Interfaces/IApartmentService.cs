using S_T.Apartaments.Application.Common.DTOs.ApartmentDto;
using S_T.Apartaments.Shared.Responses;

namespace S_T.Apartaments.Application.Common.Interfaces
{
    public interface IApartmentService
    {
        Task<CustomResponse<List<ApartmentDto>>> GetAllApartmentsAsync();
        Task<CustomResponse<ApartmentDto>> GetApartmentByIdAsync(int apartmentId);
        Task<CustomResponse> AddNewApartmentAsync(string userId, BaseApartmentDto addNewDto);
        Task<CustomResponse> UpdateApartmentAsync(string userId,int apartmentId, UpdateApartmentDto updateDto);
        Task<CustomResponse> DeleteApartmentAsync(string userId,int apartmentId);
    }
}
