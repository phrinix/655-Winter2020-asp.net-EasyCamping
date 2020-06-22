/*
 * Part B
 * Created by: Yashkumar patel
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace EasyCamping
{
    public class CamperDAO
    {
        private string UserName { get; set; }
        private string Password { get; set; }

        public CamperDAO(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }


        public Camper ValidateCamper()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT FIRST_NAME, LAST_NAME FROM CAMPER WHERE USERNAME = :username", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue(":username", UserName);

            da.Fill(dt);

           if (dt.Rows.Count > 0) // if camper found
            {
                string firstName = Convert.ToString(dt.Rows[0]["FIRST_NAME"]);
                string lastName = Convert.ToString(dt.Rows[0]["LAST_NAME"]);

                return new Camper(UserName, Password, firstName, lastName);
            }

            else
            {
                return null;
            }
        }


        public void UnregisterActivity(int ActivityID)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("DELETE FROM REGISTER WHERE ACTIVITY_ID = :activityID", conn);

            cmd.Parameters.AddWithValue(":activityID", ActivityID);

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}