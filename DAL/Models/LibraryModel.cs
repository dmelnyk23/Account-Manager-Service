using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class LibraryModel : DbContext
    {
        public LibraryModel()
            : base("name=LibraryModel")
        {
            Database.SetInitializer<LibraryModel>(new CustomInitializer<LibraryModel>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Site> Sites{ get; set; }
        public virtual DbSet<Account> Accounts{ get; set; }

    }
}
