using CRM.Domain.Entity;
using System.Collections.Generic;

public class DealBoardViewModel
{
    public Dictionary<DealStage, List<Deal>> DealsByStage { get; set; }
}
