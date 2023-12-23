using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class ProductDTO: BaseModelDTO
    {
        public bool IsActive { get; set; }
        public string ProductNumber { get; set; }
        public string Barcode { get; set; }
        public Guid ProductGroupId { get; set; }
        public string? ProductGroupName { get; set; }
        public Guid UnitId { get; set; }
        public string? UnitName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string GuaranteePeriod { get; set; }
        public string Producer { get; set; }
        public string Photo { get; set; }
    }
}
