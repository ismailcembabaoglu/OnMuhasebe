using OnMuhasebe.Application.DTOs.BaseModelDTOs;
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
        public decimal PriceValue { get; set; }
        public Guid KdvId { get; set; }
        public bool IsDefault { get; set; }

    }
    public enum PriceTypeDTO
    {
        Regular,
        Discounted
    }
}
