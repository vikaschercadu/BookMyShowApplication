using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Models.CoreModels;
using connString;
namespace Services.AddressService
{
    public class AddressService :IAddressService
    {
        private readonly IMapper Mapper;
        private readonly PetaPoco.Database Database;
        public AddressService(IMapper mapper,PetaPoco.Database database)
        {
            Database=database;
            Mapper = mapper;
        }
        public IEnumerable<AddressDTO> GetAddresses()
        {
            var addresses = Database.Fetch<Address>("SELECT * FROM Address");
            return Mapper.Map<List<AddressDTO>>(addresses);
        }
        public AddressDTO GetAddress(int id)
        {
            var query = $"SELECT * FROM Address WHERE id={id}";
            var address = Database.Fetch<Address>(query).FirstOrDefault();
            return Mapper.Map<AddressDTO>(address);
        }
        public void PostAddress(AddressDTO addressDTO)
        {
            string query = @"INSERT INTO Address(Id,BuildingNumber,StreetName,Landmark,CityId) VALUES(@Id,@BuildingNumber,@StreetName,@Landmark,@CityId))";
            Database.Execute(query, Mapper.Map<Address>(addressDTO));
           
        }
        public void PutAddress(int id, AddressDTO addressDTO)
        {
            string query = @"UPDATE Address SET BuildingNumber=@BuildingNumber,StrretName=@StreetName,Landmark=@Landmark,CityId=@CityId WHERE Id=@Id";
            Database.Execute(query, Mapper.Map<Address>(addressDTO));
        }
        public void DeleteAddress(int id)
        {
            string query = $"DELETE Address WHERE Id={id}";
            Database.Execute(query);
        }
    }
}