using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] public int CategoryID { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}
