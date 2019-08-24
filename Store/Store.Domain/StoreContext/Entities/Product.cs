using FluentValidator;

namespace Store.Domain.StoreContext.Entities
{
    public class Product : Notifiable
    {
        public Product(string title, string description, string image, decimal price, decimal quantityOnhand)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
            this.Price = price;
            this.QuantityOnhand = quantityOnhand;

        }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnhand { get; private set; }
    }
}