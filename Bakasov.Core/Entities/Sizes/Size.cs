using Bakasov.Core.Interfaces;

namespace Bakasov.Core.Entities.Sizes;

public class Size : IHaveId
{
    public int Id {  get; set; }
        
    public string Number { get; set; }
}