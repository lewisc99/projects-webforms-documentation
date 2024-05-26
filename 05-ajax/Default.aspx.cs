using System;
using System.Web.UI;

namespace ajax
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender,EventArgs e)
        {

        }
        protected void Button1_Click(object sender,EventArgs e)
        {
            Label1.Text = "You clicked the button!";
        }
    }
}