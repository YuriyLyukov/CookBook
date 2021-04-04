namespace API.Contracts.V1.Requests
{
    public class UpdateRecipeRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}