using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkLogic.Common.InputOutput;

namespace ThinkLogic.Domain.Interfaces.Business
{
    public interface IBusiness<T>
    {
        TLResponse<int> Insert(T model);
        TLResponse<int> Update(T model);
        TLResponse<int> Delete(T model);
        TLResponse<T> GetById(int id);
        TLResponse<T> GetByRequest<TFilter>(TLRequest<TFilter> request);
    }
}
