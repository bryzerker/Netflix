using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Netflix
{
    public partial class lijst : System.Web.UI.Page
    {
        private Administration ad = new Administration();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (string s in ad.ProfileShows((string)(Session["LoggedIn"]), (string)(Session["Profile"])))
                {
                    lbListShows.Items.Add(s);
                }
            }
            
        }

        protected void lbListShows_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbShowInfo.Text = ad.ShowInfo(lbListShows.SelectedValue);
        }
    }
}