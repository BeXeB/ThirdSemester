using System;
using System.Collections.Generic;
using System.Text;

namespace HouseManagerServer
{
    public interface IDBAddress
    {
        int CreateAddress(Address address);
        Address GetAddressById(int id);
        bool UpdateAddress(Address address);
        bool DeleteAddress(Address address);
    }
}