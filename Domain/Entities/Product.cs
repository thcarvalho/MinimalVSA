using System.Runtime.InteropServices.JavaScript;

namespace MinimalVSA.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    
    public void UpdateFields(string name, decimal price, int categoryId)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
        UpdatedAt = DateTime.Now;
    }
}