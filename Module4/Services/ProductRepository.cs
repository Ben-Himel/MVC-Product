using Module4.Models;

namespace Module4.Services
{
    
    public class ProductRepository : ICRUD
    {
        private List<Product> _products;

        //Constructor
        public ProductRepository() 
        {
            _products = new List<Product>
            {
                new Product() { ProductId = 1, Name = "Raspberry", ProductPrice = 123.44, Description = "how to make pies", ProductImageName = "bodie.jpg" },
                new Product() { ProductId = 2, Name = "C++ how to", ProductPrice = 66.44, Description = "how to C++", ProductImageName = "bodie.jpg" },
                new Product() { ProductId = 3, Name = "Yankee work for Yankees", ProductPrice = 12.44, Description = "book about yankees", ProductImageName = "bodie.jpg" },
                new Product() { ProductId = 4, Name = "Book of Objections", ProductPrice = 99.99, Description = "Just pictures of people objecting ", ProductImageName = "bodie.jpg" }
            };
        }

        public void Create(Product product)
        {
            _products.Add(product);
        }

        public void DeleteProduct(int? productId)
        {
            var prodToDelete = _products.Find(x => x.ProductId == productId);
            if(prodToDelete != null)
            {
                _products.Remove(prodToDelete);
            }
        }

        public int GetMaxID()
        {
            int maxid=_products.Max(x=> x.ProductId);
            return maxid+1;
        }

        public Product GetProduct(int? productIdin)
        {
            if (productIdin == null)
            {
                return null;
            }                
            else
            {
                return _products.Find(x => x.ProductId == productIdin);
            }                
        }

        public List<Product> GetProductList()
        {
            return _products;
        }

        public void Update(Product product)
        {
            var productToUpdate = _products.Find(x => x.ProductId == product.ProductId);
            if(productToUpdate!=null)
            {
                productToUpdate.ProductId = product.ProductId;
                productToUpdate.ProductPrice = product.ProductPrice;
                productToUpdate.Description = product.Description;
                productToUpdate.Name = product.Name;
                productToUpdate.ProductImageName = product.ProductImageName;
            }
        }
    }
}
