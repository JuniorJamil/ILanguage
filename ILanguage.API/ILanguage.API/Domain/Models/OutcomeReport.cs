using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Models
{
    public class OutcomeReport
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
