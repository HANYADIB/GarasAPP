using GarasAPP.Core.DTOs;
using GarasAPP.Core.Models;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.Core.Interfaces.Hotel
{
    public interface IRoomRepository : IBaseRepository<Room, int>
    {
        BaseResponseWithData<Room> AddFacilities(int id, List<int>? facilities, bool updateFacility = false);
        Task<BaseResponseWithData<List<GetRoomDto>>> FindRoomAsync(FindRoomDto findRoomDto);
        List<GetRoomDto> GetAllWithFacilities(List<GetRoomDto> roomDtos);
        GetRoomDto GetWithFacilities(GetRoomDto roomDto);
    }
}
