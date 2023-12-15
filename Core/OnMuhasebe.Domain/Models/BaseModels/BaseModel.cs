using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnMuhasebe.Domain.Models.BaseModels
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedUser { get; set; }
        public string? UpdatedUser { get; set; }
        public bool IsDeleted { get; set; }

        public string? Description { get; set; }

    }
}
