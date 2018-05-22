using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class CustomInitializer<T> : DropCreateDatabaseAlways<LibraryModel>
    {
        protected override void Seed(LibraryModel context)
        {
            var account = new Account()
            {
                Login = "Dima",
                Password = "lolkek",
            };
            var account2 = new Account()
            {
                Login = "Sergiy",
                Password = "Cheburek",
            };

            List<Account> acc = new List<Account>() { account, account2 }; 
            var site = new Site()
            {
                Name = "Vkontakte",
                Reference = "https://vk.com",
                Description = "Social network",
                Accounts = acc
            };

            var site2 = new Site()
            {
                Name = "Facebook",
                Reference = "https://facebook.com",
                Description = "Social network",
            };
            List<Site> siteList = new List<Site>() { site, site2 };

            var user = new User()
            {
                Login = "1",
                Password = "1",
                Sites = siteList
            };

            context.Users.Add(user);
            context.SaveChanges();

        }
    }
}
