using AutoMapper;
using GarasAPP.Core.DTOs;
using GarasAPP.Core.Models;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels.Hotel;


namespace GarasAPP.Core.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        //private string BaseURL = "https://localhost:7163";
        private string BaseURL = "https://garasform.garassolutions.com";

        public AutoMapperProfiles()
        {
            CreateMap<Room, RoomModel>();
            CreateMap<RoomModel, Room>();
            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>(); 
            CreateMap<Room, GetRoomDto>();
            CreateMap<GetRoomDto, Room>();
            CreateMap<Rate, RateDto>();
            CreateMap<RateDto, Rate>();
            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, Reservation>();
            CreateMap<UpdataRoomDto,Room>();
            CreateMap<Room,UpdataRoomDto>();
            CreateMap<ReservationUpdataDto,Reservation>();
            CreateMap<Reservation, ReservationUpdataDto>();
            CreateMap<Reservation, ReservationRoomsDto>();
            CreateMap<ReservationRoomsDto, Reservation>();
            CreateMap<ReservationRoomsByIDDto, Reservation>();
            CreateMap<Reservation, ReservationRoomsByIDDto>();
            CreateMap<ClientDto, Client>();
            CreateMap<Client, ClientDto>();
            CreateMap<Client, GuestProfileDto>();
            CreateMap<GuestProfileDto, Client>();
            CreateMap<AddressDto, ClientAddress>();
            CreateMap<ClientAddress, AddressDto>();
         
           
        }
    }
}
