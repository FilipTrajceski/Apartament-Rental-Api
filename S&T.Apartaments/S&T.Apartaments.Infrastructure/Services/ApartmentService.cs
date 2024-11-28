using AutoMapper;
using Microsoft.EntityFrameworkCore;
using S_T.Apartaments.Application.Common.DTOs.ApartmentDto;
using S_T.Apartaments.Application.Common.Interfaces;
using S_T.Apartaments.Entities.Entities;
using S_T.Apartaments.Infrastructure.DataLayer;
using S_T.Apartaments.Shared.CustomExceptions.ApartmentException;
using S_T.Apartaments.Shared.Responses;


namespace S_T.Apartaments.Application.Repositories
{
    public class ApartmentService : IApartmentService
    {
        private readonly IMapper _mapper;
        private readonly RentalDbContext _aptDbContext;

        public ApartmentService(IMapper mapper, RentalDbContext aptDbContext ) 
        {
            _mapper = mapper;
            _aptDbContext = aptDbContext;
        }
        public async Task<CustomResponse> AddNewApartmentAsync(string userId, BaseApartmentDto addNewDto)
        {
            try
            {
               var user = await _aptDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if(user.Role != Entities.Enums.UserRole.Owner) { return new CustomResponse("You can't add a apartment (only owners!)"); }

                var apartmentCheck = await _aptDbContext.Apartments.FirstOrDefaultAsync(x => x.Address == addNewDto.Address);
                if(apartmentCheck != null) { return new CustomResponse("An apartment already exists on that address"); }

                var apartment = _mapper.Map<Apartment>(addNewDto);
                apartment.OwnerName = user.UserName;
                apartment.CreatedDate= DateTime.Now;
                apartment.OwnerId = user.Id;
                await _aptDbContext.Apartments.AddAsync(apartment);
                await _aptDbContext.SaveChangesAsync();

                return new CustomResponse("Apartment added succesfully!") { IsSuccessfull=true};
            }
            catch (ApartmentDataException ex)
            {
                throw new ApartmentDataException(ex.Message);
            }
            catch (ApartmentNotFoundException ex)
            {
                throw new ApartmentNotFoundException(ex.Message);
            }
        }

        public async Task<CustomResponse> DeleteApartmentAsync(string userId, int apartmentId)
        {
            try
            {
                var user = await _aptDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
                var apartment = await _aptDbContext.Apartments.FindAsync(apartmentId);

                if (user.Role == Entities.Enums.UserRole.Renter) { return new CustomResponse("You can't perform this action!") { IsSuccessfull= false}; }
                if(user.Id != apartment.OwnerId ) { return new CustomResponse("You can't delete this apartment!") { IsSuccessfull = false }; }

                 _aptDbContext.Remove(apartment);
                 await _aptDbContext.SaveChangesAsync();

                return new CustomResponse($"Apartment with id: {apartment.ApartmentId} deleted succesfully!") { IsSuccessfull= true};
            }
            catch (ApartmentDataException ex)
            {
                throw new ApartmentDataException(ex.Message);
            }
            catch (ApartmentNotFoundException ex)
            {
                throw new ApartmentNotFoundException(ex.Message);
            }
        }

        public async Task<CustomResponse<List<ApartmentDto>>> GetAllApartmentsAsync()
        {
            try
            {
                var apartments = await _aptDbContext.Apartments.ToListAsync();
                var response = apartments.Select(apartment => _mapper.Map<ApartmentDto>(apartment)).ToList();

                if (!response.Any())
                {
                    return new CustomResponse<List<ApartmentDto>>("No apartments available at the moment!");
                }

                return new CustomResponse<List<ApartmentDto>>(response);

            }
            catch (ApartmentDataException ex)
            {
                throw new ApartmentDataException(ex.Message);
            }
            catch(ApartmentNotFoundException ex)
            {
                throw new ApartmentNotFoundException(ex.Message);
            }
        }

        public async Task<CustomResponse<ApartmentDto>> GetApartmentByIdAsync(int apartmentId)
        {
            try
            {
                var apartment = await _aptDbContext.Apartments.FindAsync(apartmentId);
                if(apartment is null) { return new CustomResponse<ApartmentDto>($"Apartment with id: {apartmentId} doesn't exist!"); }

                var apartmentDto = _mapper.Map<ApartmentDto>(apartment);
                return new CustomResponse<ApartmentDto>(apartmentDto);
            }
            catch(ApartmentDataException ex)
            {
                throw new ApartmentDataException(ex.Message);
            }
            catch (ApartmentNotFoundException ex)
            {
                throw new ApartmentNotFoundException(ex.Message);
            }
        }

        public async Task<CustomResponse> UpdateApartmentAsync(string userId, int apartmentId, UpdateApartmentDto updateDto)
        {
            try
            {
                var user = await _aptDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
                var apartment = await _aptDbContext.Apartments.FindAsync(apartmentId);

                if(user.Role != Entities.Enums.UserRole.Owner) { return new CustomResponse("You can't perform this action!"); };
                if(user.Id != apartment.OwnerId) { return new CustomResponse("You cannot update this apartment"); }

                apartment.ApartmentStatus = updateDto.Status;
                apartment.ApartmentSize = updateDto.Size;
                if (updateDto.Status == Entities.Enums.ApartmentStatus.Under_Maintenance)
                {
                    apartment.Description = "The apartment is currently under maintenance.";
                }
                else if (updateDto.Status == Entities.Enums.ApartmentStatus.Renovating)
                {
                    apartment.Description = "The apartment has ongoing renovations.";
                }
                else
                {
                    apartment.Description = updateDto.ReasonForUpdate;
                }
                apartment.LastUpdatedDate = DateTime.Now;

                 _aptDbContext.Update(apartment);
                await _aptDbContext.SaveChangesAsync();

                return new CustomResponse($"Apartment with id: {apartment.ApartmentId} has been updated!");
            }
            catch (ApartmentDataException ex)
            {
                throw new ApartmentDataException(ex.Message);
            }
            catch (ApartmentNotFoundException ex)
            {
                throw new ApartmentNotFoundException(ex.Message);
            }
        }
    }
}
