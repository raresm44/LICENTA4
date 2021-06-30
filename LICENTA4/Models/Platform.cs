using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LICENTA4.Models
{
    public class Platform
    {
        public int Id { get; set; }

        [Display(Name = "Platforma")]
        public string Name { get; set; }
    }
}