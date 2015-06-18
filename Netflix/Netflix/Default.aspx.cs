using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Netflix
{
    public partial class _Default : Page
    {
        private Administration ad = new Administration();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                tbEmail.Visible = false;
                tbPassword.Visible = false;
                lblLogin.Text = "Je bent al ingelogd!";
                lblEmail.Visible = false;
                lblPassword.Visible = false;
                btnLogin.Visible = false;
                btnLogout.Visible = true;
            }
            else
            {
                tbEmail.Visible = true;
                tbPassword.Visible = true;
                lblLogin.Text = "Login";
                lblEmail.Visible = true;
                lblPassword.Visible = true;
                btnLogin.Visible = true;
                btnLogout.Visible = false;

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (ad.login(tbEmail.Text, tbPassword.Text))
            {
                Session["LoggedIn"] = tbEmail.Text;
                Response.Redirect("~/profiel");
            }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["LoggedIn"] = null;
            Session["Profile"] = null;
            Response.Redirect("~/default");
        }
    }
}