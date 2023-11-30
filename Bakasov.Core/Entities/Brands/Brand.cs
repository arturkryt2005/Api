using Bakasov.Core.Interfaces;

namespace Bakasov.Core.Entities.Brands;

public class Brand : IHaveId
{
    public int Id { get; set; }

    public string Name { get; set; }
}