using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using GarasAPP.Core;
using Microsoft.AspNetCore.Mvc;
using GarasAPP.Core.DTOs;
using AutoMapper;

namespace GarasAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _ReservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IRateRepository _rateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReservationController(IReservationRepository ReservationRepository, IUnitOfWork unitOfWork
            , IMapper mapper, IRoomRepository roomRepository, IRateRepository rateRepository)
        {
            _ReservationRepository = ReservationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roomRepository = roomRepository;
            _rateRepository = rateRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllReservations()
        //{
        //    BaseResponseWithData<List<Reservation>> Response = new BaseResponseWithData<List<Reservation>>();
        //    Response.Data = new List<Reservation>();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;

        //    try
        //    {
        //        Response.Data = (List<Reservation>)await _ReservationRepository.GetAllAsync();
        //        Response.Result = true;
        //        return Ok(Response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Result = false;
        //        Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
        //        return BadRequest(Response);
        //    }
        //}
        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            BaseResponseWithData<List<ReservationRoomsDto>> Response = new BaseResponseWithData<List<ReservationRoomsDto>>();
            Response.Data = new List<ReservationRoomsDto>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                var tempData = _mapper.Map<List<ReservationRoomsDto>>(await _ReservationRepository.GetAllAsync());
                Response.Data = _ReservationRepository.GetAllWithRooms(tempData);
                Response.Result = true;
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }

        [HttpGet("reservation")]
        public async Task<IActionResult> GetReservationAsync([FromHeader] int reservationId)
        {
            BaseResponseWithData<ReservationRoomsDto> Response = new BaseResponseWithData<ReservationRoomsDto>();
            Response.Data = new ReservationRoomsDto();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                var tempdata = _mapper.Map<ReservationRoomsDto>(await _ReservationRepository.GetByIdAsync(reservationId));
                Response.Data = _ReservationRepository.GetWithRoom(tempdata);
                Response.Result = true;
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }
        [HttpGet("reservationWithMealandChildern")]
        public async Task<IActionResult> GetReservationWithChildernandMealTypeAsync([FromHeader] int reservationId)
        {
            BaseResponseWithData<ReservationRoomsByIDDto> Response = new BaseResponseWithData<ReservationRoomsByIDDto>();
            Response.Data = new ReservationRoomsByIDDto();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                var tempdata = _mapper.Map<ReservationRoomsByIDDto>(await _ReservationRepository.GetByIdAsync(reservationId));
                Response.Data = _ReservationRepository.GetWithRoomandmealandchildern(tempdata);
                Response.Result = true;
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }
        //[HttpGet("reservation")]
        //public async Task<IActionResult> GetReservationAsync([FromHeader] int reservationId)
        //{
        //    BaseResponseWithData<Reservation> Response = new BaseResponseWithData<Reservation>();
        //    Response.Data = new Reservation();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;

        //    try
        //    {
        //        Response.Data = await _ReservationRepository.GetByIdAsync(reservationId);
        //        Response.Result = true;
        //        return Ok(Response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Result = false;
        //        Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
        //        return BadRequest(Response);
        //    }
        //}
        [HttpGet("room")]
        public async Task<IActionResult> GetRoomReservation(DurationDto? durationDto, [FromHeader] int roomId)
        {
            BaseResponseWithData<List<Reservation>> Response = new BaseResponseWithData<List<Reservation>>();
            Response.Data = new List<Reservation>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                if (_roomRepository.GetById(roomId) == null)
                {
                    Response.Result = false;
                    Response.Errors.Add(new Error { code = "E-2", message = "This Room is not valid" });
                    return BadRequest(Response);
                }
                //var ttt = _mapper.Map<List<ReservationRoomsDto>>(await _ReservationRepository.GetAllAsync());
                //var test = (_ReservationRepository.GetRoomReservations(durationDto, roomId));
                //var tempdata = _mapper.Map<List<ReservationRoomsDto>>( test); 

                Response = _ReservationRepository.AllReservedRooms(durationDto, roomId);

                //var tempdate =  (_ReservationRepository.GetRoomReservations(durationDto, roomId));

                //var temp  =  _ReservationRepository.GetAllWithRooms(_ReservationRepository.GetRoomReservations(durationDto,roomId));
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }

        //[HttpGet("room")]
        //public async Task<IActionResult> GetRoomReservation([FromHeader] int roomId, DurationDto? durationDto)
        //{
        //    BaseResponseWithData<List<Reservation>> Response = new BaseResponseWithData<List<Reservation>>();
        //    Response.Data = new List<Reservation>();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;

        //    try
        //    {
        //        if (_roomRepository.GetById(roomId) == null)
        //        {
        //            Response.Result = false;
        //            Response.Errors.Add(new Error { code = "E-2", message = "This Room is not valid" });
        //            return BadRequest(Response);
        //        }
        //        Response = _ReservationRepository.GetRoomReservations(durationDto, roomId);
        //        return Ok(Response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Result = false;
        //        Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
        //        return BadRequest(Response);
        //    }
        //}

        [HttpGet("rooms")]
        public async Task<IActionResult> GetAllRoomReservation([FromHeader] DurationDto? durationDto)
        {
            BaseResponseWithData<List<Reservation>> Response = new BaseResponseWithData<List<Reservation>>();
            Response.Data = new List<Reservation>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response = _ReservationRepository.AllReservedRooms(durationDto);
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }

        //[HttpGet("rooms")]
        //public async Task<IActionResult> GetAllRoomReservation(DurationDto? durationDto)
        //{
        //    BaseResponseWithData<List<Reservation>> Response = new BaseResponseWithData<List<Reservation>>();
        //    Response.Data = new List<Reservation>();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;

        //    try
        //    {
        //        Response = _ReservationRepository.GetRoomReservations(durationDto);
        //        return Ok(Response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Result = false;
        //        Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
        //        return BadRequest(Response);
        //    }
        //}

        [HttpGet("grid")]
        public async Task<IActionResult> GetRoomReservationGrid([FromHeader] DurationDto2 durationDto, [FromHeader] int? roomTypeId = 0, [FromHeader] int? roomviewId = 0, [FromHeader] int? roombuildingId = 0)
        {

            BaseResponseWithData<List<RoomReservationDto>> Response = new BaseResponseWithData<List<RoomReservationDto>>();
            // _rateRepository.DailyUpdate();
            try
            {
                Response = _ReservationRepository.GetRoomReservationsGrid(durationDto, roomTypeId, roomviewId, roombuildingId);
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }

        [HttpPost]
        public IActionResult AddReservation(ReservationDto Dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponseWithData<Reservation> Response = new BaseResponseWithData<Reservation>();
            Response.Data = new Reservation();
            Response.Errors = new List<Error>();
            Response.Result = false;
            var duration = new DurationDto
            {
                StartDate = Dto.FromDate,
                EndDate = Dto.ToDate
            };

            try
            {
                for (int i=0;Dto.ListRooms.Count>i;i++) 
                {
                    
                        if ((_ReservationRepository.GetRoomReservationsfortesting(duration, Dto.ListRooms[i].RoomId).Data.Any()))
                        {
                            Response.Errors.Add(new Error { code = "E-2", message = $"This room {Dto.ListRooms[i].RoomId} is already reserved in those days" });
                            return BadRequest(Response);
                        }
                    
                }
                var tempdata = _ReservationRepository.Add(_mapper.Map<Reservation>(Dto));
                _unitOfWork.Complete();
                var newReservation = _ReservationRepository.AddRooms(tempdata.Id,Dto.ListRooms);
                _unitOfWork.Complete(); 
                Response = newReservation;
                Response.Result = true;
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }

        //[HttpPost]
        //public IActionResult AddReservation(ReservationDto reservationDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    BaseResponseWithData<Reservation> Response = new BaseResponseWithData<Reservation>();
        //    Response.Data = new Reservation();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;
        //    var duration = new DurationDto
        //    {
        //        StartDate = reservationDto.FromDate,
        //        EndDate = reservationDto.ToDate
        //    };

        //    try
        //    {
                
                
        //            foreach (var roomId in reservationDto.roomIds)
        //            {
        //                if ((_ReservationRepository.GetRoomReservationsfortesting(duration, roomId).Data.Any()))
        //                {
        //                    Response.Errors.Add(new Error { code = "E-2", message = $"This room {roomId} is already reserved in those days" });
        //                    return BadRequest(Response);
        //                }
        //            }
                
        //        var tempdata = _ReservationRepository.Add(_mapper.Map<Reservation>(reservationDto));
        //        _unitOfWork.Complete();
        //        //var newReservation = _ReservationRepository.AddRooms(tempdata.Id,reservationDto.RoomIds);
        //        _unitOfWork.Complete();
        //        // Response = newReservation;
        //        Response.Result = true;
        //        return Ok(Response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Result = false;
        //        Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
        //        return BadRequest(Response);
        //    }
        //}

        [HttpDelete]
        public IActionResult RemoveReservation([FromHeader] int reservationId)
        {
            BaseResponseWithData<Reservation> Response = new BaseResponseWithData<Reservation>();
            Response.Data = new Reservation();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _ReservationRepository.Delete(_ReservationRepository.GetById(reservationId));
                _unitOfWork.Complete();
                Response.Result = true;
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }

        //[HttpPut]
        //public IActionResult UpdateReservation([FromHeader] int reservationId, [FromBody] Reservation reservation)
        //{
        //    BaseResponseWithData<Reservation> Response = new BaseResponseWithData<Reservation>();
        //    Response.Data = new Reservation();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    if (reservation.Id != reservationId)
        //        return BadRequest(ModelState);

        //    try
        //    {

        //        var updatedReservation = _ReservationRepository.Update(reservation);
        //        _unitOfWork.Complete();
        //        Response.Result = true;
        //        Response.Data = updatedReservation;
        //        return Ok(Response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Result = false;
        //        Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
        //        return BadRequest(Response);
        //    }
        //}

        //[HttpPut]
        //public IActionResult UpdateReservation([FromHeader] int reservationId, [FromBody] ReservationUpdataDto reservationUpdata)
        //{
        //    BaseResponseWithData<Reservation> Response = new BaseResponseWithData<Reservation>();
        //    Response.Data = new Reservation();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    if (reservationUpdata.Id != reservationId)
        //        return BadRequest(ModelState);
        //    var duration = new DurationDto
        //    {
        //        StartDate = reservationUpdata.FromDate,
        //        EndDate = reservationUpdata.ToDate
        //    };

        //    try
        //    {

        //        if (_ReservationRepository.GetRoomReservations(duration, reservationUpdata.RoomId).Data.Any())
        //        {
        //            Response.Errors.Add(new Error { code = "E-2", message = "This room is already reserved in those days" });
        //            return BadRequest(Response);
        //        }

        //        var updatedReservation = _ReservationRepository.Update(_mapper.Map<Reservation>(reservationUpdata));
        //        _unitOfWork.Complete();
        //        Response.Result = true;
        //        Response.Data = updatedReservation;
        //        return Ok(Response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Result = false;
        //        Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
        //        return BadRequest(Response);
        //    }
        //}

        [HttpPut]
        public IActionResult UpdateReservation([FromHeader] int reservationId, [FromBody] ReservationDto Dto)
        {
            BaseResponseWithData<Reservation> Response = new BaseResponseWithData<Reservation>();
            Response.Data = new Reservation();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (Dto.Id != reservationId)
                return BadRequest(ModelState);
            var duration = new DurationDto
            {
                StartDate = Dto.FromDate,
                EndDate = Dto.ToDate
            };

            try
            {
                for (int i =0; Dto.ListRooms.Count>i;i++) 
                {
                   
                        if ((_ReservationRepository.GetRoomReservationsfortesting(duration, Dto.ListRooms[i].RoomId, Dto.Id).Data.Any()))
                        {
                            Response.Errors.Add(new Error { code = "E-2", message = $"This room {Dto.ListRooms[i].RoomId} is already reserved in those days" });
                            return BadRequest(Response);
                        }
                    
                }
                var updatedReservation = _ReservationRepository.Update(_mapper.Map<Reservation>(Dto));
                _unitOfWork.Complete();
                var newReservation = _ReservationRepository.AddRooms(updatedReservation.Id, Dto.ListRooms, true);
                _unitOfWork.Complete();
                Response.Result = true;
                Response.Data = updatedReservation;
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }
        }
    }
}