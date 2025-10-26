namespace Catalog.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public String Name { get; set; } = default!;

        public List<String> Category { get; set; } = new();

        public String Description { get; set; } = default!;

        public String ImageFile { get; set; } = default!;

        public Decimal price { get; set; }
         

    }
}
