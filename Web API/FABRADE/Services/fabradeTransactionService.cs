using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FABRADE.Models;
using Microsoft.EntityFrameworkCore;

namespace FABRADE.Services
{
    public class fabradeTransactionService : IfabradeTransactionService
    {
        #region Property
        private readonly fabradeDBContext _fabradeDBContext;
        #endregion

        #region Constructor
        public fabradeTransactionService(fabradeDBContext fabradeDBContext)
        {
            _fabradeDBContext = fabradeDBContext;
        }
        #endregion

        public async Task<string> GetfabradeTransactionByID(int TransID)
        {
            var dress_type = await _fabradeDBContext.fabradeTransactions.Where(c => c.id == TransID).Select(d => d.dress_type).FirstOrDefaultAsync();
            return dress_type;
        }

        public async Task<fabradeTransaction> GetfabradeTransactionDetails(int TransID)
        {
            var transDetails = await _fabradeDBContext.fabradeTransactions.FirstOrDefaultAsync(c => c.id == TransID);
            return transDetails;
        }
    }


}
