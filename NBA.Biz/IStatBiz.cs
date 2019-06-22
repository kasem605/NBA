using NBA.Model;
using System.Collections.Generic;

namespace NBA.Biz
{
    public interface IStatBiz
    {
        bool InsertStatData(List<Stat> stats);

    }
}
