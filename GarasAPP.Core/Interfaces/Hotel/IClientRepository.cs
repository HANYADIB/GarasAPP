using GarasAPP.Core.DTOs;
using GarasAPP.Core.Models;
using GarasAPP.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Interfaces.Hotel
{
    public interface IClientRepository : IBaseRepository<Client, long>
    {
        public BaseResponseWithData<GuestProfileDto> Addlanguage(long ClientId, List<int>? languageId, bool updateLanguage = false);
        public BaseResponseWithData<GuestProfileDto> AddAddress(long ClientId, List<AddressDto>? addresslist, bool updatAddress = false);

    }
}
