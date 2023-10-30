using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkLogic.Common.InputOutput;
using ThinkLogic.Common.Models;
using ThinkLogic.Domain.Implementations.Repository;
using ThinkLogic.Domain.Interfaces.Business;
using ThinkLogic.Domain.Interfaces.Repository;
using ThinkLogic.Domain.Interfaces.Validator;

namespace ThinkLogic.Domain.Implementations.Business
{
    public class ScheduledEventBusiness : IBusiness<ScheduledEvent>
    {
        private readonly IRepository<ScheduledEvent> _repository;
        private readonly IValidator<ScheduledEvent> _validator;

        public ScheduledEventBusiness(IRepository<ScheduledEvent> repository, IValidator<ScheduledEvent> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public TLResponse<int> Delete(int id)
        {
            return _repository.Delete(id);
        }

        public TLResponse<ScheduledEvent> GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TLListResponse<ScheduledEvent> GetByRequest<TFilter>(TLRequest<TFilter> request)
        {
            return _repository.GetByRequest(request);
        }

        public TLResponse<int> Insert(ScheduledEvent model)
        {
            var validationResponse = _validator.IsValid(model, "INSERT");
            if (validationResponse.HasStopEventMessages)
            {
                return new TLResponse<int>
                {
                    Messages = validationResponse.Messages
                };
            }

            return _repository.Insert(model);
        }

        public TLResponse<int> Update(ScheduledEvent model)
        {
            var validationResponse = _validator.IsValid(model, "UPDATE");
            if (validationResponse.HasStopEventMessages)
            {
                return new TLResponse<int>
                {
                    Messages = validationResponse.Messages
                };
            }

            return _repository.Update(model);
        }
    }
}
