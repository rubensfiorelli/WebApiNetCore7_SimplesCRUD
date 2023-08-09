namespace Store.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Title { get; private set; }
        public string Category { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public string ImageFilename { get; private set; }

    }
}
