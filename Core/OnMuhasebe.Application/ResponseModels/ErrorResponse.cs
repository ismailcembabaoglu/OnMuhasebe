using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.ResponseModels
{
    public class ErrorResponse: BaseResponse
    {
        // Kurucu metod: Hata mesajını alır ve sınıfın özelliklerini ayarlar.
        public ErrorResponse(string message)
        {
            // Temel sınıf olan BaseResponse'ın kurucu metodunu çağırır.
            // Bu, Success ve Message özelliklerini ayarlar.
            // Hata durumunda genellikle başarısız olduğu için Success özelliği false olarak ayarlanır.
            // Message özelliği, kullanıcıya gösterilmek üzere bir hata mesajını içerir.
            Success = false;
            Message = message;
        }
    }
}
