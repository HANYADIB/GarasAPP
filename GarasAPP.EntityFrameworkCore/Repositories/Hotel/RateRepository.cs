using AutoMapper;
using GarasAPP.Core.DTOs;
using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models.HotelModels;
using GarasAPP.Core.ViewModels;


namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class RateRepository : BaseRepository<Rate, int>, IRateRepository
    {
        protected ApplicationDbContext _context;
        protected IMapper _mapper;
        public RateRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public BaseResponseWithData<List<Rate>> DailyUpdate()
        {
            BaseResponseWithData<List<Rate>> Response = new BaseResponseWithData<List<Rate>>();
            Response.Data = new List<Rate>();
            Response.Errors = new List<Error>();
            Response.Result = false;
            try
            {
                var activeRates = _context.Rates.Where(r => r.IsActive).ToList();
                foreach (var activeRate in activeRates)
                {
                    if(!activeRate.IsDefault && DateTime.Today > activeRate.EndingDate)
                    {
                        activeRate.IsActive = false;
                        _context.Rates.FirstOrDefault(r => r.RoomId == activeRate.RoomId && r.IsDefault).IsActive = true;
                    }
                    Response.Result = true;
                    Response.Data.Add(activeRate);
                }
                return Response;
            }
            catch (Exception ex)
            {
                Response.Result = false;
                Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
                return Response;
            }
        }

        //public BaseResponseWithData<List<Rate>> AddSpecialOffer(NewRateDto newRates)
        //{
        //    BaseResponseWithData<List<Rate>> Response = new BaseResponseWithData<List<Rate>>();
        //    Response.Data = new List<Rate>();
        //    Response.Errors = new List<Error>();
        //    Response.Result = false;
        //    try
        //    {
        //        if (newRates.EndingDate < newRates.StartingDate)
        //        {
        //            Response.Errors.Add(new Error { code = "E-2", message = "EndingDate must be after StartingDate" });
        //            return Response;
        //        }
        //        if (newRates.RoomsIds.Count != newRates.RoomsIds.Count)
        //        {
        //            Response.Errors.Add(new Error { code = "E-2", message = "Rooms list does not match Rates list" });
        //            return Response;
        //        }
        //        for (int i = 0; i < newRates.RoomsIds.Count; i++)
        //        {
        //            var tempRate = new Rate //_mapper.Map<Rate>(newRates);
        //            {
        //                IsDefault = false,
        //                StartingDate = newRates.StartingDate,
        //                EndingDate = newRates.EndingDate,
        //                SpecialOfferFlag = newRates.SpecialOfferFlag,
        //                RoomTypeId = newRates.RoomTypeId,
        //                RoomViewId = newRates.RoomViewId,
        //                BuildingId = newRates.BuildingId
        //            };
        //            var oldOffers = _context.Rates.Where(r => r.RoomId == newRates.RoomsIds[i] && r.IsActive).ToList();
        //            foreach (var r in oldOffers)
        //            {
        //                r.IsActive = false;
        //            }
        //            tempRate.RoomId = newRates.RoomsIds[i];
        //            tempRate.RoomRate = newRates.RoomsRates[i];
        //            Response.Data.Add(tempRate);
        //            _context.Add(tempRate);
        //            Response.Result = true;
        //        }


        //        return Response;
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Result = false;
        //        Response.Errors.Add(new Error { code = "E-1", message = ex.InnerException != null ? ex.InnerException?.Message : ex.Message });
        //        return Response;
        //    }
        //}

        public BaseResponseWithData<List<Rate>> AddSpecialOffer(NewRateDto newRates)
        {
            BaseResponseWithData<List<Rate>> Response = new BaseResponseWithData<List<Rate>>();
            Response.Data = new List<Rate>();
            Response.Errors = new List<Error>();
            Response.Result = false;
            try
            {
                if (newRates.EndingDate < newRates.StartingDate)
                {
                    Response.Errors.Add(new Error { code = "E-2", message = "EndingDate must be after StartingDate" });
                    return Response;
                }
                if (newRates.RoomsIds.Count != newRates.RoomsRates.Count)
                {
                    Response.Errors.Add(new Error { code = "E-2", message = "Rooms list does not match Rates list" });
                    return Response;
                }
                for (int i = 0; i < newRates.RoomsIds.Count; i++)
                {
                   
                        var tempRate = new Rate //_mapper.Map<Rate>(newRates);
                        {
                            IsDefault = false,
                            StartingDate = newRates.StartingDate,
                            EndingDate = newRates.EndingDate,
                            SpecialOfferFlag = newRates.SpecialOfferFlag,
                            RoomTypeId = newRates.RoomTypeId,
                            RoomViewId = newRates.RoomViewId,
                            BuildingId = newRates.BuildingId
                        };
                        var oldOffers = _context.Rates.Where(r => r.RoomId == newRates.RoomsIds[i] && r.IsActive).ToList();
                    if (_context.Rates.Where(x => x.RoomId == newRates.RoomsIds[i] && x.StartingDate == newRates.StartingDate && x.EndingDate == newRates.EndingDate).Any())
                    {
                        foreach (var r in oldOffers)
                        {
                            r.IsActive = false;
                        }

                    }
                    tempRate.RoomId = newRates.RoomsIds[i];
                        tempRate.RoomRate = newRates.RoomsRates[i];
                        Response.Data.Add(tempRate);
                        _context.Add(tempRate);
                        Response.Result = true;

                   

                    }
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
