using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBA.Model;

namespace NBA.Biz
{
    public interface IPlayerBiz
    {
        bool InsertPlayersData(List<Player> players);
    }
}
