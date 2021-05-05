using System;

namespace BusinessLogicLayer.Models
{
    public class ShopWorkTimeModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime MondayFrom { get; set; }
        public DateTime MondayTo { get; set; }
        public bool MondayDayOffFlag { get; set; }
        public DateTime TuesdayFrom { get; set; }
        public DateTime TuesdayTo { get; set; }
        public bool TuesdayDayOffFlag { get; set; }
        public DateTime WednesdayFrom { get; set; }
        public DateTime WednesdayTo { get; set; }
        public bool WednesdayDayOffFlag { get; set; }
        public DateTime ThursdayFrom { get; set; }
        public DateTime ThursdayTo { get; set; }
        public bool ThursdayDayOffFlag { get; set; }
        public DateTime FridayFrom { get; set; }
        public DateTime FridayTo { get; set; }
        public bool FridayDayOffFlag { get; set; }
        public DateTime SaturdayFrom { get; set; }
        public DateTime SaturdayTo { get; set; }
        public bool SaturdayDayOffFlag { get; set; }
        public DateTime SundayFrom { get; set; }
        public DateTime SundayTo { get; set; }
        public bool SundayDayOffFlag { get; set; }
    }
}
