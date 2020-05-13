using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEBvize.Models;

namespace WEBvize.Models
{
    public class Movie
    {
        public int id { get; set; }

        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        public string Name { get; set;}

        [Required(ErrorMessage = "Yıl alanı gereklidir.")]
        public int Year { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage = "Açıklama alanı gereklidir.")]
        public string Description { get; set;}

        [Required(ErrorMessage = "Başrol alanı gereklidir.")]
        public string Headliner { get; set; }

        public Category category{ get; set; }
        [Required(ErrorMessage ="Kategori alanı seçimi gereklidir.")]
        public int categoryId { get; set; }

        public List<Comment> Comment = new List<Comment>();
    }
}