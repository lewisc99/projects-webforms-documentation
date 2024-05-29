using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace masterPage
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender,EventArgs e)
        {
            DateDisplay.Text = DateTime.Now.ToString("dddd, MMMM dd");
        }
    }
}