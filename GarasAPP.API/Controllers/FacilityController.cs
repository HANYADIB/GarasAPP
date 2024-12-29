using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using GarasAPP.Core;
using Microsoft.AspNetCore.Mvc;

namespace GarasAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IFacilityRepository _facilityRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FacilityController(IFacilityRepository facilityRepository, IUnitOfWork unitOfWork)
        {
            _facilityRepository = facilityRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllFacilitys")]
        public async Task<IActionResult> GetAllFacilitys()
        {
            BaseResponseWithData<List<Facility>> Response = new BaseResponseWithData<List<Facility>>();
            Response.Data = new List<Facility>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = (List<Facility>)await _facilityRepository.GetAllAsync();
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

        [HttpGet("facility")]
        public async Task<IActionResult> GetFacilityAsync([FromHeader]int facilityId)
        {
            BaseResponseWithData<Facility> Response = new BaseResponseWithData<Facility>();
            Response.Data = new Facility();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = await _facilityRepository.GetByIdAsync(facilityId);
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
        public IActionResult AddFacility(Facility facility)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponseWithData<Facility> Response = new BaseResponseWithData<Facility>();

            try
            {
                var newFacility = _facilityRepository.Add(facility);
                _unitOfWork.Complete();
                Response.Data = newFacility;
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
        public IActionResult RemoveRoom([FromHeader] int facilityId)
        {
            BaseResponseWithData<Facility> Response = new BaseResponseWithData<Facility>();
            Response.Data = new Facility();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _facilityRepository.Delete(_facilityRepository.GetById(facilityId));
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
        public IActionResult UpdateRoom([FromHeader] int facilityId, [FromBody] Facility facility)
        {
            BaseResponseWithData<Facility> Response = new BaseResponseWithData<Facility>();
            Response.Data = new Facility();
            Response.Errors = new List<Error>();
            Response.Result = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (facility.Id != facilityId)
                return BadRequest(ModelState);

            try
            {

                var updatedFacility = _facilityRepository.Update(facility);
                _unitOfWork.Complete();
                Response.Result = true;
                Response.Data = updatedFacility;
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