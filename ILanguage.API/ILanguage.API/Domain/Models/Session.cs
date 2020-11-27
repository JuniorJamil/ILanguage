using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string StartAt { get; set; }
        public string EndAt { get; set; }

        public string Link { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public IList<SessionDetails> SessionsDetails { get; set; } = new List<SessionDetails>();

        public IList<Resource> Resources { get; set; } = new List<Resource>();

        public IList<OutcomeReport> OutcomeReports { get; set; } = new List<OutcomeReport>();



    }
}
