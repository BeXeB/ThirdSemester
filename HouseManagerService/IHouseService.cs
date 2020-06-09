using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using HouseManagerServer;

namespace HouseManagerService
{
    [ServiceContract]
    interface IHouseService
    {
        [OperationContract]
        bool CreateHouse(House house, string sessionid);
        [OperationContract]
        bool UpdateHouse(House house, string sessionid);
        [OperationContract]
        List<House> GetAllHouse(string sessionid);
        [OperationContract]
        bool DeleteHouse(House house, string sessionid);
        [OperationContract]
        bool JoinHouse(string invitecode, string sessionid);
        [OperationContract]
        bool LeaveHouse(House house, string sessionid);
    }

    [DataContract]
    public class House
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Address Address { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string InviteCode { get; set; }
        [DataMember]
        public List<PersonToHouse> People { get; set; }
        [DataMember]
        public List<ChatMessage> Chat { get; set; }
        [DataMember]
        public List<Chore> Chores { get; set; }
    }

    [DataContract]
    public class Address
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ZipCode { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string HouseNo { get; set; }
        [DataMember]
        public short FloorNo { get; set; }
        [DataMember]
        public string DoorNo { get; set; }
    }

    [DataContract]
    public class PersonToHouse
    {
        [DataMember]
        public Person Person { get; set; }
        [DataMember]
        public DateTime MoveInDate { get; set; }
        [DataMember]
        public DateTime? MoveOutDate { get; set; }
        [DataMember]
        public bool IsOwner { get; set; }
    }
}
