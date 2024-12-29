using AutoMapper;
using GarasAPP.Core;
using GarasAPP.Core.Interfaces;
using GarasAPP.Core.Models;
using System.Collections.Generic;


namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class CountryRepository : BaseRepository<Country, int>, ICountryRepository
    {
        protected ApplicationDbContext _context;
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
