using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWebApp
{
    public partial class FirstWebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     
        protected void Button1_Clicked(object sender, EventArgs e)
        {
            Label1.Text = TextBox1.Text + ", welcome to Visual Studio!";
        }
    }
}