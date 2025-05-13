using Infrastructure.Reponsitories.Abstractions.Extend;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Reponsitories.Abstractions
{
    public interface IUnitOfWork
    {
        IDisposable BeginTransaction(IsolationLevel level);
        void CommitChanges();
        Task CommitChangesAsync();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
