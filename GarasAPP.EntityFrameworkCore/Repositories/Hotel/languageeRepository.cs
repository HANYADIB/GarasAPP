using GarasAPP.Core.Interfaces.Hotel;
using GarasAPP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.EntityFrameworkCore.Repositories.Hotel
{
    public class languageeRepository : BaseRepository<languagee, int>, IlanguageeRepository
    {
        protected ApplicationDbContext _context;
        public languageeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
