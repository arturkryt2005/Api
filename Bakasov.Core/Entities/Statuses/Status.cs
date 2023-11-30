using Bakasov.Core.Interfaces;

namespace Bakasov.Core.Entities.Statuses;

public class Status : IHaveId
{
    public int Id { get; set; }

    public string Name { get; set; }
}