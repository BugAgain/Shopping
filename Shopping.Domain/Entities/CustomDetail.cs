namespace Shopping.Domain.Entities
{
    public class CustomDetail
    {
        public int CustomDetailId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
