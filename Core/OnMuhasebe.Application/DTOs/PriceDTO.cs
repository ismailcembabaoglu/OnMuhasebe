using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class PriceDTO: BaseModelDTO
    {
        public int ProductId { get; set; }
        public PriceType PriceType { get; set; }
        public decimal PriceValue { get; set; }
        public Guid KdvId { get; set; }
        public bool IsDefault { get; set; }

    }
}
