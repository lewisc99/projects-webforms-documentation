using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace masterPage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender,EventArgs e)
        {
            Page.Title = string.Format("Default Page {0:d}",DateTime.Now);
        }
    }
}