using AutoMapper;
using GarasAPP.Core.DTOs;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.ViewModels;
using GarasAPP.Core;
using Microsoft.AspNetCore.Mvc;
using GarasAPP.Core.Models;
using GarasAPP.EntityFrameworkCore.Repositories.Hotel;

namespace GarasAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    { 
        private readonly IClientRepository _clientRepository;
        private readonly IAddressRepository _addressRep;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClientController(IClientRepository clientRepository, IUnitOfWork unitOfWork, IMapper mapper , IAddressRepository addressRep)
        {
            _clientRepository = clientRepository;
            _addressRep = addressRep;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllclient()
        {
            BaseResponseWithData<List<ClientDto>> Response = new BaseResponseWithData<List<ClientDto>>();
            Response.Data = new List<ClientDto>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                var test = await _clientRepository.GetAllAsync();
                Response.Data = _mapper.Map<List<ClientDto>>(await _clientRepository.GetAllAsync());
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
        //public IActionResult AddClient([FromBody] ClientDto client)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    BaseResponseWithData<ClientDto> Response = new BaseResponseWithData<ClientDto>();

        //    try
        //    {
        //        var newclient = _clientRepository.Add(_mapper.Map<Client>(client));
        //        _unitOfWork.Complete();
        //        Response.Data = client;
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

        [HttpPost]
        public IActionResult AddClient([FromBody] GuestProfileDto client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponseWithData<GuestProfileDto> Response = new BaseResponseWithData<GuestProfileDto>();
            Response.Data = new GuestProfileDto();
            Response.Errors = new List<Error>();
            Response.Result = false;
            try
            {
                var newclient = _clientRepository.Add(_mapper.Map<Client>(client));
                _unitOfWork.Complete();
                _clientRepository.Addlanguage(newclient.Id,client.languageeId);
                _unitOfWork.Complete();
                _clientRepository.AddAddress(newclient.Id,client.addressDtos);
                _unitOfWork.Complete();
                Response.Data = client;
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
        //public IActionResult AddClient([FromBody] ClientDto client)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    BaseResponseWithData<Client> Response = new BaseResponseWithData<Client>();

        //    try
        //    {
        //        var newclient = _clientRepository.Add(_mapper.Map<Client>(client));
        //        _unitOfWork.Complete();
        //        Response.Data = newclient;
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
        [HttpPost("address")]
        public IActionResult adresss([FromBody] AddressDto client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            BaseResponseWithData<AddressDto> Response = new BaseResponseWithData<AddressDto>();
            Response.Data = new AddressDto();
            Response.Errors = new List<Error>();
            Response.Result = false;
            try
            {
                var newaddress = _addressRep.Add(_mapper.Map<ClientAddress>(client));
                _unitOfWork.Complete();
                Response.Data = client;
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
