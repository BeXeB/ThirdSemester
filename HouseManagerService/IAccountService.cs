using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagerService
{
    [ServiceContract]
    interface IAccountService
    {
        [OperationContract]
        Person GetAccountIfromation(string sessionid);
        [OperationContract]
        bool SetChanges(Person account, string sessionid);
        [OperationContract]
        bool ChangePassword(string oldpassword, string newpassword, string sessionid);
        [OperationContract]
        bool DeleteAccount(string sessionid);
    }
}
