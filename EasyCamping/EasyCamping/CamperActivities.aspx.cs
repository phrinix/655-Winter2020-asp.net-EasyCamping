/*
 * Part B
 * Created by: Yashkumar patel
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyCamping
{
    public partial class CamperActivities : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NotRegisteredLBL.Visible = false;
            Camper camperinfo = (Camper)(Session["login"]);
            CamperNameLBL.Text = camperinfo.FirstName + " " + camperinfo.LastName;      
            
            ActivityDAO activityInfo = new ActivityDAO(camperinfo.UserName, camperinfo.Password);
            lblRegActivities.Text = activityInfo.GetNumberOfActivities().ToString();
            if (!IsPostBack)
                GetNumberOfActivities();

        }

        protected void LogOutBTN_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/CamperActivities.aspx");
        }

        private void GetNumberOfActivities()
        {
            Camper login = (Camper)Session["login"];
            RegisterDAO registerDAO = new RegisterDAO(login.UserName, login.Password);

            List<RegisteredActivity> registerActivity = new List<RegisteredActivity>();
           registerActivity = registerDAO.GetRegisteredActivities();

            if (!registerActivity.Any())
           {
                NotRegisteredLBL.Visible = true;
            }
            GridView1.DataSource = registerDAO.GetRegisteredActivities();
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Camper login = (Camper)Session["login"];
            CamperDAO activity = new CamperDAO(login.UserName, login.Password);
            int index = Convert.ToInt32(e.CommandArgument);
            int ActivityID = Convert.ToInt32(GridView1.Rows[index].Cells[0].Text);

            if (e.CommandName == "DELETE")
           {
                try
                {
                    activity.UnregisterActivity(ActivityID);
                    GetNumberOfActivities();
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void RegActivityBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RegisterActivity.aspx");
        }
    }
}