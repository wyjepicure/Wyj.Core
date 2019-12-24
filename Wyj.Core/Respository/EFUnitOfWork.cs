using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Wyj.Core.Data;
using Wyj.Core.IRespository;

namespace Wyj.Core.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;

        public EFUnitOfWork(MyDbContext context)
        {
            _context = context;
        }

        public DbTransaction BeginTransaction()
        {
            _context.Database.BeginTransaction();

            return _context.Database.CurrentTransaction.GetDbTransaction();
        }

        public void CommitTransaction()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
