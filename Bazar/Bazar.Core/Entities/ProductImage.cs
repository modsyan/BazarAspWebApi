using Bazar.Core.Entities.Base;

namespace Bazar.Core.Entities;

public class ProductImage : BaseModel
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public string Url { get; set; }
}