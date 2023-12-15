﻿using OnMuhasebe.Application.DTOs.BaseModelDTOs;
using OnMuhasebe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Application.DTOs
{
    public class BankMotionDTO : BaseModelDTO
    {
        public string VoucherCode { get; set; }
        public BankMotionTypeDTO BankMotionType { get; set; }
        public Guid BankId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Price { get; set; }
    }
    public enum BankMotionTypeDTO
    {
        Deposit,
        Withdrawal,
        Transfer
    }
}
