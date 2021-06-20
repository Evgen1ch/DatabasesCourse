namespace DatabasesCourse.DatabaseModel.Entities
{
    public class OrderProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
