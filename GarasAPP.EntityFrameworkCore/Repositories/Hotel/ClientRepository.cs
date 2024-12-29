using GarasAPP.Core.DTOs;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
   
        public class ClientRepository : BaseRepository<Client, long>, IClientRepository
        {
            protected ApplicationDbContext _context;
            public ClientRepository(ApplicationDbContext context) : base(context)
            {
                _context = context;
            }
        public BaseResponseWithData<GuestProfileDto> Addlanguage(long ClientId, List<int>? languageId ,bool updateLanguage = false)
        {
            BaseResponseWithData<GuestProfileDto> Response = new BaseResponseWithData<GuestProfileDto>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                if (ClientId == 0 || languageId is null || languageId.Contains(0))
                {
                    Response.Errors.Add(new Error { code = "E-2", message = "Invalid client language" });
                    return Response;
                }
                if (updateLanguage == true)
                {
                    foreach (var lang in _context.ClientLanguagees.Where(x => x.ClientId == ClientId))
                    {
                        _context.ClientLanguagees.Remove(lang);
                    }

                }
                foreach (var lang in languageId)
                {
                    _context.ClientLanguagees.Add(new ClientLanguagee { ClientId = ClientId, LanguageeId = lang });
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
        public BaseResponseWithData<GuestProfileDto> AddAddress(long ClientId, List<AddressDto>? addresslist, bool updatAddress = false)
        {
            BaseResponseWithData<GuestProfileDto> Response = new BaseResponseWithData<GuestProfileDto>();
            Response.Errors = new List<Error>();
            Response.Result = false;

            try
            {
                if (addresslist.Count < 0)
                {
                    Response.Errors.Add(new Error { code = "E-2", message = "Invalid client Address" });
                    return Response;
                }
                if (updatAddress == true)
                {
                    foreach (var lang in _context.ClientAddresses.Where(x => x.ClientId == ClientId))
                    {
                        _context.ClientAddresses.Remove(lang);
                    }

                }
                
             
                    foreach (var item in addresslist)
                    {
                        _context.ClientAddresses.Add(new ClientAddress
                        {
                            ClientId = ClientId,
                            CountryId = item.CountryId,
                            GovernorateId = item.GovernorateId,
                            AreaId = item.AreaId,
                            Address = item.Address,
                            BuildingNumber = item.BuildingNumber,
                            Floor = item.Floor,
                            Description = item.Description,
                            Active = item.Active,
                            CreationDate=DateTime.Now,
                            CreatedBy=1
                        });
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
