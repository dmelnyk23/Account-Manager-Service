using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DatabaseDAL
    {
        private readonly LibraryModel _ctx = new LibraryModel();

        public User CheckUser(string login, string password)
        {
            return _ctx.Users.SingleOrDefault(x => x.Login == login && 
            x.Password == password);
        }

        public User CheckUserLogin(string login)
        {
            return _ctx.Users.SingleOrDefault(x => x.Login == login);
        }

        public void AddUser(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();
        }


        public void DeleteUser(User user)
        {
            var userDel = _ctx.Users.Single(a => a.Login   == user.Login && a.Password == user.Password);
            _ctx.Users.Remove(userDel);
            _ctx.SaveChanges();
        }

        public List<Site> GetAllSites()
        {
            return _ctx.Sites.ToList();
        }

        public List<Account> GetAllAccounts()
        {
            return _ctx.Accounts.ToList();
        }

        public void AddAccount(Account account)
        {
            _ctx.Accounts.Add(account);
            _ctx.SaveChanges();
        }

        public void AddSite (Site site)
        {
            _ctx.Sites.Add(site);
            _ctx.SaveChanges();
        }

        public void DeleteAccount(Account account)
        {
            var accountDel = _ctx.Accounts.Single(a => a.Login == account.Login && a.Password == account.Password);
            _ctx.Accounts.Remove(accountDel);
            _ctx.SaveChanges();
        }

        public void DeleteSite(Site site)
        {
            var siteDel = _ctx.Sites.Single(a => a.Name == site.Name && a.Description == site.Description);
            _ctx.Sites.Remove(siteDel);
            _ctx.SaveChanges();
        }

    }
}
