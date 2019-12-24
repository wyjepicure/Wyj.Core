using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Wyj.Core.IRespository
{
    public interface IUnitOfWork
    {
        DbTransaction BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
