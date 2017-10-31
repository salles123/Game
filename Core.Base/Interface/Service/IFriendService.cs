using Core.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base.Interface.Service
{
    public interface IFriendService
    {

        IList<Friend> GetAll();
        bool Add(Friend friend);
        bool Update(Friend friend);
        bool Delete(int id);
        Friend GetFriend(int Id);
    }
}
