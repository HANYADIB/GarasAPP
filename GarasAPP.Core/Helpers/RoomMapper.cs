using GarasAPP.Core.DTOs;
using GarasAPP.Core.Models.HotelModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Helpers
{
    public static class RoomMapper
    {
        public static GetRoomDto ToGetRoomDto(this Room commentModel)
        {
            return new GetRoomDto
            {
                Id = commentModel.Id,
                Name = commentModel.Name,
                Description = commentModel.Description,
                RoomTypeName = commentModel.RoomType.Type,
                RoomViewName = commentModel.RoomView.View,
                BuildingName = commentModel.Building.BuildingName
                
                
            };
        }
    }
}
