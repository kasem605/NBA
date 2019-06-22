using NBA.Model;
using System.Collections.Generic;

namespace NBA.Biz
{
    public interface IDepthChartBiz
    {
        bool InsertDepthChart(List<DepthChart> charts);
    }
}
