using Core.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base.Interface.Service
{
    public interface IGameService
    {
        IList<Game> GetAll();
        bool Add(Game game);
        bool Update(Game game);
        bool Delete(int id);
        Game GetGame(int Id);
        bool Devolve(Game game);
    }
}
