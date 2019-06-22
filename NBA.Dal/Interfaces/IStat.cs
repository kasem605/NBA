using NBA.Model;
using System.Collections.Generic;

namespace NBA.Dal.Interfaces
{
    public interface IStat
    {
        bool InsertStatData(List<Stat> stats);
    }
}
