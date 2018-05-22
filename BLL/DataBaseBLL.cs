﻿using BLL.DTO_s;
using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class DataBaseBLL
    {
        private DatabaseDAL _dal = new DatabaseDAL();

        public UserDTO CheckUser(string login, string password)
        {
            var user = _dal.CheckUser(login, password);
            if (_dal.CheckUser(login, password) == null)
            {
                return null;
            }
            UserDTO userDAL = new UserDTO
            {
                Login = login,
                Password = password,
            };
            return userDAL;
        }

        public UserDTO CheckUserLogin(string login)
        {
            var user = _dal.CheckUserLogin(login);
            if (_dal.CheckUserLogin(login) == null)
            {
                return null;
            }
            UserDTO userDAL = new UserDTO
            {
                Login = login
            };
            return userDAL;
        }

        public void AddUser(string login, string password)
        {
            User userDAL = new User
            {
                Login = login,
                Password = password,
            };
            _dal.AddUser(userDAL);
        }


        public void DeleteUser(UserDTO user)
        {
            User userDAL = new User
            {
                Login = user.Login,
                Password = user.Password,
                //Sites = item.Sites
                //.Select(a => new Site
                //{
                //    ID = a.ID,
                //    Name = a.Name,
                //    Description = a.Description
                //}).ToList()
            };
            _dal.DeleteUser(userDAL);
        }

        public List<SiteDTO> GetAllSites()
        {
            var siteDAL = _dal.GetAllSites();
            List<SiteDTO> sitesDTOs = new List<SiteDTO>();
            foreach (var item in siteDAL)
            {
                SiteDTO temp = new SiteDTO
                {
                    ID = item.ID,
                    Name = item.Name,
                    Description = item.Description,
                    Reference = item.Reference,
                    Accounts = item.Accounts
                    .Select(a => new AccountDTO
                    {
                        ID = a.ID,
                        Login = a.Login,
                        Password = a.Password
                    }).ToList()
                };
                sitesDTOs.Add(temp);
            }
            return sitesDTOs;
        }

        public List<AccountDTO> GetAllAccounts()
        {
            var accountDAL = _dal.GetAllAccounts();
            List<AccountDTO> accountsDTOs = new List<AccountDTO>();
            foreach (var item in accountDAL)
            {
                AccountDTO temp = new AccountDTO
                {
                    ID = item.ID,
                    Login = item.Login,
                    Password = item.Password,
                };
                accountsDTOs.Add(temp);
            }
            return accountsDTOs;
        }

        public void AddAccount(AccountDTO account)
        {
            Account accountDAL = new Account
            {
                Login = account.Login,
                Password = account.Password,
            };
            _dal.AddAccount(accountDAL);
        }

        public void AddSite(SiteDTO site)
        {
            Site siteDAL = new Site
            {
                Name = site.Name,
                Description = site.Description,
                Reference = site.Reference,
                Accounts = site.Accounts
                    .Select(a => new Account
                    {
                        ID = a.ID,
                        Login = a.Login,
                        Password = a.Password
                    }).ToList()
            };
            _dal.AddSite(siteDAL);
        }

        public void DeleteAccount(AccountDTO account)
        {
            Account accountDAL = new Account
            {
                Login = account.Login,
                Password = account.Password,
            };
            _dal.DeleteAccount(accountDAL);
        }

        public void DeleteSite(SiteDTO site)
        {
            Site siteDAL = new Site
            {
                Name = site.Name,
                Description = site.Description,
                Reference = site.Reference,
                Accounts = site.Accounts
                    .Select(a => new Account
                    {
                        ID = a.ID,
                        Login = a.Login,
                        Password = a.Password
                    }).ToList()
            };
            _dal.DeleteSite(siteDAL);
        }
    }
}
