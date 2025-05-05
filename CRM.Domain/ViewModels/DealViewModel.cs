using CRM.Domain.Entity;
using CRM.Domain.Enum;
using System.Collections.Generic;

public class DealBoardViewModel
{
    public Dictionary<DealStage, List<Deal>> DealsByStage { get; set; }
}

