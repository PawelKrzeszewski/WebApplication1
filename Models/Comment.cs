using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] public int CommentID { get; set; }

        public string? Description { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public string CreatorID { get; set; }  
    }
}
