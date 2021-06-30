using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using LICENTA4.Models;

namespace LICENTA4.Dtos
{
    public class PostDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        // public Genre Genre { get; set; }
        public string Description { get; set; }
        // public int CountryId { get; set; }
        // public Country Country { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateRelease { get; set; }
        public float Price { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}