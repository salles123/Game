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
    public class FriendService : IFriendService
    {
        IRepository<Friend> _friendRepository;
        public FriendService(IRepository<Friend> friendRepository)
        {
            _friendRepository = friendRepository;
        }
        public bool Add(Friend friend)
        {
            if (friend.IsValid)
                return _friendRepository.Insert(friend);

            return false;
        }

        public bool Delete(int id)
        {
            var friend = GetFriend(id);
            return _friendRepository.Delete(friend);
        }

        public Friend GetFriend(int Id)
        {
            return _friendRepository.GetAll()
                                     .Where(x => x.Id == Id).FirstOrDefault();
        }

        public IList<Friend> GetAll()
        {
            return _friendRepository.GetAll().ToList();
        }


        public bool Update(Friend friend)
        {
            if (friend.IsValid)
            {
                GetFriend(friend.Id).Update(friend);

                return _friendRepository.SaveChanges();
            }

            return false;
        }
    }
}
