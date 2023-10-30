using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkLogic.Common.InputOutput;

namespace ThinkLogic.Domain.Interfaces.Repository
{
    public interface IRepository<T> 
    {
        TLResponse<int> Insert(T model);
        TLResponse<int> Update(T model);
        TLResponse<int> Delete(int id);
        TLResponse<T> GetById(int id);
        TLListResponse<T> GetByRequest<TFilter>(TLRequest<TFilter> request);
    }
}
