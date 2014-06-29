using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEventStore.Persistence.Sql;

namespace EventStoreTester.ServiceBus {
  public class SqlTenantEventStoreConnectionFactory : IConnectionFactory {

    string _connectionStr;

    public SqlTenantEventStoreConnectionFactory(string connectionStr) {
      _connectionStr = connectionStr;
    }

    public Type GetDbProviderFactoryType() {
      return typeof(SqlTenantEventStoreConnectionFactory);
    }

    public System.Data.IDbConnection Open() {
      var c = new SqlConnection(_connectionStr);
      c.Open();
      return c;
    }
  }
}
