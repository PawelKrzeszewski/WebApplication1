using Humanizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set;}

        public string? Name { get; set;}

        public string? Description { get; set;}  

        public bool IsDeleted {  get; set;}

        public DateTime Date {  get; set;}  

        public int CreatorId {  get; set;}

        public string? ImageUrl { get; set;} 

    }
}
