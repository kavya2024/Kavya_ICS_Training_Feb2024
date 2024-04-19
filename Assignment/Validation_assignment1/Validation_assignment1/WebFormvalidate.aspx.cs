using System;
using System.Web.UI;

namespace Validation_assignment1
{
    public partial class WebFormvalidate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Response.Redirect("Welcome.html");
            }
        }
    }
}