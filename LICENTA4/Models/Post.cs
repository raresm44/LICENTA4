using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LICENTA4.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Nume Joc")]
        public string Title { get; set; }
        public int GenreId { get; set; }
        [Display(Name = "Gen")]
        public Genre Genre { get; set; }
        [Display(Name = "Descriere")]
        public string Description { get; set; }
        // public int CountryId { get; set; }
        // public Country Country { get; set; }
        [Display(Name = "Data Agaugare")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Data Lansare")]
        public DateTime? DateRelease { get; set; }
        [Display(Name = "pret")]
        public float Price { get; set; }
        
        public int PlatformId { get; set; }
        [Display(Name = "Platforma")]
        public Platform Platform { get; set; }
        [Display(Name = "Imagine")]
        public string Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public string UserId{ get; set; }

         public int Aprobare { get; set; }
        //public int Discount { get; set; }

    }
}