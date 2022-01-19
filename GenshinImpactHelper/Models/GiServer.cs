using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenshinImpactHelper.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class GiServer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual ICollection<GiAccount> Accounts { get; set; }
    }
}
