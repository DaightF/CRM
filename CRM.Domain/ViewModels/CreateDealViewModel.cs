using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRM.Domain.ViewModels
{
    public class CreateDealViewModel
    {
        public string Title { get; set; }               // Добавить
        public string Description { get; set; }
        public int Amount { get; set; }

        public int ReceiverId { get; set; }          // Можно оставить, если нужен выбор клиента
        public DealStage Stage { get; set; }            // Добавить

        public List<SelectListItem> Clients { get; set; } = new List<SelectListItem>();
    }

}
