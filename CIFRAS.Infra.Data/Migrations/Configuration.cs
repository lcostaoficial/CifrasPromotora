using System.Data.Entity.Migrations;

namespace CIFRAS.Infra.Data.Migrations
{ 
    internal sealed class Configuration : DbMigrationsConfiguration<Context.CifrasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.CifrasContext context) { }      
    }
}