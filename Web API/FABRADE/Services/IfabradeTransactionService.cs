using FABRADE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABRADE.Services
{
    public interface IfabradeTransactionService
    {
        Task<string> GetfabradeTransactionByID(int TransID);
        Task<fabradeTransaction> GetfabradeTransactionDetails(int TransID);
    }
}
