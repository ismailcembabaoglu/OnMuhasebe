using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Enums
{
    public enum PriceType
    {
        Cash,           // Nakit ödeme
        CreditCard,     // Kredi kartı ile ödeme
        BankTransfer,   // Banka havalesi veya EFT
        Check,          // Çekle ödeme
        VirtualCard,    // Sanal kartla ödeme
        Other           // Diğer ödeme türleri
    }
}
