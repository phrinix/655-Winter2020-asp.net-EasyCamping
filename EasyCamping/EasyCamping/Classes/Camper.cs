//Shahdib Hasan(Part C)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyCamping
{
    public class Camper
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        

        public Camper(string userName, string password, string firstName, string lastName)
        {
            this.UserName = userName;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            
        }
    }


}