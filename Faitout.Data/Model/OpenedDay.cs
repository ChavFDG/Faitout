using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Faitout.Data.Model
{
    public class OpenedDay
    {
        public OpenedDay()
        {

        }
        public OpenedDay(DayOfWeek day, bool isOpen = true)
        {
            Day = day;
            IsOpen = isOpen;
        }

        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        //Day
        [Display(Name = "Jour")]
        public DayOfWeek Day { get; set; }
        [Display(Name = "Est ouvert")]
        public bool IsOpen { get; set; } = true;
        //Pickup
        [Display(Name = "Fait du à emporter")]
        public bool EnablePickUp { get; set; } = false;
        //Delivery
        [Display(Name = "Fait de la livraison")]
        public bool EnableDelivery { get; set; } = false;
        public List<TimeRange> TimeRanges { get; set; } = new List<TimeRange>();
    }
}
