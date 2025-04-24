using CRM.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Services
{
    public class DealService : IDealService
    {
        private readonly AppDbContext _context;

        public DealService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateDealAsync(Deal deal)
        {
            _context.Deals.Add(deal);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Deal>> GetIncomingDealsAsync(int receiverId)
        {
            return await _context.Deals
                .Where(d => d.ReceiverId == receiverId)
                .ToListAsync();
        }

    }

}
