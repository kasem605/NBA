using System.Data;

namespace NBA.Dal.Interfaces
{
    public interface IParameter<T>
    {
        IDbDataParameter[] CreateParameters(T s);
    }
}
