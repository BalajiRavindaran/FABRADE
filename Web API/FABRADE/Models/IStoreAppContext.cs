using Microsoft.EntityFrameworkCore;
using System;

namespace FABRADE.Models
{
    public interface IStoreAppContext
    {
        public interface IStoreAppContext : IDisposable
        {
            DbSet<fabradeTransaction> fabradeTransactions { get; }
            int SaveChanges();
            void MarkAsModified(fabradeTransaction item);
        }
    }
}
