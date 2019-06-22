using NBA.Model;
using System.Collections.Generic;

namespace NBA.Biz
{
    public interface INBAStandingBiz
    {
        bool InsertNBAStandings(List<NBAStanding> sstandings);

    }
}
