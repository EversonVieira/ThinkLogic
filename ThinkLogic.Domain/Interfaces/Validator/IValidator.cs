using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThinkLogic.Common.InputOutput;

namespace ThinkLogic.Domain.Interfaces.Validator
{
    public interface IValidator<T>
    {
        TLResponse<bool> IsValid(T value, string context);
    }
}
