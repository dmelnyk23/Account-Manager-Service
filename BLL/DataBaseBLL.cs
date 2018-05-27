using BLL.DTO_s;
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

        public UserDTO GetUserByLogin(string login)
        {
            var userDAL = _dal.GetUserByLogin(login);
            UserDTO userDTO = new UserDTO
            {
                Login = userDAL.Login,
                Password = userDAL.Password
            };

            return userDTO;

        }
        
        public List<string> GetAllSitesNamesByLogin(string login)
        {
            var siteDAL = _dal.GetAllSitesByLogin(login);
            List<string> sitesNames = new List<string>();
            foreach (var item in siteDAL)
            {
                sitesNames.Add(item.Name);
            }
            return sitesNames;
        }

        public List<string> GetAllSitesReferencesByLogin(string login)
        {
            var siteDAL = _dal.GetAllSitesByLogin(login);
            List<string> sitesReferences = new List<string>();
            foreach (var item in siteDAL)
            {
                sitesReferences.Add(item.Reference);
            }
            return sitesReferences;
        }

        public void AddSite(string userLogin, string name, string reference, string description,
                                      string login, string password, bool addAcc)
        {
            var user = _dal.GetUserByLogin(userLogin);
            if (addAcc == true)
            {
                Account acc = new Account()
                {
                    Login = login,
                    Password = password
                };
                List<Account> listAcc = new List<Account>() { acc };
                Site siteDal = new Site()
                {
                    Name = name,
                    Reference = reference,
                    Description = description,
                    Accounts = listAcc,
                    User = user

                };
                _dal.AddSite(siteDal);
            }
            else
            {
                Site siteDal = new Site()
                {
                    Name = name,
                    Reference = reference,
                    Description = description,
                    User = user
                };
                _dal.AddSite(siteDal);
            }
        }

        public void AddAccount(string siteName, string accountLogin, string accountPassword)
        {
            var siteDAL = _dal.GetSiteByName(siteName);
            Account accountDAL = new Account
            {
                Login = accountLogin,
                Password = accountPassword,
                Site = siteDAL

            };
            _dal.AddAccount(accountDAL);
        }

        public void DeleteSite(string siteName)
        {

            var site = _dal.GetSiteByName(siteName);
            var accounts = _dal.GetAccountBySiteID(site.ID);
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

            foreach (var item in accounts)
            {
                _dal.DeleteAccount(item);
            }

            _dal.DeleteSite(siteDAL);
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




    }
}
