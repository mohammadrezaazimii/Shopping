using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Shopping.UIL.User
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if(txtname.Text=="user" && txtpassword.Text == "user")
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("code");
                dt.Columns.Add("name");
                dt.Columns.Add("price");
                dt.Columns.Add("quantity");
                dt.Columns.Add("total");
                dt.Columns.Add("image");
                Session["Cart"] = dt;
                Response.Redirect("~/Products/ViewProducts.aspx");
            }
        }
    }
}