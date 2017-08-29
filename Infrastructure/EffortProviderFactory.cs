using System.Data.Common;
using System.Data.Entity.Infrastructure;

namespace EntityFrameworkEffort.Infrastructure
{
    internal class EffortProviderFactory : IDbConnectionFactory
    {
        private static readonly object Lock = new object();

        private static DbConnection _connection;
        
        public static void ResetDb()
        {
            lock (Lock)
            {
                _connection = null;
            }
        }

        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            lock (Lock)
            {
                return _connection ?? (_connection = Effort.DbConnectionFactory.CreateTransient());
            }
        }
    }
}