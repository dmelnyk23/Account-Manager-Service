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
        string[] GetAllSites(string login);


        [OperationContract]
        void DeleteUser(User user);

        [OperationContract]
        Account[] GetAllAccounts();

        [OperationContract]
        void AddAccount(Account account);

        [OperationContract]
        void AddSite(Site site);

        [OperationContract]
        void DeleteAccount(Account account);

        [OperationContract]
        void DeleteSite(Site site);
    }

}
