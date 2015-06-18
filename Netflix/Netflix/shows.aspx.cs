using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Netflix
{
    public partial class shows : System.Web.UI.Page
    {
        private Administration ad = new Administration();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string s in ad.Shows())
            {
                lbShows.Items.Add(s);
            }
        }

        protected void lbShows_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbShowInfo.Text = ad.ShowInfo(lbShows.SelectedValue);
        }
    }
}