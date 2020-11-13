using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Resources
{
    public class AvailableScheduleResource
    {


        public int Id { get; set; }

        public string startAt { get; set; }
        public string endAt { get; set; }
        public bool state { get; set; }



        public UserResource User { get; set; }

    }
}
