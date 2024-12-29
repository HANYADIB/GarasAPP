using AutoMapper;
using GarasAPP.Core.DTOs;
using GarasAPP.Core.Helpers;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class ReservationRepository : BaseRepository<Reservation, int>, IReservationRepository
    {
        protected ApplicationDbContext _context;
        protected IMapper _mapper;
        public ReservationRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public BaseResponseWithData<List<Reservation>> GetRoomReservationsfortesting(DurationDto? durationDto , int roomId = 0 , int reservationId = 0)
        {
            BaseResponseWithData<List<Reservation>> Response = new BaseResponseWithData<List<Reservation>>();
            Response.Data = new List<Reservation>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                if(durationDto.StartDate > durationDto.EndDate)
                {
                    Response.Result = false;
                    Response.Errors.Add(new Error { code = "E-2", message = "End date must be before start date" });
                    return Response;
                }
                if (roomId > 0)
                {
                    var temp = new List<Reservation>();

                    var room = _context.RoomsReservations.Where(X => X.RoomId == roomId).Any();
                    var reservationNum = _context.RoomsReservations.Where(x => x.RoomId == roomId && x.ReservationId != reservationId).Select(x => x.Reservation).ToList();
                    for (int i = 0; i < reservationNum.Count; i++)
                    {
                        var tempdata = _context.Reservations.Where(x => x.Id == reservationNum[i].Id && x.ToDate > durationDto.StartDate && x.FromDate < durationDto.EndDate).ToList();
                        if (tempdata.Count !=0)
                        {
                            //int y = 0;
                            //temp[y] = tempdata;
                            //y++;
                            Response.Result = true;
                            Response.Data = tempdata;

                            return Response;


                        }

                    }
                }
                
                    return Response;
                
               

               
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return Response;
            }
        }

        public BaseResponseWithData<List<Reservation>> GetRoomReservations(DurationDto? durationDto, int roomId = 0)
        {
            BaseResponseWithData<List<Reservation>> Response = new BaseResponseWithData<List<Reservation>>();
            Response.Data = new List<Reservation>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                if (durationDto.StartDate > durationDto.EndDate)
                {
                    Response.Result = false;
                    Response.Errors.Add(new Error { code = "E-2", message = "End date must be before start date" });
                    return Response;
                }
                if (roomId > 0)
                {
                    var room = _context.RoomsReservations.Where(X => X.RoomId == roomId).Any();
                    Response.Data = _context.Reservations.Where(r => (
                                     r.ToDate > durationDto.StartDate
                                    && r.FromDate < durationDto.EndDate) && room).ToList();
                }
                else
                {
                    Response.Data = _context.Reservations.Where(r => r.ToDate >= durationDto.StartDate
                                    && r.FromDate <= durationDto.EndDate).ToList();
                }

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

        public BaseResponseWithData<List<Reservation>> AllReservedRooms(DurationDto? durationDto, int roomId = 0)
        {
            BaseResponseWithData<List<Reservation>> Response = new BaseResponseWithData<List<Reservation>>();
            Response.Data = new List<Reservation>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                if (durationDto.StartDate > durationDto.EndDate)
                {
                    Response.Result = false;
                    Response.Errors.Add(new Error { code = "E-2", message = "End date must be before start date" });
                    return Response;
                }
                if (roomId > 0)
                {
                    //var test = new List<Reservation>();
                    var rooms = _context.RoomsReservations.Where(X => X.RoomId == roomId).Select(x=>x.Reservation).ToList();
                    Response.Data = rooms.Where(r => r.ToDate > durationDto.StartDate && r.FromDate < durationDto.EndDate).ToList();
                    //foreach (var room in rooms)
                    //{
                    //    test = _context.Reservations.Where(r => (
                    //                      r.ToDate > durationDto.StartDate
                    //                     && r.FromDate < durationDto.EndDate) && r.Id == room.Id).ToList();
                    //    Response.Data.Add(test);

                    //}
                }
                else
                {
                    Response.Data = _context.Reservations.Where(r => r.ToDate >= durationDto.StartDate
                                    && r.FromDate <= durationDto.EndDate).ToList();
                }

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

        public BaseResponseWithData<List<ReservationRoomsDto>> GetAllRoomReservations(DurationDto? durationDto, List<int> roomIds )
        {
            BaseResponseWithData<List<ReservationRoomsDto>> Response = new BaseResponseWithData<List<ReservationRoomsDto>>();
            Response.Data = new List<ReservationRoomsDto>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                if (durationDto.StartDate > durationDto.EndDate)
                {
                    Response.Result = false;
                    Response.Errors.Add(new Error { code = "E-2", message = "End date must be before start date" });
                    return Response;
                }
                for (int i=0;roomIds.Count>i;i++)
                {
                    if (roomIds[i] > 0)
                    {
                        var room = _context.RoomsReservations.Where(X => X.RoomId == roomIds[i]).Any();
                        var tempdata = _context.Reservations.Where(r => (
                                          r.ToDate >= durationDto.StartDate
                                         && r.FromDate <= durationDto.EndDate) && room).ToList();
                       
                        Response.Data = GetAllWithRooms(_mapper.Map<List<ReservationRoomsDto>>(tempdata));
                    }

                    else
                    {
                        var tempdata = _context.Reservations.Where(r => r.ToDate >= durationDto.StartDate
                                         && r.FromDate <= durationDto.EndDate).ToList();
                        Response.Data = GetAllWithRooms(_mapper.Map<List<ReservationRoomsDto>>(tempdata));

                    }
                }
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

        public BaseResponseWithData<List<RoomReservationDto>> GetRoomReservationsGrid(DurationDto2 durationDto, int? roomTypeId, int? roomviewId, int? roombuildingId)
        {
            BaseResponseWithData<List<RoomReservationDto>> Response = new BaseResponseWithData<List<RoomReservationDto>>();
            Response.Data = new List<RoomReservationDto>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                List<RoomReservationDto> roomReservationDto = new List<RoomReservationDto>();
                var allRooms = new List<Room>();
                if (roomTypeId == 0 && roomviewId == 0 && roombuildingId == 0)
                {
                    allRooms = _context.Rooms.ToList();
                }
                else
                {
                    allRooms = _context.Rooms.Where(x => x.RoomType.Id == roomTypeId && x.RoomView.Id == roomviewId && x.Building.Id == roombuildingId).ToList();
                }
                foreach (var room in allRooms)
                {
                    RoomReservationDto tempRoomReservation = new RoomReservationDto();
                    tempRoomReservation.Room = room;
                    //var test = _context.RoomsReservations.Where(x => x.RoomId == room.Id).Select(y => y.Reservation.Id).ToList();
                    var tempdata = _context.RoomsReservations.Include(x=>x.Reservation.Clients).Where(x => x.RoomId == room.Id).Select(x=>x.Reservation).ToList();                   
                    var tempdata1 = tempdata.Where(r => r.ToDate > durationDto.StartDate && r.FromDate < durationDto.EndDate).ToList();
                    tempRoomReservation.reservations = tempdata1.Select(c => c.ToReservationGridDto()).ToList();
                    // tempRoomReservation.ClientName = _context.Clients.FirstOrDefault(x => x.Id == tempRoomReservation.reservations[0].ClientId).Name;

                    var tempdataRates = _context.Rates.
                        Where(x => x.RoomId == room.Id && x.EndingDate > durationDto.StartDate && x.StartingDate < durationDto.EndDate).ToList();
                    foreach (var item in tempdataRates)
                    {
                        if ( tempdataRates !=null) {
                            if (item.IsDefault == false && durationDto.StartDate > item.StartingDate)
                            {
                                item.StartingDate = durationDto.StartDate;
                            }
                            else if (item.IsDefault == false && item.EndingDate > durationDto.EndDate) 
                            {
                                item.EndingDate = durationDto.EndDate;
                            }
                        }
                    }
                    tempRoomReservation.rate = tempdataRates.Select(c => c.ToRateDto()).ToList();

                    //tempRoomReservation.reservations = _context.Reservations
                    //    .Where(r =>(
                    //                r.ToDate > durationDto.StartDate
                    //               && r.FromDate < durationDto.EndDate) 
                    //               && _context.RoomsReservations.Where(x=>x.RoomId==room.Id) ).ToList();
                    roomReservationDto.Add(tempRoomReservation);
                }
                Response.Data = roomReservationDto;
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



        //public BaseResponseWithData<List<RoomReservationDto>> GetRoomReservationsGrid(DurationDto? durationDto)
        //{
        //    BaseResponseWithData<List<RoomReservationDto>> Response = new BaseResponseWithData<List<RoomReservationDto>>();
        //    Response.Data = new List<RoomReservationDto>();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;
        //    List<RoomReservationDto> roomReservationDto = new List<RoomReservationDto>();

        //    try
        //    {
        //        var allRooms = _context.Rooms.ToList();
        //        foreach (var room in allRooms)
        //        {
        //            RoomReservationDto tempRoomReservation = new RoomReservationDto();
        //            tempRoomReservation.Room = room;
        //            tempRoomReservation.reservations = _context.Reservations.Where(r => r.RoomId == room.Id
        //                            && r.ToDate > durationDto.StartDate
        //                            && r.FromDate < durationDto.EndDate).ToList();
        //            roomReservationDto.Add(tempRoomReservation);
        //        }
        //        Response.Data = roomReservationDto;
        //        Response.Result = true;
        //        return Response;

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Result = false;
        //        Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
        //        return Response;
        //    }
        //}
        public List<ReservationRoomsDto> GetAllWithRooms(List<ReservationRoomsDto> roomDtos)
        {
          
            for (int i = 0; i < roomDtos.Count; i++)
            {
 
                roomDtos[i] = GetWithRoom(roomDtos[i]);
            }
            return roomDtos;
        }

        public ReservationRoomsDto GetWithRoom(ReservationRoomsDto roomDto)
        {
            roomDto.Rooms = _context.RoomsReservations.Where(x => x.ReservationId == roomDto.Id)
                    .Select(x => x.Room).ToList();
            //roomDto.FacilitiesIds = roomDto.Facilities.Select(x => x.Id).ToList();
            List<int> Rates = new List<int>();

            for (int y = 0;y<roomDto.Rooms.Count;y++ ) {
                var tempdata = _context.Rates.FirstOrDefault(r => r.IsActive && r.RoomId == (roomDto.Rooms[y].Id)).RoomRate;
                Rates.Add(tempdata);
                //roomDto.Rate[y] = test;
                // roomDto.Rate.Add(test);


                roomDto.Rate = Rates;

            }

            //roomDto.Rate = _context.Rates.FirstOrDefault(r => r.IsActive && r.RoomId == roomDto.Rooms.Select(x => x.Id).FirstOrDefault()).RoomRate;
            // roomDto.Rate[i] = 1000;
            //roomDto.Rate =(List<int>) _context.Rates.Where(r => r.IsActive &&r.RoomId==roomDto.Rooms.Select(x=>x.Id).ToList() ).RoomRate;
            return roomDto;
        }

        public ReservationRoomsByIDDto GetWithRoomandmealandchildern(ReservationRoomsByIDDto roomDto)
        {
            var Rooms = _context.RoomsReservations.Where(x => x.ReservationId == roomDto.Id)
                    .Select(x => x.Room.Id).ToList();

            var alltempdata = new AddlistreservationByIDDto();
            var alldata = new List<AddlistreservationByIDDto>();
            if (Rooms.Count>0) 
            {
                for (int i = 0; Rooms.Count > i; i++)
                {
                    alltempdata.NumAdults = _context.RoomsReservationChilderns.Where(x => x.ReservationId == roomDto.Id && x.RoomId == Rooms[i]).Select(x => x.NumbersofAdulte).First();
                    alltempdata.RoomName = _context.RoomsReservations.Where(x => x.ReservationId == roomDto.Id && x.RoomId == Rooms[i])
                            .Select(x => x.Room.Name).FirstOrDefault();
                    alltempdata.MealName = _context.RoomsReservationMeals.Where(x => x.ReservationId == roomDto.Id).Select(x => x.MealType.Name).FirstOrDefault();
                    alltempdata.NumChildern = _context.Childerns.Where(x => x.ReservationId == roomDto.Id && x.RoomId == Rooms[i]).Count();
                    alltempdata.YearsofChildern = _context.Childerns.Where(x => x.ReservationId == roomDto.Id && x.RoomId == Rooms[i]).Select(x => x.Years).ToList();

                    alldata.Add(alltempdata);
                }
            }
            roomDto.Reservationdetails = alldata;
            return roomDto;
        }


        //public ReservationRoomsByIDDto GetWithRoomandmealandchildern(ReservationRoomsByIDDto roomDto)
        //{
        //    var Rooms = _context.RoomsReservations.Where(x => x.ReservationId == roomDto.Id)
        //            .Select(x => x.Room.Id).ToList();
        //    if (Rooms.Count > 0)
        //    {
        //        for (int i = 0; Rooms.Count > i; i++)
        //        {
        //            roomDto.addlist[i].NumAdults = _context.RoomsReservationChilderns.Where(x => x.ReservationId == roomDto.Id && x.RoomId == Rooms[i]).Select(x => x.NumbersofAdulte).FirstOrDefault();

        //            string test = _context.RoomsReservations.Where(x => x.ReservationId == roomDto.Id && x.RoomId == Rooms[i])
        //                    .Select(x => x.Room.Name).FirstOrDefault();
        //            roomDto.addlist[i].RoomName = test;
        //            roomDto.addlist[i].MealName = _context.RoomsReservationMeals.Where(x => x.ReservationId == roomDto.Id).Select(x => x.MealType.Name).FirstOrDefault();
        //            roomDto.addlist[i].NumChildern = _context.Childerns.Where(x => x.ReservationId == roomDto.Id && x.RoomId == Rooms[i]).Count();
        //            int counter = _context.Childerns.Where(x => x.ReservationId == roomDto.Id && x.RoomId == Rooms[i]).Count();
        //            roomDto.addlist[i].YearsofChildern = _context.Childerns.Where(x => x.ReservationId == roomDto.Id && x.RoomId == Rooms[i]).Select(x => x.Years).ToList();

        //        }
        //    }
        //    return roomDto;
        //}


        //    //roomDto.Rate = _context.Rates.FirstOrDefault(r => r.IsActive && r.RoomId == roomDto.Rooms.Select(x => x.Id).FirstOrDefault()).RoomRate;
        //    // roomDto.Rate[i] = 1000;
        //    //roomDto.Rate =(List<int>) _context.Rates.Where(r => r.IsActive &&r.RoomId==roomDto.Rooms.Select(x=>x.Id).ToList() ).RoomRate;
        //    return roomDto;
        //}

        public BaseResponseWithData<Reservation> AddRooms(int id, List<AddListofReservationDto> addlist,bool updateFacility = false)
        {
            BaseResponseWithData<Reservation> Response = new BaseResponseWithData<Reservation>();
            Response.Data = new Reservation();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                for (int i = 0; addlist.Count > i; i++)
                {
                    if (id == 0 || addlist[i].RoomId is 0 || addlist[i].RoomId is EmptyResult)
                    {
                        Response.Errors.Add(new Error { code = "E-2", message = "Invalid room reservation" });
                        return Response;
                    } 
                }
                if (updateFacility == true)
                {
                    foreach (var roomReservation in _context.RoomsReservations.Where(x => x.ReservationId == id))
                    {
                        _context.RoomsReservations.Remove(roomReservation);
                    } 
                    foreach (var roomReservation in _context.RoomsReservationMeals.Where(x => x.ReservationId == id))
                    {
                        _context.RoomsReservationMeals.Remove(roomReservation);
                    }
                    foreach (var roomReservation in _context.RoomsReservationChilderns.Where(x => x.ReservationId == id))
                    {
                        _context.RoomsReservationChilderns.Remove(roomReservation);
                    } 
                    foreach (var roomReservation in _context.Childerns.Where(x => x.ReservationId == id))
                    {
                        _context.Childerns.Remove(roomReservation);
                    }

                }
                for (int i = 0; addlist.Count > i; i++)
                {
                    _context.RoomsReservations.Add(new RoomsReservation { RoomId = addlist[i].RoomId ,ReservationId = id });
                    _context.RoomsReservationMeals.Add(new RoomsReservationMeal { MealTypeId = addlist[i].MealId, RoomId = addlist[i].RoomId, ReservationId = id });
                    _context.RoomsReservationChilderns.Add(new RoomsReservationChildern { NumbersofAdulte = addlist[i].NumbersofAud, RoomId = addlist[i].RoomId, ReservationId = id });
                    if (addlist[i].Years.Count > 0) 
                    {
                        for (int y = 0; addlist[i].Years.Count > y; y++)
                        {
                            _context.Childerns.Add(new Childern { RoomId = addlist[i].RoomId, ReservationId = id, Years = addlist[i].Years[y]  });
                        }
                    }
                }
                Response.Data = Find(x => x.Id == id);
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

        //public BaseResponseWithData<Reservation> AddRooms(int id, List<int> RoomIds, bool updateFacility = false)
        //{
        //    BaseResponseWithData<Reservation> Response = new BaseResponseWithData<Reservation>();
        //    Response.Data = new Reservation();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;

        //    try
        //    {
        //        if (id == 0 || RoomIds is null || RoomIds.Contains(0))
        //        {
        //            Response.Errors.Add(new Error { code = "E-2", message = "Invalid room reservation" });
        //            return Response;
        //        }
        //        if (updateFacility == true)
        //        {
        //            foreach (var roomReservation in _context.RoomsReservations.Where(x => x.ReservationId == id))
        //            {
        //                _context.RoomsReservations.Remove(roomReservation);
        //            }

        //        }
        //        foreach (var room in RoomIds)
        //        {
        //            _context.RoomsReservations.Add(new RoomsReservation { RoomId = room, ReservationId = id });

        //        }
        //        Response.Data = Find(x => x.Id == id);
        //        Response.Result = true;
        //        return Response;

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Result = false;
        //        Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
        //        return Response;
        //    }
        //}

        public BaseResponseWithData<List<ReservationRoomsDto>> GetAllRoomReservationsForAdding(DurationDto? durationDto, List<int> roomIds)
        {
            BaseResponseWithData<List<ReservationRoomsDto>> Response = new BaseResponseWithData<List<ReservationRoomsDto>>();
            Response.Data = new List<ReservationRoomsDto>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                if (durationDto.StartDate > durationDto.EndDate)
                {
                    Response.Result = false;
                    Response.Errors.Add(new Error { code = "E-2", message = "End date must be before start date" });
                    return Response;
                }
                if (roomIds.Count==0 || roomIds == null )
                {
                    Response.Result = false;
                    Response.Errors.Add(new Error { code = "E-2", message = "Enter numbers of rooms" });
                    return Response;
                }
                for (int i = 0; roomIds.Count > i; i++)
                {
                    if (roomIds[i] > 0)
                    {
                        //var room = _context.RoomsReservations.Where(X => X.RoomId == roomIds[i]).Any();
                        //var temp = _context.Reservations.Where(r => (
                        //                  r.ToDate >= durationDto.StartDate
                        //                 && r.FromDate <= durationDto.EndDate) && room).ToList();
                        var temp = _context.Reservations.Where(r => (
                                          r.ToDate >= durationDto.StartDate
                                         && r.FromDate <= durationDto.EndDate)).ToList();
                       // var tempdata = _context.RoomsReservations.Where(r=>r.ReservationId == )
                        Response.Data = GetAllWithRooms(_mapper.Map<List<ReservationRoomsDto>>(temp));
                    }

                   
                }
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


        public BaseResponseWithData<List<Reservation>> NotGetRoomReservations(DurationDto? durationDto, List<int> roomIds,int Id )
        {
            BaseResponseWithData<List<Reservation>> Response = new BaseResponseWithData<List<Reservation>>();
            Response.Data = new List<Reservation>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                if (durationDto.StartDate > durationDto.EndDate)
                {
                    Response.Result = false;
                    Response.Errors.Add(new Error { code = "E-2", message = "End date must be before start date" });
                    return Response;
                }
                if (roomIds.Count > 0)
                {
                    foreach (var roomId in roomIds)
                    {
                        //var room = _context.RoomsReservations.Where(X => X.RoomId == roomId &&X.ReservationId==Id).Any();
                        var tempdata = _context.Reservations.Where(r => (
                                          r.ToDate > durationDto.StartDate
                                         && r.FromDate < durationDto.EndDate) &&
                                         _context.RoomsReservations.Where(X => X.RoomId == roomId && X.ReservationId !=Id).Any()).ToList();

                        Response.Data = tempdata;
                    }

                }

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

      
    }
}
