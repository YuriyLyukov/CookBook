using System;

namespace API.Contracts.V1.Responses
{
    public class RecipeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int? ParentId { get; set; } = null;
        public int DepthLevel { get; set; }
        public Guid TreeId { get; set; }
    }
}