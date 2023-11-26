using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21Shop.Core.Domain;
using TARpe21Shop.Core.Dto;
using TARpe21Shop.Core.ServiceInterface;
using TARpe21Shop.Data;

namespace TARpe21Shop.ApplicationServices.Services
{
    public class RealEstatesServices : IRealEstatesServices
    {
        private readonly TARpe21ShopContext _context;
        public RealEstatesServices
            (
            TARpe21ShopContext context
            )
        {
            _context = context;
        }

        public async Task<RealEstate> GetAsync()
        {
            //var result = await _context.RealEstates
            //    .FirstOrDefaultAsync(x => x.Id == id);
            return null;
        }
        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new();

            realEstate.Id = Guid.NewGuid();
            realEstate.Address = dto.Address;
            realEstate.City = dto.City;
            realEstate.Country = dto.Country;
            realEstate.County = dto.County;
            realEstate.PostalCode = dto.PostalCode;
            realEstate.PhoneNumber = dto.PhoneNumber;
            realEstate.FaxNumber = dto.FaxNumber;
            realEstate.ListingDescription = dto.ListingDescription;
            realEstate.SquareMeters = dto.SquareMeters;
            realEstate.BuildDate = dto.BuildDate;
            realEstate.Price = dto.Price;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.EstateFloor = dto.EstateFloor;
            realEstate.Bathrooms = dto.Bathrooms;
            realEstate.Bedrooms = dto.Bedrooms;
            realEstate.DoesHaveParkingSpace = dto.DoesHaveParkingSpace;
            realEstate.DoesHavePowerGridConnection = dto.DoesHavePowerGridConnection;
            realEstate.DoesHaveWaterGridConnection = dto.DoesHaveWaterGridConnection;
            realEstate.IsPropertySold = dto.IsPropertySold;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.ModifiedAt = DateTime.Now;

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();  
            return realEstate;
        }
    }
}
