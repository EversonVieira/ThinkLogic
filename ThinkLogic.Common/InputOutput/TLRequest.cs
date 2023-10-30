using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkLogic.Common.InputOutput
{
    public class TLRequest<T>
    {
        public int PageNumber { get; set; } = 0;
        public int ItemsPerPage { get; set; } = 0;
        public bool WithPagination { get; set; }
        public T? FilterObject { get; set; }
    }
}
