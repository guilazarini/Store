using Store.Core.DomainObjects;

namespace Store.Catalogo.Domain
{
    public class Product : Entity, IAggreagateRoot
    {
        public Guid CategoryId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Value { get; private set; }
        public DateTime DateRegister { get; private set; }
        public string Image {  get; private set; }
        public int QuantityStock { get; private set; }

        public Category Category { get; private set; }

        public Product( string name, string description, bool active, decimal value, Guid categoryId, DateTime dateRegister, string image)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Active = active;
            Value = value;
            DateRegister = dateRegister;
            Image = image;
        }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void UpdateCategory(Category category) 
        {
            Category = category;
            CategoryId = category.Id;
        }

        public void UpdateDesCription(string description) 
        {  
            Description = description; 
        }

        public void DebitStock(int quantity) 
        {
            if (quantity < 0) quantity *= -1;
            QuantityStock -= quantity;
        }

        public bool ReplenishStock(int quantity)
        {
            return QuantityStock >= quantity;        
        }

        public bool HasStock(int quantity)
        {  
            return QuantityStock >= quantity; 
        }

        public void Validate()
        {
        }
    }
}
