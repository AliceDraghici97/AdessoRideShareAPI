using System.ComponentModel.DataAnnotations;

namespace AdessoRideShareAPI.Models
{
    public class TravelPlan
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int MaxNoOfSeats { get; set; }
        public int OccupiedNoOfSeats { get; set; }
        public bool Published { get; set; }
    }
}