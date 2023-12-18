using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Enums
{
    public enum SafeBoxMotionType
    {
        Deposit, // Kasaya para yatırma işlemi
        Withdrawal,  // Kasadan para çekme işlemi
        TransferIn,  // Başka bir kaynaktan kasaya para transferi
        TransferOut, // Kasadan başka bir hedefe para transferi   
        Expense,    // Kasadan harcama yapma işlemi
        Income,      // Kasaya gelir ekleme işlemi
    }
}
