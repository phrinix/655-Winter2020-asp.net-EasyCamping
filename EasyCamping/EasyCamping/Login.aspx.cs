//Shahdib Hasan(Part C)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyCamping
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    CamperDAO camperDAO = new CamperDAO(txtUserName.Text.ToUpper(), txtPassword.Text);
                    Camper camperInfo = camperDAO.ValidateCamper();

                    if (camperInfo != null)
                    {
                        Session.Add("login", camperInfo);
                        Response.Redirect("~/CamperActivities.aspx");
                    }
                    else lblInvalid.Visible = true;
                }
                catch (Exception)
                {
                    lblInvalid.Visible = true;
                }
            }
        }
    }
}