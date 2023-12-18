using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.ResponseModels
{
    public class NotFoundResponse: ErrorResponse
    {
        // Kurucu metod: Entity adı ve ID bilgisini alır ve sınıfın özelliklerini ayarlar.
        public NotFoundResponse(string entityName, object entityId): base($"{entityName} with ID {entityId} not found.")
        {
            // Bu sınıf, ErrorResponse sınıfından türediği için ErrorResponse sınıfının kurucu metodunu çağırmalıdır.
            // NotFound durumu genellikle başarısız olduğu için Success özelliği false olarak ayarlanır.
            // Message özelliği, kullanıcıya gösterilmek üzere bir hata mesajını içerir.

        }
    }
}
