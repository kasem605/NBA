using System.Data;

namespace NBA.Model
{
    public class Param
    {
        public string Name { get; set; }
        public DbType DBType { get; set; }
        public int Size { get; set; }
        public object Value { get; set; }
    }
}
