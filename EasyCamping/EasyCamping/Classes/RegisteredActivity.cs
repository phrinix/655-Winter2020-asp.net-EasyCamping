//Shahdib Hasan(Part C)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace EasyCamping
{
    public class RegisteredActivity
    {

        public int ActivityId { get; private set; }
        public string ActivityName { get; private set; }
        public int CampDay { get; private set; }

        public RegisteredActivity(int activityid, string activityname, int campday)
        {
            this.ActivityId = activityid;
            this.ActivityName = activityname;
            this.CampDay = campday;
                        
        }

    }
}