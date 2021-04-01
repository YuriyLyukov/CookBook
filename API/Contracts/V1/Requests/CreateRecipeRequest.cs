using System;

namespace API.Contracts.V1.Requests
{
    public class CreateRecipeRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}