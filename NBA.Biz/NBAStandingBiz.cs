using NBA.Dal.Interfaces;
using NBA.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NBA.Biz
{
    public class NBAStandingBiz : INBAStandingBiz
    {
        private INBAStanding iNBAStanding;
        public NBAStandingBiz(INBAStanding iNBAStanding)
        {
            this.iNBAStanding = iNBAStanding;
        }

        public bool InsertNBAStandings(List<NBAStanding> standings)
        {
            bool returnState = false;

            List<NBAStanding> standingList = null;

            try
            {
                standingList = standings.ToList();
                returnState = iNBAStanding.InsertNBAStandings(standings);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message + "\nFrom Business layer");
            }

            return returnState;
        }
    }
}
