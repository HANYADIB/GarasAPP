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
    public interface IReservationRepository : IBaseRepository<Reservation, int>
    {
        BaseResponseWithData<List<Reservation>> GetRoomReservations(DurationDto? durationDto, int roomId = 0);
        BaseResponseWithData<List<Reservation>> AllReservedRooms(DurationDto? durationDto, int roomId = 0);
        public BaseResponseWithData<List<RoomReservationDto>> GetRoomReservationsGrid(DurationDto2 durationDto, int? roomTypeId, int? roomviewId, int? roombuildingId);
        public BaseResponseWithData<List<ReservationRoomsDto>> GetAllRoomReservations(DurationDto? durationDto, List<int> roomIds);
        public List<ReservationRoomsDto> GetAllWithRooms(List<ReservationRoomsDto> roomDtos);
        public ReservationRoomsDto GetWithRoom(ReservationRoomsDto roomDto);
        public BaseResponseWithData<List<ReservationRoomsDto>> GetAllRoomReservationsForAdding(DurationDto? durationDto, List<int> roomIds);
        public BaseResponseWithData<Reservation> AddRooms(int id, List<AddListofReservationDto> addlist, bool updateFacility = false);
        public BaseResponseWithData<List<Reservation>> NotGetRoomReservations(DurationDto? durationDto, List<int> roomIds, int Id);
        public BaseResponseWithData<List<Reservation>> GetRoomReservationsfortesting(DurationDto? durationDto, int roomId = 0, int reservationId = 0);
        public ReservationRoomsByIDDto GetWithRoomandmealandchildern(ReservationRoomsByIDDto roomDto);




    }
}
