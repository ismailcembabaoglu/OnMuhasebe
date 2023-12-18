using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.ResponseModels
{
   
    public class ServiceResponse<T> : BaseResponse
    {
        // Generic bir veri tipi ile birlikte bu sınıfın bir özelliği.
        public T Value { get; set; }

    }
}
