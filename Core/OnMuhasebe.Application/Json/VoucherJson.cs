using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.Json
{
    public static class VoucherJson
    {
        public static string json = @"
[
    { ""Property"": ""VoucherCode"", ""Title"": ""Kupon Kodu"" },
    { ""Property"": ""VoucherType"", ""Title"": ""Kupon Türü"" },
    { ""Property"": ""DocumentNo"", ""Title"": ""Belge Numarası"" },
    { ""Property"": ""DiscountRate"", ""Title"": ""İndirim Oranı"" },
    { ""Property"": ""DiscountPrice"", ""Title"": ""İndirim Tutarı"" },
    { ""Property"": ""Owed"", ""Title"": ""Borçlu"" },
    { ""Property"": ""Debt"", ""Title"": ""Borç"" },
    { ""Property"": ""TotalPrice"", ""Title"": ""Toplam Fiyat"" },
    { ""Property"": ""CustomerId"", ""Title"": ""Müşteri ID"" },
    { ""Property"": ""CustomerName"", ""Title"": ""Müşteri Adı"" },
    { ""Property"": ""CustomerCode"", ""Title"": ""Müşteri Kodu"" }
]";
    }
}
