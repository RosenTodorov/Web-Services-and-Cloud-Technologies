namespace TravelWithMe.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Travel
    {
        public int Id { get; set; }


        public virtual TravelWithMeUser User { get; set; }

        [MinLength(10)]
        [MaxLength(6000)]
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal TicketCost { get; set; }

        public virtual City StartLocation { get; set; }

        public virtual City EndLocation { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public TimeSpan? SpendingTime
        {
            get
            {
                return this.EndDate - this.StartDate;
            }
        }
    }
}
