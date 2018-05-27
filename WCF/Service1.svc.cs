using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BLL;
using BLL.DTO_s;
using WCF.DataContracts;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private DataBaseBLL _bll = new DataBaseBLL();

        public User CheckUser(string login, string password)
        {
            var user = _bll.CheckUser(login, password);
            if(user == null)
            {
                return null;
            }
            User userDC = new User
            {
                Login = login,
                Password = password,
            };
            return userDC;
        }

        public User CheckUserLogin(string login)
        {
            var user = _bll.CheckUserLogin(login);
            if (user == null)
            {
                return null;
            }
            User userDC = new User
            {
                Login = login,
            };
            return userDC;
        }

        public User GetUserByLogin(string login)
        {
            var userDAL = _bll.GetUserByLogin(login);
            User user = new User
            {
                Login = userDAL.Login,
                Password = userDAL.Password
            };

            return user;
        }

        public string[] GetAllSitesNamesByLogin(string login)
        {
            return _bll.GetAllSitesNamesByLogin(login).ToArray();
        }

        public string[] GetAllSitesReferencesByLogin(string login)
        {
            return _bll.GetAllSitesReferencesByLogin(login).ToArray();
        }

        public void AddSite(string userLogin, string name, string reference, string description,
                                      string login, string password, bool addAcc)
        {
            _bll.AddSite(userLogin, name, reference, description, login, password, addAcc);
        }

        public void AddAccount(string siteName, string accountLogin, string accountPassword)
        {
            _bll.AddAccount(siteName, accountLogin, accountPassword);
        }

        public void DeleteSite(string siteName)
        {
            _bll.DeleteSite(siteName);
        }






        public void AddUser(string login, string password)
        {
            UserDTO userDTO = new UserDTO
            {
                Login = login,
                Password = password,
            };
            _bll.AddUser(login, password);
        }

        public void DeleteUser(User user)
        {
            UserDTO userDTO = new UserDTO
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
            _bll.DeleteUser(userDTO);
        }




        public Account[] GetAllAccounts()
        {
            var accountBLL = _bll.GetAllAccounts();
            List<Account> accountsDC = new List<Account>();
            foreach (var item in accountBLL)
            {
                Account temp = new Account
                {
                    Login = item.Login,
                    Password = item.Password,
                };
                accountsDC.Add(temp);
            }
            return accountsDC.ToArray();
        }

        

        public void DeleteAccount(Account account)
        {
            AccountDTO accountDTO = new AccountDTO
            {
                Login = account.Login,
                Password = account.Password,
            };
         //   _bll.DeleteAccount(accountDTO);
        }

    }
}
