namespace NBA.Dal.DatabaseFactory
{
    /// <summary>
    /// Class that is a part of the Factory Pattern Design Pattern
    /// </summary>
    public static class DBFactory
    {
        /// <summary>
        /// Factory method to create the specific Database class to get the correct connection
        /// </summary>
        /// <param name="dBType"></param>
        /// <returns>New Class</returns>
        public static IConnection CreateConnection(DBType dBType)
        {
            switch(dBType)
            {
                case DBType.SQL:
                    return new SQLDb();
                default:
                    return null;
            }
        }
    }
}
