using NBA.Model;
using System.Collections.Generic;

namespace NBA.Dal.Interfaces
{
    public interface IPlayer
    {
        bool InsertPlayersData(List<Player> players);
    }
}
