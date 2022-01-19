using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenshinImpactHelper.Models
{
    [Index(nameof(Title))]
    public class GiPersone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual GiElement Element { get; set; }
        public virtual GiCountry Country { get; set; }
    }
}
