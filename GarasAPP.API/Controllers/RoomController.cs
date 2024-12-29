
using AutoMapper;
using GarasAPP.Core;
using GarasAPP.Core.DTOs;
using GarasAPP.Core.Helpers;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GarasAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRateRepository _rateRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RoomController(IRoomRepository roomRepository, IMapper mapper, IUnitOfWork unitOfWork, IRateRepository rateRepository)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _rateRepository = rateRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomsAsync()
        {
            _rateRepository.DailyUpdate();
            _unitOfWork.Complete();
            BaseResponseWithData<List<GetRoomDto>> Response = new BaseResponseWithData<List<GetRoomDto>>();
            Response.Data = new List<GetRoomDto>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                var tempData = (await _roomRepository.FindAllAsync(
                    r => r.Id > 0, new string[] { "RoomType", "Building", "RoomView" })); ;
                var tempdata2 = tempData.Select(x => x.ToGetRoomDto()).ToList();
                Response.Data = _roomRepository.GetAllWithFacilities(tempdata2);
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

        [HttpGet("room")]
        public async Task<IActionResult> GetRoomAsync([FromHeader]int roomId)
        {
            _rateRepository.DailyUpdate();
            _unitOfWork.Complete();
            BaseResponseWithData<GetRoomDto> Response = new BaseResponseWithData<GetRoomDto>();
            Response.Data = new GetRoomDto();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                var tempData =(await _roomRepository.FindAsync(
                    r => r.Id == roomId, new string[] { "RoomType", "Building", "RoomView" }));
                var tempdata2 = tempData.ToGetRoomDto();
                Response.Data = _roomRepository.GetWithFacilities(tempdata2);
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

        [HttpGet("searchInRooms")]
        public async Task<IActionResult> SearchInRoomsAsync([FromHeader]FindRoomDto findRoomDto)
        {
            _rateRepository.DailyUpdate();
            BaseResponseWithData<List<GetRoomDto>> Response = new BaseResponseWithData<List<GetRoomDto>>();

            try
            {
                Response = await _roomRepository.FindRoomAsync(findRoomDto);
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

        [HttpPost]
        public IActionResult AddRoom(RoomDto createRoomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponseWithData<Room> Response = new BaseResponseWithData<Room>();

            try
            {
                var newRoom = _roomRepository.Add(_mapper.Map<Room>(createRoomDto));
                _unitOfWork.Complete();
                Response = _roomRepository.AddFacilities(newRoom.Id, createRoomDto.FacilitiesIds);
                _rateRepository.Add(new Rate { RoomRate = (int)createRoomDto.Rate, RoomId =  newRoom.Id});
                _unitOfWork.Complete();
                return Ok(Response);
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return BadRequest(Response);
            }

        }
        [HttpDelete]
        public IActionResult RemoveRoom([FromHeader] int roomId)
        {
            BaseResponseWithData<Room> Response = new BaseResponseWithData<Room>();
            Response.Data = new Room();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _roomRepository.Delete(_roomRepository.GetById(roomId));
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
        //public IActionResult UpdateRoom([FromHeader] int roomId,[FromBody] RoomDto updateRoomDto)
        //{
        //    BaseResponseWithData<Room> Response = new BaseResponseWithData<Room>();
        //    Response.Data = new Room();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    if (updateRoomDto.Id != roomId)
        //        return BadRequest(ModelState);

        //    try
        //    {

        //        var updatedRoom = _roomRepository.Update(_mapper.Map<Room>(updateRoomDto));
        //        Response = _roomRepository.AddFacilities(updatedRoom.Id, updateRoomDto.FacilitiesIds, true);
        //        _unitOfWork.Complete();
        //        Response.Result = true;
        //        Response.Data = updatedRoom;
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
        public async Task <IActionResult> UpdateRoom([FromHeader] int roomId, [FromBody] UpdataRoomDto updateRoomDto)
        {
            BaseResponseWithData<Room> Response = new BaseResponseWithData<Room>();
            Response.Data = new Room();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (updateRoomDto.Id != roomId)
                return BadRequest(ModelState);

            try
            {

                var updatedRoom =  _roomRepository.Update(_mapper.Map<Room>(updateRoomDto));
                Response = _roomRepository.AddFacilities(updatedRoom.Id, updateRoomDto.FacilitiesIds, true);
                _unitOfWork.Complete();
                Response.Result = true;
                Response.Data = updatedRoom;
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
