using account.configuration;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace account.account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender,EventArgs e)
        {
            if (!IsPostBack)
            {
                // Clear the error message
                ErrorMessage.Text = string.Empty;
            }
        }
        protected void LoginButton_Click(object sender,EventArgs e)
        {
            var userManager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var result = signInManager.PasswordSignIn(Username.Text,Password.Text,isPersistent: false,shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                Response.Redirect("~/Default.aspx");
                break;
                case SignInStatus.Failure:
                default:
                ErrorMessage.Text = "Invalid login attempt";
                break;
            }
        }
    }
}