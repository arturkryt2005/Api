using Bakasov.Core.Entities.Brands;
using Bakasov.Core.Entities.Categories;
using Bakasov.Core.Entities.Sizes;
using Bakasov.Core.Interfaces;

namespace Bakasov.Core.Entities.Products;

public class Product : IHaveId
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int BrandId { get; set;}

    public virtual Brand Brand { get; set; }

    public int SizeId { get; set;}

    public virtual Size Size { get; set; }

    public int CategoryId { get; set;}

    public virtual Category Category { get; set; }
}