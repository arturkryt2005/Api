using Bakasov.Core.Entities.Statuses;
using Bakasov.Core.Entities.Users;
using Bakasov.Core.Interfaces;

namespace Bakasov.Core.Entities.Orders;

public class Order : IHaveId
{
    public int Id { get; set; }
    
    public int StatusId { get; set; }

    public virtual Status Status { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; }

    public DateTime CreatedDate { get; set; }
}