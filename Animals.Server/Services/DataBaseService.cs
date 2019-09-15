using Animals.Server.Models;

namespace Animals.Server.Services
{
    public static class DataBaseService
    {
        public static bao_ton_tnContext DataBase { get; set; }
        public static void Create (bao_ton_tnContext context)
        {
            context.Database.EnsureCreated();
            DataBase = context;
        }
    }
}
