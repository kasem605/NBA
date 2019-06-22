using NBA.Dal.Interfaces;
using NBA.Model;
using System;
using System.Collections.Generic;

namespace NBA.Biz
{
    public class DepthChartBiz : IDepthChartBiz
    {
        private IDepthChart iDepthChart;

        public DepthChartBiz(IDepthChart iDepthChart) 
        {
            this.iDepthChart = iDepthChart;
        }

        public bool InsertDepthChart(List<DepthChart> charts)
        {
            bool insertStatus = false;

            try
            {
                insertStatus = iDepthChart.InsertDepthChart(charts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return insertStatus;
        }
    }
}
