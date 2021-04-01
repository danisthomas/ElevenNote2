using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class NoteListItems
    {
        public int NoteId { get; set; }
        [ForeignKey(nameof(category))]
        public int CategoryId { get; set; }
        public virtual Category category { get; set; }
        public string CategoryName { get; set; }

        public string CategoryDesc { get; set; }
        public string Title { get; set; }
        [UIHint("Starred")]
        public bool IsStarred { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
