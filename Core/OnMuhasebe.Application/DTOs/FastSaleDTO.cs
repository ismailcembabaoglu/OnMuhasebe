using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class FastSaleDTO : BaseModelDTO
    {
        public Guid FastSaleGroupId { get; set; }
        public Guid ProductId { get; set; }
    }
}
