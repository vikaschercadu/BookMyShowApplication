using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Services.AddressService;
using Models.CoreModels;
namespace BookMyShow.Controllers
{
    public class AddressController : ApiController
    {
        private readonly IAddressService AddressService;
        public AddressController(IAddressService addressService)
        {
            AddressService = addressService;

        }
        // GET: api/Address
        public IEnumerable<AddressDTO> Get()
        {
            return AddressService.GetAddresses();
        }

        // GET: api/Address/5
        public AddressDTO Get(int id)
        {
            return AddressService.GetAddress(id);
        }

        // POST: api/Address
        public void Post(AddressDTO addressDTO)
        {
            AddressService.PostAddress(addressDTO);
        }

        // PUT: api/Address/5
        public void Put(int id,AddressDTO addressDTO)
        {
            AddressService.PutAddress(id, addressDTO);
        }

        // DELETE: api/Address/5
        public void Delete(int id)
        {
            AddressService.DeleteAddress(id);
        }
    }
}
