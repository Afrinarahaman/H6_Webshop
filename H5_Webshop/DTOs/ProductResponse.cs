


namespace H5_Webshop.DTOs
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        public ProductCategoryResponse Category { get; set; }

     




    }

    public class ProductCategoryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
