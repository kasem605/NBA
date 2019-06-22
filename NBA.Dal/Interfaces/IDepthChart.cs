using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBA.Model;

namespace NBA.Dal.Interfaces
{
    public interface IDepthChart
    {
        bool InsertDepthChart(List<DepthChart> dCharts);
    }
}