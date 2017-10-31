using Core.Base.Model;
using Infra.Data.Map;
using Infra.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context
{
    public class S2Models : DbContext
    {
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Game> Games { get; set; }

        public S2Models()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<S2Models, Configuration>());
            //Configuration.ProxyCreationEnabled = true;
            //Configuration.LazyLoadingEnabled = true;

            modelBuilder.Configurations.Add(new FriendMap());
            modelBuilder.Configurations.Add(new GameMap());
        }

        public static S2Models Create()
        {
            return new S2Models();
        }
    }
}
