namespace API.Controllers.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        
        public static class Recipes
        {
            public const string GetAll = Base + "/recipe";
            public const string Update = Base + "/recipe/{recipeId}";
            public const string Delete = Base + "/recipe/{recipeId}";
            public const string Get = Base + "/recipe/{recipeId}";
            public const string Create = Base + "/recipe";
        }
    }
}