using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class BankDTO:BaseModelDTO
    {
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string BankName { get; set; }
        public string Branch { get; set; }
        public string IbanNo { get; set; }
        public string AccountNo { get; set; }
        public string AuthName { get; set; }
        public string AuthPhone { get; set; }
    }
}
