using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkLogic.Domain.Interfaces.Validator
{
    public interface IValidator<T>
    {
        bool IsValid(T value, string context);
    }
}
