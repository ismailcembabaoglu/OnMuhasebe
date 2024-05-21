using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Enums;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class PriceDTO: BaseModelDTO
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductNumber { get; set; }
        public decimal PriceValue { get; set; }
        public string PriceType { get; set; }
        public Guid KdvId { get; set; }
        public string? KdvName { get; set; }
        public decimal? KdvRatio { get; set; }
        public bool IsDefault { get; set; }

    }
}
