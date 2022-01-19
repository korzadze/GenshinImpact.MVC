using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenshinImpactHelper.Models
{
    public class GiAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Password { get; set; }

        public virtual int ServerId { get; set; }
        public virtual GiServer Server { get; set; }
    }
}
