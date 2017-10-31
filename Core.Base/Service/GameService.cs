using Core.Base.Interface.Repository;
using Core.Base.Interface.Service;
using Core.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base.Service
{
    public class GameService : IGameService
    {
        IRepository<Game> _gameRepository;
        public GameService(IRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public bool Add(Game game)
        {
            if (game.IsValid)
                return _gameRepository.Insert(game);

            return false;
        }

        public bool Delete(int id)
        {
            var game = GetGame(id);
            return _gameRepository.Delete(game);
        }

        public Game GetGame(int Id)
        {
            return _gameRepository.GetAll()
                                     .Where(x => x.Id == Id).FirstOrDefault();
        }

        public IList<Game> GetAll()
        {
            return _gameRepository.GetAll().ToList();

        }


        public bool Update(Game game)
        {
            if (game.IsValid)
            {
                GetGame(game.Id).Update(game);

                return _gameRepository.SaveChanges();
            }

            return false;
        }

        public bool Devolve(Game game)
        {
            if (game.IsValid)
            {
                GetGame(game.Id).Devolve(game);

                return _gameRepository.SaveChanges();
            }

            return false;
        }
    }
}
