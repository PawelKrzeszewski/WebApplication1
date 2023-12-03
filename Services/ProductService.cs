using Microsoft.Identity.Client;
using WebApplication1.Models;


namespace WebApplication1.Services
{
    public class ProductService
    {

        static List<Product> products { get; }
        static int nextId = 3;

        public static List<Product> GetAll() => products;

        public static Product? Get(int id) => products.FirstOrDefault(p => p.ProductID  == id);

        public static void Add(Product product)
        {
            product.ProductID = nextId++;
            products.Add(product);
        }

        public static void Update(Product product)
        {
            var index = products.FindIndex(p => p.ProductID == product.ProductID);
            if (index == -1)
                return;

            products[index] = product;
        }

        public static void Delete(int id)
        {
            var product = Get(id);
            if(product == null) return;

            products.Remove(product);
        }
    }
}
