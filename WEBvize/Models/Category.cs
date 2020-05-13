using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBvize.Models
{
    public class Category
    {
        
        public int id { get; set; }

        [Required(ErrorMessage ="Kategori ismi Zorunludur.")]
        public string Name { get; set; }

       public List<Movie> movies = new List<Movie>();


    }
}