using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class SafeBoxDTO : BaseModelDTO
    {
        public string SafeBoxCode { get; set; }
        public string SafeBoxName { get; set; }
        public string AuthCode { get; set; }
        public string AuthName { get; set; }
    }
}
