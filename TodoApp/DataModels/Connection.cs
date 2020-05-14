using LinqToDB.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace TodoApp
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }
    public class Connection : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "PostgreSQL";
        public string DefaultDataProvider => "PostgreSQL";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "todo_db",
                        ProviderName = "PostgreSQL",
                        ConnectionString = @"User ID=zz;Password=ee;Host=localhost;Port=5432;Database=todo_db"
                    };
            }
        }
    }
}