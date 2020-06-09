using HouseManagerServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagerService
{
    class HouseService : IHouseService
    {
        private static readonly IDBHouse dBHouse = new DBHouse();
        private static readonly IDBPersonToHouse dBPersonToHouse = new DBPersonToHouse();
        private static readonly IDBAddress dBAddress = new DBAddress();
        private static readonly IDBSession dBSession = new DBSession();
        private static readonly IDBChore dBChore = new DBChore();
        private static readonly IDBChatMessage dBChatMessage = new DBChatMessage();
        public bool CreateHouse(House house, string sessionid)
        {
            int addressid = -1;
            try
            {
                addressid = dBAddress.CreateAddress(new HouseManagerServer.Address { ZipCode = house.Address.ZipCode, City = house.Address.City, Street = house.Address.Street, HouseNo = house.Address.HouseNo, FloorNo = house.Address.FloorNo, DoorNo = house.Address.DoorNo });
                HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
                string invitecode = (house.Name + DateTime.Now + person.UserName).Replace(" ", string.Empty);
                int houseid = dBHouse.InsertHouse(new HouseManagerServer.House { Address = new HouseManagerServer.Address { Id = addressid }, Name = house.Name, InviteCode = invitecode });
                dBPersonToHouse.JoinHouse(new HouseManagerServer.PersonToHouse { IsOwner = true, Person = person }, houseid);
                return true;
            }
            catch (Exception)
            {

                throw new Exception(addressid.ToString());
            }
        }

        public bool DeleteHouse(House house, string sessionid)
        {
            HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
            HouseManagerServer.PersonToHouse personToHouse = dBPersonToHouse.GetPersonToHouseByBothId(person.Id, house.Id);
            HouseManagerServer.House serverhouse = dBHouse.GetHouseById(house.Id);
            if (personToHouse.IsOwner)
            {
                dBChore.DeleteChoreByHouseId(serverhouse.Id);
                dBPersonToHouse.DeletePersonToHouseByHouseId(serverhouse.Id);
                dBAddress.DeleteAddress(serverhouse.Address);
                dBChatMessage.DeleteChatMessageByHouseId(serverhouse.Id);
                dBHouse.DeleteHouse(serverhouse);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<House> GetAllHouse(string sessionid)
        {
            List<House> list = new List<House>();
            HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
            List<HouseManagerServer.PersonToHouse> houses = dBPersonToHouse.GetAllHouseForPerson(person.Id);
            foreach (var item in houses)
            {
                HouseManagerServer.House house = dBHouse.GetHouseById(item.HouseId);
                house.Address = dBAddress.GetAddressById(house.Address.Id);
                List<PersonToHouse> people = new List<PersonToHouse>();
                foreach (var personToHouse in dBPersonToHouse.GetAllPersonInHouse(house.Id))
                {
                    people.Add(new PersonToHouse { MoveInDate = personToHouse.MoveInDate, IsOwner = personToHouse.IsOwner, Person = new Person { UserName = personToHouse.Person.UserName, DateOfBirth = personToHouse.Person.DateOfBirth, Email = personToHouse.Person.Email, FirstName = personToHouse.Person.FirstName, LastName = personToHouse.Person.LastName, Phone = personToHouse.Person.LastName } });
                }
                list.Add(new House { People = people, Id = house.Id, InviteCode = house.InviteCode, Name = house.Name, Address = new Address { Id = house.Address.Id, City = house.Address.City, DoorNo = house.Address.DoorNo, FloorNo = house.Address.FloorNo, HouseNo = house.Address.HouseNo, Street = house.Address.Street, ZipCode = house.Address.ZipCode } });
            }
            return list;
        }

        public bool JoinHouse(string invitecode, string sessionid)
        {
            HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
            HouseManagerServer.House house = dBHouse.GetHouseByInvitecode(invitecode);
            HouseManagerServer.PersonToHouse personToHouse = dBPersonToHouse.GetPersonToHouseByBothIdMovedOut(person.Id, house.Id);
            if (personToHouse != null)
            {
                return dBPersonToHouse.Update(new HouseManagerServer.PersonToHouse { Person = person }, house.Id);
            }
            return dBPersonToHouse.JoinHouse(new HouseManagerServer.PersonToHouse { IsOwner = false, Person = person }, house.Id);
        }

        public bool LeaveHouse(House house, string sessionid)
        {
            HouseManagerServer.Person person = dBSession.GetSessionBySessionID(sessionid).Person;
            return dBPersonToHouse.LeaveHouse(new HouseManagerServer.PersonToHouse { Person = person }, house.Id);
        }

        public bool UpdateHouse(House house, string sessionid)
        {
            bool a = dBAddress.UpdateAddress(new HouseManagerServer.Address { City = house.Address.City, DoorNo = house.Address.DoorNo, FloorNo = house.Address.FloorNo, HouseNo = house.Address.HouseNo, Id = house.Address.Id, Street = house.Address.Street, ZipCode = house.Address.ZipCode });
            bool b = dBHouse.UpdateHouse(new HouseManagerServer.House { Name = house.Name, Id = house.Id });
            return a && b;
        }
    }
}
