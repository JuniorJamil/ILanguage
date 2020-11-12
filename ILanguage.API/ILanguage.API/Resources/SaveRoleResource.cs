using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ILanguage.API.Resources
{
    public class SaveRoleResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
