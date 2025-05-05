using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.ViewModels
{
    public class ChangeStageViewModel
    {
        [Required]
        public int DealId { get; set; }

        [Required]
        public DealStage NewStage { get; set; }
    }

}
