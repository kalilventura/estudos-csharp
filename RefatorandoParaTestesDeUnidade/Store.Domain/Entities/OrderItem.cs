namespace Store.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            AddNotifications(new Contact()
                                .Requires()
                                .IsNotNull(product, "Product", "Produto Inválido")
                                .IsGreaterThen(quantity, 0, "A quantidade deve ser maior que zero") );
            Product = product;
            Price = Product != null ? product.Price : 0;
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }
}