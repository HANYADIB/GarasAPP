using GarasAPP.Core.DTOs;
using GarasAPP.Core.Models.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Helpers
{
    public static class RateGridMapper
    {
        public static RateDto ToRateDto(this Rate commentModel)
        {
            return new RateDto
            {
                Id = commentModel.Id,
                RoomId = commentModel.RoomId,
                StartingDate = commentModel.StartingDate,
                EndingDate = commentModel.EndingDate,
                RoomOfferRate = commentModel.RoomRate,
                IsActive = commentModel.IsActive,
                SpecialOfferFlag =commentModel.SpecialOfferFlag

    };
        }
    }
}
