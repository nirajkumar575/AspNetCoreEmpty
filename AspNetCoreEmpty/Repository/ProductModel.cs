namespace AspNetCoreEmpty.Repository
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
    }
}
