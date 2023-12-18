using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.ResponseModels
{
    public class BaseResponse
    {
        // İşlemin başarılı olup olmadığını belirten özellik.
        public bool Success { get; set; }
        // İşlemle ilgili bilgi veya hata mesajını içeren özellik.
        public string Message { get; set; }


    }
    public class BaseResponse<T> : BaseResponse
    {
        // Jenerik veriyi içeren özellik.
        public T Data { get; set; }
    }
}
