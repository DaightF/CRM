using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Interfaces
{
    public interface IDealService
    {
        Task CreateDealAsync(Deal deal);
        Task<List<Deal>> GetIncomingDealsAsync(int receiverId);
        // другие методы
    }

}
