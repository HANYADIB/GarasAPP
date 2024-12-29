using GarasAPP.Core;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GarasAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BuildingController(IBuildingRepository buildingRepository, IUnitOfWork unitOfWork)
        {
            _buildingRepository = buildingRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllBuildings()
        {
            BaseResponseWithData<List<Building>> Response = new BaseResponseWithData<List<Building>>();
            Response.Data = new List<Building>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = (List<Building>)await _buildingRepository.GetAllAsync();
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

        [HttpGet("building")]
        public async Task<IActionResult> GetBuildingAsync([FromHeader] int buildingId)
        {
            BaseResponseWithData<Building> Response = new BaseResponseWithData<Building>();
            Response.Data = new Building();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = await _buildingRepository.GetByIdAsync(buildingId);
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
        public IActionResult AddBuilding(Building building)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponseWithData<Building> Response = new BaseResponseWithData<Building>();

            try
            {
                var newBuilding = _buildingRepository.Add(building);
                _unitOfWork.Complete();
                Response.Data = newBuilding;
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
        public IActionResult RemoveRoom([FromHeader]int buildingId)
        {
            BaseResponseWithData<Building> Response = new BaseResponseWithData<Building>();
            Response.Data = new Building();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _buildingRepository.Delete(_buildingRepository.GetById(buildingId));
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
        public IActionResult UpdateRoom([FromHeader] int buildingId, [FromBody] Building building)
        {
            BaseResponseWithData<Building> Response = new BaseResponseWithData<Building>();
            Response.Data = new Building();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (building.Id != buildingId)
                return BadRequest(ModelState);

            try
            {

                var updatedBuilding = _buildingRepository.Update(building);
                _unitOfWork.Complete();
                Response.Result = true;
                Response.Data = updatedBuilding;
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