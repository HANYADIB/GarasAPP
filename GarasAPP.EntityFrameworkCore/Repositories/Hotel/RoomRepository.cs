using AutoMapper;
using GarasAPP.Core;
using GarasAPP.Core.DTOs;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using System.Linq.Expressions;


namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class RoomRepository : BaseRepository<Room, int>, IRoomRepository
    {
        protected ApplicationDbContext _context;
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        public RoomRepository(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public BaseResponseWithData<Room> AddFacilities(int id, List<int>? facilities, bool updateFacility = false)
        {
            BaseResponseWithData<Room> Response = new BaseResponseWithData<Room>();
            Response.Data = new Room();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try 
            {
                if(id == 0 || facilities is null || facilities.Contains(0))
                {
                    Response.Errors.Add(new Error { code = "E-2", message = "Invalid room facilities" });
                    return Response;
                }
                if (updateFacility == true)
                {
                    foreach(var roomFacility in _context.RoomFacilities.Where(x => x.RoomId == id))
                    {
                        _context.RoomFacilities.Remove(roomFacility);
                    }

                }
                foreach (var facility in facilities)
                {
                    _context.RoomFacilities.Add(new RoomFacility { RoomId = id, FacilityId = facility });
                }
               Response.Data = Find(x => x.Id == id, new string[]  { "RoomType", "RoomView" });
                Response.Result = true;
                return Response;

            }
            catch (Exception ex) 
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return Response;
            }
        }

        public async Task<BaseResponseWithData<List<GetRoomDto>>> FindRoomAsync(FindRoomDto findRoomDto)
        {
            BaseResponseWithData<List<GetRoomDto>> Response = new BaseResponseWithData<List<GetRoomDto>>();
            Response.Data = new List<GetRoomDto>();
            Response.Errors = new List<Error>();
            Response.Result = false;
            try
            {
                if (findRoomDto == null)
                {
                    Response.Errors.Add(new Error { code = "E-2", message = "Invalid search keys" });
                    return Response;
                }

                Expression<Func<Room, bool>> filter = (x => 
                                    (findRoomDto.Name == null || x.Name.Contains(findRoomDto.Name))
                                  &&(findRoomDto.RoomType == null || x.RoomType.Type.Contains(findRoomDto.RoomType))
                                  &&(findRoomDto.RoomView == null || x.RoomView.View.Contains(findRoomDto.RoomView))
                                  &&(findRoomDto.Building == null || x.Building.BuildingName.Contains(findRoomDto.Building))
                );

                var tempRooms =_mapper.Map<List<GetRoomDto>>(FindAll(filter, new string[] { "RoomType", "Building", "RoomView" }));

                //var reservedRooms = new List<Room>();
                //if (findRoomDto.FilterByReserved)
                //{
                //    if (findRoomDto.FromDate != null || findRoomDto.ToDate != null)
                //    {
                //        reservedRooms = _context.Reservations
                //            .Where(x => x.FromDate < findRoomDto.FromDate && x.ToDate > findRoomDto.ToDate)
                //            .Select(x => x.Room).ToList();
                //        if (findRoomDto.Reserved) tempRooms = reservedRooms;
                //        else tempRooms = tempRooms.Except(reservedRooms).ToList();
                //    }
                //}

                tempRooms = GetAllWithFacilities(tempRooms);
                if (findRoomDto.Facilties != null)
                {
                    foreach (var facilityId in findRoomDto.Facilties)
                    {
                        var facility = _context.Facilities.FirstOrDefault(f => f.Id == facilityId);
                        tempRooms = tempRooms.Where(x => x.Facilities.Contains(facility)).ToList();
                    }
                }

                Response.Data = tempRooms;
                Response.Result = false;
                return Response;
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return Response;
            }

        }

        public List<GetRoomDto> GetAllWithFacilities(List<GetRoomDto> roomDtos)
        {
            for (int i =0; i<roomDtos.Count;i++)
            {
                roomDtos[i] = GetWithFacilities(roomDtos[i]);
            }
            return roomDtos;
        }

        public GetRoomDto GetWithFacilities(GetRoomDto roomDto)
        {
          
            roomDto.Facilities = _context.RoomFacilities.Where(x => x.RoomId == roomDto.Id)
                    .Select(x => x.Facility).ToList();
            roomDto.hhh = _context.RoomFacilities.Where(x => x.RoomId == roomDto.Id)
                  .Select(x => x.Facility.FacilityName).ToList();
            //roomDto.FacilitiesIds = roomDto.Facilities.Select(x => x.Id).ToList();
            roomDto.Rate = _context.Rates.FirstOrDefault(r => r.IsActive && r.RoomId == roomDto.Id).RoomRate;
            return roomDto;
        }
    }
}
