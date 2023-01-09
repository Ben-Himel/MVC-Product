using Module4.Models;
using System.Net.Http.Headers;

namespace Module4.Services
{
    public interface ICRUD
    {
        //public IEnumerable<Product> GetProducts();
        List<Product> GetProductList();
        void Create(Product product); //Crud
        Product GetProduct(int? productId); //cRud
        void Update(Product product); //crUd        
        void DeleteProduct(int? productId);//cruD

        int GetMaxID();

    }
}
