namespace _3_formsapp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository() 
        {
            _categories.Add(new Category { CategoryId = 1, Name = "Phone" });
            _categories.Add(new Category { CategoryId = 2, Name = "Computer" });

            _products.Add(new Product 
            { 
                ProductId = 1,
                Name = "Nokia 3310",
                Price = 100,
                IsActive = true,
                Image = "nokia3310.jpg",
                CategoryId = 1
            });
            _products.Add(new Product
            {
                ProductId = 2,
                Name = "Samsung Galaxy",
                Price = 1250,
                IsActive = true,
                Image = "samsunggalaxy.jpg",
                CategoryId = 1
            });
            _products.Add(new Product
            {
                ProductId = 3,
                Name = "Bull Gama 3",
                Price = 100000,
                IsActive = true,
                Image = "bullgama3.jpg",
                CategoryId = 2
            });
        }

        public static List<Product> Products => _products;

        public static void AddProduct(Product product)
        {
            product.ProductId = _products.Max(p => p.ProductId) + 1;
            _products.Add(product);
        }

        public static void EditProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Image = product.Image;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.IsActive = product.IsActive;
            }
        }

        public static void EditProductActive(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.IsActive = product.IsActive;
            }
        }

        public static void DeleteProduct(int productId)
        {
            var existingProduct = _products.FirstOrDefault(p => p.ProductId == productId);
            if (existingProduct != null)
            {
                _products.Remove(existingProduct);
            }
        }

        public static List<Category> Categories => _categories;
    }
}
