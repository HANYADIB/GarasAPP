using AutoMapper;
using GarasAPP.Core;
using GarasAPP.Core.DTOs;
using GarasAPP.Core.Interfaces;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GarasAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _CountryRepository;
        private readonly IGovernorateRepository _governorateRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly IlanguageeRepository _languageeRepository;
        private readonly INationalityRepository _clientNationality;
     
        public CountryController(ICountryRepository countryRepository,IGovernorateRepository governorateRepository,
                                 IAreaRepository areaRepository,IlanguageeRepository languageeRepository ,INationalityRepository clientNationality)
        {
            _CountryRepository = countryRepository;
            _governorateRepository = governorateRepository;
            _areaRepository = areaRepository;
            _clientNationality = clientNationality;
            _languageeRepository = languageeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCountryAsync()
        {
            BaseResponseWithData<List<Country>> Response = new BaseResponseWithData<List<Country>>();
            Response.Data = new List<Country>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = (List<Country>)await _CountryRepository.FindAllAsync(
                    r => r.Id > 0); ;
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
        
        [HttpGet("City")]
        public async Task<IActionResult> GetAllCityfilterbycountryAsync([FromHeader] int idCountry)
        {
            BaseResponseWithData<List<Governorate>> Response = new BaseResponseWithData<List<Governorate>>();
            Response.Data = new List<Governorate>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = (List<Governorate>)await _governorateRepository.FindAllAsync(
                    r => r.CountryId== idCountry); ;
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
        [HttpGet("Area")]
        public async Task<IActionResult> GetAllAreafilterbycityAsync([FromHeader] int idCity)
        {
            BaseResponseWithData<List<Area>> Response = new BaseResponseWithData<List<Area>>();
            Response.Data = new List<Area>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = (List<Area>)await _areaRepository.FindAllAsync(
                    r => r.GovernorateId== idCity); ;
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

        [HttpGet("Language")]
        public async Task<IActionResult> GetAllLanguages()
        {
            BaseResponseWithData<List<languagee>> Response = new BaseResponseWithData<List<languagee>>();
            Response.Data = new List<languagee>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = (List<languagee>)await _languageeRepository.FindAllAsync(
                    r => r.Id > 0); ;
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
        [HttpGet("Nationality")]
        public async Task<IActionResult> GetAllNationality()
        {
            BaseResponseWithData<List<Nationality>> Response = new BaseResponseWithData<List<Nationality>>();
            Response.Data = new List<Nationality>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                Response.Data = (List<Nationality>)await _clientNationality.FindAllAsync(
                    r => r.num_code > 0); ;
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
    }
}
