using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CoreModels;
namespace Services.AddressService
{
    public interface IAddressService
    {
        IEnumerable<AddressDTO> GetAddresses();
        AddressDTO GetAddress(int id);
        void PostAddress(AddressDTO addressDTO);
        void PutAddress(int id, AddressDTO addressDTO);
        void DeleteAddress(int id);
    }
}
