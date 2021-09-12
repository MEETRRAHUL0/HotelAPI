using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Model
{
    public class StoresActionsRequest
    {
        public string location_ref_id { get; set; }
        public List<string> platforms { get; set; }
        public string action { get; set; }
    }
}
