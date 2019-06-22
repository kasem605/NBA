using NBA.Model;
using System.Collections.Generic;

namespace NBA.Dal.Interfaces
{
    public interface INBAStanding
    {
        bool InsertNBAStandings(IEnumerable<NBAStanding> standings);
    }
}
