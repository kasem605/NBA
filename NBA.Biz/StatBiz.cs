using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBA.Model;
using NBA.Dal.Interfaces;

namespace NBA.Biz
{
    public class StatBiz : IStatBiz
    {
        private IStat iStat;
        public StatBiz(IStat iStat)
        {
            this.iStat = iStat;
        }

        public bool InsertStatData(List<Stat> stats)
        {
            bool returnState = false;

            List<Stat> statList = null;

            try
            {
                statList = stats;
                returnState = iStat.InsertStatData(statList);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + "\nFrom Business layer");
            }

            return returnState;
        }
    }
}
