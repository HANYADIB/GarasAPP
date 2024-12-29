using AutoMapper;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core;
using Microsoft.AspNetCore.Mvc;
using GarasAPP.Core.DTOs;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;


namespace GarasAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : Controller
    {
        private readonly IRateRepository _rateRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public RateController(IRateRepository rateRepository, IMapper mapper, IUnitOfWork unitOfWork) 
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddRates(NewRateDto newRates)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            BaseResponseWithData<List<Rate>> Response = new BaseResponseWithData<List<Rate>>();
            try
            {
                Response = _rateRepository.AddSpecialOffer(newRates);
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
        [HttpGet("TEST")]
        public async Task<IActionResult> test() 
        {
            var test = _rateRepository.DailyUpdate();
            _unitOfWork.Complete();

            return Ok(test);
        }
    }
}
