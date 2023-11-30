using Bakasov.Core.Interfaces;

namespace Bakasov.Core.Entities.Categories;

public class Category : IHaveId
{
    public int Id { get; set; }

    public string Name { get; set; }
}