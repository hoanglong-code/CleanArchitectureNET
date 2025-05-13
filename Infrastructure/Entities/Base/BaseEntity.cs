
using Infrastructure.Reponsitories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Enums.ApiEnums;

namespace Infrastructure.Entities.Base
{
    public class BaseEntity<TId> : IEntity<TId>
    {
        public TId Id { get; set; }
        public virtual long? CreatedById { get; set; }
        public virtual long? UpdatedById { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual string? UpdatedBy { get; set; }
        public virtual EntityStatus Status { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}
