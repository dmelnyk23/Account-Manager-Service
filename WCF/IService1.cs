using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using WCF.DataContracts;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        User CheckUser(string login, string password);

        [OperationContract]
        User CheckUserLogin(string login);

        [OperationContract]
        void AddUser(string login, string password);

        [OperationContract]
        User GetUserByLogin(string login);

        [OperationContract]
        string[] GetAllSitesNamesByLogin(string login);

        [OperationContract]
        string[] GetAllSitesReferencesByLogin(string login);

        [OperationContract]
        void AddSite(string userLogin, string name, string reference, string description,
                                      string login, string password, bool addAcc);
        
        [OperationContract]
        void AddAccount(string siteName, string accountLogin, string accountPassword);

        [OperationContract]
        void DeleteSite(string siteName);


        [OperationContract]
        void DeleteUser(User user);

        [OperationContract]
        Account[] GetAllAccounts();



        [OperationContract]
        void DeleteAccount(Account account);

    }

}
