using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NBA.Dal.Interfaces
{
    public interface IGetRecordSet<T>
    {
        IEnumerable<T> GetRecordSet(SqlDataReader reader);

    }
}
