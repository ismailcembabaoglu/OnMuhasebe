using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class KdvDTO: BaseModelDTO
    {
        public string KdvName { get; set; }
        public decimal KdvRatio { get; set; }

    }
}
