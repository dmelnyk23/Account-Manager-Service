using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Site
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Reference { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Account> Accounts{ get; set; }

        public virtual User User{ get; set; }


    }
}
