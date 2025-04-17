using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entity
{
    public class Deal
    {
        public int Id { get; set; }
        public string Stage { get; set; } 
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
