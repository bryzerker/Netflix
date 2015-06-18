using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Netflix
{
    public partial class profiel : System.Web.UI.Page
    {
        private Administration ad = new Administration();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (string s in ad.Profiles((string)(Session["LoggedIn"])))
                {
                    lbProfiles.Items.Add(s);
                }
            }
            
        }

        protected void lbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Profile"] = lbProfiles.SelectedValue;
            Response.Redirect("~/lijst");
            //lblCategorie.Text = ad.profileCat((string) (Session["LoggedIn"]), lbProfiles.SelectedValue);
        }

        protected void btnProfiel_Click(object sender, EventArgs e)
        {
            
        }
    }
}