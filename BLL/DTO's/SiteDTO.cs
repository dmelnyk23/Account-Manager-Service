using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO_s
{
    public class SiteDTO
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Reference { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<AccountDTO> Accounts { get; set; }

        public virtual UserDTO User { get; set; }

    }
}
