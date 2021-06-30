﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LICENTA4.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Display(Name = "Genre")]
        public string Name { get; set; }
    }
}