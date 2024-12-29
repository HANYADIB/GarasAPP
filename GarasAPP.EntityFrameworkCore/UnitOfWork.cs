using GarasAPP.Core;
using GarasAPP.Core.Interfaces;
using GarasAPP.Core.Models;
using GarasAPP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarasAPP.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<User, long> Users { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new BaseRepository<User, long>(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
