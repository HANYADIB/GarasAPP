using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using GarasAPP.Core;
using Microsoft.AspNetCore.Mvc;

namespace GarasAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RoomTypeController(IRoomTypeRepository roomTypeRepository, IUnitOfWork unitOfWork)
        {
            _roomTypeRepository = roomTypeRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            BaseResponseWithData<List<RoomType>> Response = new BaseResponseWithData<List<RoomType>>();
            Response.Data = new List<RoomType>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = (List<RoomType>)await _roomTypeRepository.GetAllAsync();
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

        [HttpGet("roomType")]
        public async Task<IActionResult> GetRoomTypeAsync([FromHeader]int roomTypeId)
        {
            BaseResponseWithData<RoomType> Response = new BaseResponseWithData<RoomType>();
            Response.Data = new RoomType();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = await _roomTypeRepository.GetByIdAsync(roomTypeId);
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
        public IActionResult AddRoomType(RoomType roomType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponseWithData<RoomType> Response = new BaseResponseWithData<RoomType>();

            try
            {
                var newRoomType = _roomTypeRepository.Add(roomType);
                _unitOfWork.Complete();
                Response.Data = newRoomType;
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

        [HttpDelete]
        public IActionResult RemoveRoom([FromHeader]int RoomTypeId)
        {
            BaseResponseWithData<RoomType> Response = new BaseResponseWithData<RoomType>();
            Response.Data = new RoomType();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _roomTypeRepository.Delete(_roomTypeRepository.GetById(RoomTypeId));
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

        [HttpPut]
        public IActionResult UpdateRoom([FromHeader] int roomTypeId, [FromBody] RoomType roomType)
        {
            BaseResponseWithData<RoomType> Response = new BaseResponseWithData<RoomType>();
            Response.Data = new RoomType();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (roomType.Id != roomTypeId)
                return BadRequest(ModelState);

            try
            {

                var updatedRoomType = _roomTypeRepository.Update(roomType);
                _unitOfWork.Complete();
                Response.Result = true;
                Response.Data = updatedRoomType;
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