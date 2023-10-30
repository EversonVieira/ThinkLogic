using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ThinkLogic.Common.InputOutput;
using ThinkLogic.Common.Models;
using ThinkLogic.Domain.Common;
using ThinkLogic.Domain.Interfaces.Repository;

namespace ThinkLogic.Domain.Implementations.Repository
{
    public class ScheduledEventRepository : IRepository<ScheduledEvent>
    {
        private readonly ThinkLogicDatabaseContext _databaseContext;

        public ScheduledEventRepository(ThinkLogicDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public TLResponse<int> Delete(int id)
        {
            var response = new TLResponse<int>();

            response.Data = _databaseContext.WithTransaction((transaction) =>
            {
                string sql = $"DELETE FROM ScheduledEvents WHERE Id = @Id; SELECT @@ROWCOUNT AS DELETED;";

                return _databaseContext.Connection.Query<int>(sql, new {Id = id}, transaction).FirstOrDefault();
            });

            if (response.Data == 0)
            {
                response.Messages.Add(new Message
                {
                    Code = "X",
                    Text = $"Error while attempting to remove the event, the event with id:{id} was not found in database.",
                    Title = "Validation",
                    Type = Message.MessageTypeEnum.Caution
                });
            }

            return response;
        }

        public TLResponse<ScheduledEvent> GetById(int id)
        {
            var response = new TLResponse<ScheduledEvent>();

            string sql = $"SELECT * FROM ScheduledEvents WHERE Id = @Id";
            
            response.Data = _databaseContext.Connection.Query<ScheduledEvent>(sql, new {Id = id}).FirstOrDefault();

            return response;
        }

        public TLListResponse<ScheduledEvent> GetByRequest<TFilter>(TLRequest<TFilter> request)
        {
            var response = new TLListResponse<ScheduledEvent>();

            string sql = $"SELECT * FROM ScheduledEvents";

            response.Data = _databaseContext.Connection.Query<ScheduledEvent>(sql).ToList();

            return response;
        }

        public TLResponse<int> Insert(ScheduledEvent model)
        {
            var response = new TLResponse<int>();

            string sql = 
                $@"INSERT INTO ScheduledEvents(Title,Location,Description,StartDate,EndDate) 
                   VALUES(@Title,@Location,@Description,@StartDate,@EndDate); SELECT SCOPE_IDENTITY();";


            response.Data = _databaseContext.WithTransaction((transaction) =>
            {
               return _databaseContext.Connection.ExecuteScalar<int>(sql, model,transaction);
            });

            return response;
        }

        public TLResponse<int> Update(ScheduledEvent model)
        {
            var response = new TLResponse<int>();

            string sql =
                $@"UPDATE ScheduledEvents 
                   SET Title = @Title,
                       Location = @Location,
                       Description = @Description,
                       StartDate = @StartDate,
                       EndDate = @StartDate
                   WHERE Id = @Id; SELECT @@ROWCOUNT AS DELETED;";


            response.Data = _databaseContext.WithTransaction((transaction) =>
            {
                return _databaseContext.Connection.ExecuteScalar<int>(sql, model, transaction);
            });

            return response;
        }
    }
}
