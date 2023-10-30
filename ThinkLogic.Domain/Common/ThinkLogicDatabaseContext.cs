using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkLogic.Domain.Common
{
    public class ThinkLogicDatabaseContext
    {
        public SqlConnection Connection { get; private set; }

        public ThinkLogicDatabaseContext(ThinkLogicDatabaseContextOptions options)
        {
            Connection = new SqlConnection(options.ConnectionString);
            Connection.Open();
        }

        public void WithTransaction(Action action)
        {
            try
            {
                var transaction = Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                try
                {
                    action();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T? WithTransaction<T>(Func<T> action)
        {
            try
            {
                var transaction = Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                T? result = default(T);

                try
                {
                    result = action();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                return result;

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
