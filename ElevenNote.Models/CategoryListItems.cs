using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryListItems
    {
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Category Description")]
        public string CategoryDesc { get; set; }


    }
}
