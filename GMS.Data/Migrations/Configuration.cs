using GMS.Data.Context;
using GMS.Data.Seeds;

namespace GMS.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(GMSContext context)
        {
            UsuarioSeed.Seed(context);
        }
    }
}
