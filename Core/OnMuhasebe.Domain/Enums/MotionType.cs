using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Enums
{
    public enum MotionType
    {
        Purchase,       // Satın alma işlemi
        Sale,           // Satış işlemi
        Return,         // İade işlemi
        TransferIn,     // Transfer (Ürün girişi)
        TransferOut,    // Transfer (Ürün çıkışı)
        AdjustmentIn,   // Düzeltme (Artış)
        AdjustmentOut   // Düzeltme (Azalış)
    }
}
