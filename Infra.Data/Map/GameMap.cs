using Core.Base.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Map
{
    public class GameMap : EntityTypeConfiguration<Game>
    {
        public GameMap()
        {
            ToTable("Games");
            HasKey(x => x.Id);

            HasOptional(game => game.Friend).WithMany(friend => friend.Games).HasForeignKey(game => game.FriendId);
        }
    }
}
