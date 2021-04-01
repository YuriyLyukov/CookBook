using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain
{
    public class Recipe
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? ParentId { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int DepthLevel { get; set; }
        public Guid TreeId { get; set; }
    }
}