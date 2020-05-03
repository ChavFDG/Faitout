using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class TimeRange
    {
        [Key]
        public Guid Id { get; set; }

        public Guid OpenedDayId { get; set; }
        [ForeignKey(nameof(OpenedDayId))]
        public virtual OpenedDay OpenedDay{ get; set; }

        [Display(Name = "Type")]
        public OpenType OpenType { get; set; } = OpenType.Open;
        //Opening hours
        [Display(Name = "De")]
        public TimeSpan From { get; set; } = new TimeSpan(11, 45, 0);
        [Display(Name = "A")]
        public TimeSpan To { get; set; } = new TimeSpan(13, 45, 0);

    }

    public enum OpenType
    {
        Open,
        Delivery,
        PickUp
    }
}
