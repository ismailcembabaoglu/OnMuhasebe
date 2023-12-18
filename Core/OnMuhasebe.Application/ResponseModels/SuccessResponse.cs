using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.ResponseModels
{
    public class SuccessResponse<T> : BaseResponse<T>
    {
        // Kurucu metod: Başarılı bir cevap oluşturur, veriyi ve başarı durumunu ayarlar.
        public SuccessResponse(T data)
        {
            // BaseResponse<T> sınıfından türediği için, Success ve Data özelliklerini miras alır.
            // Success özelliği, başarılı bir işlemin gerçekleşip gerçekleşmediğini belirtir.
            // Default olarak true olarak ayarlanır, çünkü başarılı bir cevap oluşturuyoruz.
            // Data özelliği, başarılı bir işlem sonucunda döndürülen veriyi içerir.
            Success = true;
            Data = data;
        }
    }
}
