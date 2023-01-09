using Module4.Models;

namespace Module4.Services
{
    public class CRUD : ICRUD
    {
        private ProductContext _productContext;

        public CRUD(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public void Create(Product product)
        {
            _productContext.Products.Add(product);
            _productContext.SaveChanges();
        }

        public void DeleteProduct(int? productIdtoDelete)
        {
            var product = _productContext.Products.Find(productIdtoDelete);
            if(product != null)
            {
                _productContext.Products.Remove(product);
                _productContext.SaveChanges();
            }
        }

        public int GetMaxID()
        {
            return _productContext.Products.Max(x => x.ProductId) + 1;
        }

        public Product GetProduct(int? productIdtoGet)
        {
            return _productContext.Products.Find(productIdtoGet);
        }

        public List<Product> GetProductList()
        {
            return new List<Product>(_productContext.Products);
        }

        public void Update(Product product)
        {
            var prod = _productContext.Products.Find(product.ProductId);
            if(prod != null)
            {
                prod.ProductId= product.ProductId;
                prod.Name= product.Name;
                prod.Description= product.Description;
                prod.ProductPrice= product.ProductPrice;
                prod.ProductImageName= product.ProductImageName;              
            }
            //_productContext.Add(product);
            _productContext.SaveChanges();
        }
    }
}
