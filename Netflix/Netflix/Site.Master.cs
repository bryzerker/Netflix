using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Netflix
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Niet ingelogd
            if (Session["LoggedIn"] == null)
            {
                lblAccount.Visible = false;
                lblProfile.Visible = false;

                var ctrl = FindControlRecursive(this, "liAbout");
                if (ctrl != null)
                {
                    ctrl.Visible = false;
                }
                ctrl = FindControlRecursive(this, "liContact");
                if (ctrl != null)
                {
                    ctrl.Visible = false;
                }
            }
            //Wel ingelogd
            else
            {
                lblAccount.Visible = true;
                lblAccount.Text = "Ingelogd als " + (string)(Session["LoggedIn"]);
                //Nog geen profiel gekozen
                if (Session["Profile"] == null)
                {
                    lblProfile.Visible = false;
                    var ctrl = FindControlRecursive(this, "liAbout");
                    if (ctrl != null)
                    {
                        ctrl.Visible = false;
                    }
                    ctrl = FindControlRecursive(this, "liContact");
                    if (ctrl != null)
                    {
                        ctrl.Visible = false;
                    }
                }
                //Wel een profiel gekozen
                else
                {
                    lblProfile.Text = (string) (Session["Profile"]);
                    var ctrl = FindControlRecursive(this, "liAbout");
                    if (ctrl != null)
                    {
                        ctrl.Visible = true;
                    }
                    ctrl = FindControlRecursive(this, "liContact");
                    if (ctrl != null)
                    {
                        ctrl.Visible = true;
                    }
                }

            }
        }
        private Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn =
                    FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null) return controlToReturn;
            }
            return null;
        }
    }
}