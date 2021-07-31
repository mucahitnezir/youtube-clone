using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoApp.Core.Entities
{
    public abstract class EntityBase
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Column(Order = 1200)]
        public DateTime? CreatedAt { get; set; }

        [Column(Order = 1300)]
        public DateTime? UpdatedAt { get; set; }

        [Column(Order = 1400)]
        public Guid? CreatedBy { get; set; }

        [Column(Order = 1500)]
        public Guid? UpdatedBy { get; set; }

        public virtual string Describe(EventType eventType)
        {
            return null;
        }
    }
}
