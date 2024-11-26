using AutoMapper;
using S_T.Apartaments.Application.Common.DTOs.ApartmentDto;
using S_T.Apartaments.Application.Common.Interfaces;
using S_T.Apartaments.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Application.Repositories
{
    public class ApartmentService : IApartmentService
    {
        private readonly IMapper _mapper;
        private readonly IApartmentDbContext _aptDbContext;

        public ApartmentService(IMapper mapper,IApartmentDbContext aptDbContext) 
        {
            _mapper = mapper;
            _aptDbContext = aptDbContext;
        }
        public Task<CustomResponse> AddNewApartmentAsync(string userId, BaseApartmentDto addNewDto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse> DeleteApartmentAsync(string userId, int apartmentId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse<List<ApartmentDto>>> GetAllApartmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse<ApartmentDto>> GetApartmentByIdAsync(int apartmentId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponse> UpdateApartmentAsync(string userId, int apartmentId, BaseApartmentDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
