﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Resources
{
    public class OutcomeReportResource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public SessionResource Session { get; set; }
    }
}
