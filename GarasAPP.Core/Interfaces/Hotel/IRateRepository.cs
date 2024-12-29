using GarasAPP.Core.DTOs;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Interfaces.Hotel
{
    public interface IRateRepository : IBaseRepository<Rate, int>
    {
        BaseResponseWithData<List<Rate>> AddSpecialOffer(NewRateDto newRate);
        BaseResponseWithData<List<Rate>> DailyUpdate();
    }
}
