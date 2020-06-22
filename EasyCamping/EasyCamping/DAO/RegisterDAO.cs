//Prateek Singh - Part A
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace EasyCamping
{
    public class RegisterDAO
    {
        private string UserName;
        private string Password;
        public RegisterDAO(string Username, string Password)
        {
            this.UserName = Username;
            this.Password = Password;
        }
        public List<RegisteredActivity> GetRegisteredActivities()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT activity_id, name, camp_day FROM register INNER JOIN activity ON activity_id = id WHERE camper_username = :Username", conn);
            cmd.Parameters.AddWithValue("Username", UserName.ToUpper());
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<RegisteredActivity> registeredActivity = new List<RegisteredActivity>();
            da.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                registeredActivity.Add(new RegisteredActivity(Convert.ToInt32(dr["activity_id"]), Convert.ToString(dr["name"]), Convert.ToInt32(dr["camp_day"])));
            }

            return registeredActivity;
 
        }
        public int RegisterActivity(int ActivityId, int CampDay)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("REGISTER_ACTIVITY", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pactivity_id", ActivityId);
            cmd.Parameters.AddWithValue("pcamp_day", CampDay);
            cmd.Parameters.Add("psuccess", OracleType.Int32).Direction = ParameterDirection.Output;
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                return Convert.ToInt32(cmd.Parameters["psuccess"].Value);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}