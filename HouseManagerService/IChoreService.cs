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
    interface IChoreService
    {
        [OperationContract]
        bool CreateChore(Chore chore, int houseid);
        [OperationContract]
        bool JoinChore(Chore chore, string sessionid);
        [OperationContract]
        bool UpdateStatus(Chore chore, string sessionid);
        [OperationContract]
        List<Chore> GetChoresForHouse(int houseid);
    }

    [DataContract]
    public class Chore
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public byte Status { get; set; }
        [DataMember]
        public Person Person { get; set; }
        [DataMember]
        public DateTime DueDate { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
