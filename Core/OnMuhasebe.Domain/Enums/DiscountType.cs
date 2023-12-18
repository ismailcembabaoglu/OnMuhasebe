using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Enums
{
    public enum DiscountType
    {
        Percentage,   // Yüzde indirim
        Amount,       // Miktar indirim
        Gift,         // Hediye ürün veya hizmet
        SpecialOffer  // Özel teklif
    }
}
