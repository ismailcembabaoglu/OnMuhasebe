using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.ResponseModels
{
    public class ValidationErrorResponse: ErrorResponse
    {
        // Kurucu metod: Validation hatasını temsil eden bir hata cevabı oluşturur.
        public ValidationErrorResponse(string message) : base(message)
        {
            // Base sınıf olan ErrorResponse'tan türemiştir.
            // Validation hataları genellikle başarısız işlemleri ifade eder, bu nedenle Success özelliği false olarak ayarlanır.
            // Message özelliği, hata mesajını içerir ve base sınıfın kurucu metoduna iletilir.
        }
    }
}
