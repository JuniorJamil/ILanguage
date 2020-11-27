﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Starts { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
