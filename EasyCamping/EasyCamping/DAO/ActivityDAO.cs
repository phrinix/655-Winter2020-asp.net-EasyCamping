//Shahdib Hasan(Part C)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace EasyCamping
{
    public class ActivityDAO
    {

        public string UserName { get; private set; }
        public string Password { get; private set; }

        public ActivityDAO(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;

        }
        public int GetNumberOfActivities()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT COUNT(*) as numofactivity FROM register INNER JOIN activity ON activity_id = id WHERE camper_username = :Username", conn);
            cmd.Parameters.AddWithValue("Username", UserName.ToUpper());
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                return Convert.ToInt32(dr["numofactivity"]);
            }
            return 0;
        }

        public List<Activity> GetAvailableActivities(int CampDay)
        {

            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT id, name, capacity FROM activity", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmd = new OracleCommand("IS_AVAILABLE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            List<Activity> activity = new List<Activity>();
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["id"]);
                cmd.Parameters.AddWithValue("pactivity_id", id).Direction = ParameterDirection.Input;
                cmd.Parameters.AddWithValue("pcamp_day", CampDay).Direction = ParameterDirection.Input;
                cmd.Parameters.Add("result", OracleType.Int32).Direction = ParameterDirection.ReturnValue;
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    int result = Convert.ToInt32(cmd.Parameters["result"].Value); // Get the return value
                    if (result == 1)
                    {
                        activity.Add(new Activity(Convert.ToInt32(dr["id"]), Convert.ToString(dr["name"]), Convert.ToInt32(dr["capacity"])));
                    }
                }
                finally
                {
                    conn.Close();
                }

            }
            return activity;
        }



    }
}