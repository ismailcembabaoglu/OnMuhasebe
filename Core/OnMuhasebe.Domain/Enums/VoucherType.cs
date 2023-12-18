using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Enums
{
    public enum VoucherType
    {
        Purchase, // Ürün veya hizmet alımı için düzenlenen fiş
        Sales,     // Ürün veya hizmet satışı için düzenlenen fiş
        Return,     // Ürün veya hizmet iadesi için düzenlenen fiş
        Expense,    // Genel giderler için düzenlenen fiş
        Income,      //Genel gelirler için düzenlenen fiş
        Transfer,   // Para veya mal transferi için düzenlenen fiş
        Other,      // Diğer çeşitli işlemler için düzenlenen fiş
    }
}
