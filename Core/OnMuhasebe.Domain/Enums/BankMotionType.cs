using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Enums
{
    public enum BankMotionType
    {
        Deposit,          // Para yatırma
        Withdrawal,       // Para çekme
        TransferIn,       // Transfer alma
        TransferOut,      // Transfer gönderme
        Other             // Diğer işlemler
    }
}
