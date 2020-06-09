using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagerService
{
    [ServiceContract]
    interface IListService
    {
        [OperationContract]
        int CreateList(MemoList list, string sessionid);
        [OperationContract]
        bool UpdateList(MemoList list, string sessionid);
        [OperationContract]
        List<MemoList> GetAllList(string sessionid);
        [OperationContract]
        bool DeleteList(MemoList list, string sessionid);
    }

    [DataContract]
    public class MemoList 
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Person Person { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
