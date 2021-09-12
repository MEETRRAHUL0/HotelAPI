using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Model
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Slot
    {
        public string start_time { get; set; }
        public string end_time { get; set; }
    }

    public class DaySlot
    {
        public string day { get; set; }
        public List<Slot> slots { get; set; }
    }

    public class TimingGroup
    {
        public string title { get; set; }
        public List<string> category_ref_ids { get; set; }
        public List<DaySlot> day_slots { get; set; }
    }

    public class CategoryTimingGroupsRequest
    {
        public List<TimingGroup> timing_groups { get; set; }
    }
}
