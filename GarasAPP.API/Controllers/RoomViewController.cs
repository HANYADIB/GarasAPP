using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using GarasAPP.Core;
using Microsoft.AspNetCore.Mvc;

namespace GarasAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomViewController : ControllerBase
    {
        private readonly IRoomViewRepository _roomViewRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RoomViewController(IRoomViewRepository roomViewRepository, IUnitOfWork unitOfWork)
        {
            _roomViewRepository = roomViewRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomViews()
        {
            BaseResponseWithData<List<RoomView>> Response = new BaseResponseWithData<List<RoomView>>();
            Response.Data = new List<RoomView>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = (List<RoomView>)await _roomViewRepository.GetAllAsync();
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

        [HttpGet("roomView")]
        public async Task<IActionResult> GetRoomViewAsync([FromHeader] int roomViewId)
        {
            BaseResponseWithData<RoomView> Response = new BaseResponseWithData<RoomView>();
            Response.Data = new RoomView();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = await _roomViewRepository.GetByIdAsync(roomViewId);
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
        public IActionResult AddRoomView(RoomView roomView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponseWithData<RoomView> Response = new BaseResponseWithData<RoomView>();

            try
            {
                var newRoomView = _roomViewRepository.Add(roomView);
                _unitOfWork.Complete();
                Response.Data = newRoomView;
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
        public IActionResult RemoveRoom([FromHeader] int RoomViewId)
        {
            BaseResponseWithData<RoomView> Response = new BaseResponseWithData<RoomView>();
            Response.Data = new RoomView();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _roomViewRepository.Delete(_roomViewRepository.GetById(RoomViewId));
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
        public IActionResult UpdateRoom([FromHeader] int roomViewId, [FromBody] RoomView roomView)
        {
            BaseResponseWithData<RoomView> Response = new BaseResponseWithData<RoomView>();
            Response.Data = new RoomView();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (roomView.Id != roomViewId)
                return BadRequest(ModelState);

            try
            {

                var updatedRoomView = _roomViewRepository.Update(roomView);
                _unitOfWork.Complete();
                Response.Result = true;
                Response.Data = updatedRoomView;
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