using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment15
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LblMsg.Visible = false;
            }
        }

     

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            LblMsg.Visible = true;
            try
            {
                int id = int.Parse(TxtID.Text);
                string name = TxtName.Text;
                string pwd = TxtPwd.Text;
                if(id == 0 )
                {
                    throw new Exception("ID cant be zero or null");
                }
                else if(name =="Aniket" && pwd=="123@anik")
                {
                    LblMsg.Text = "Login Success!!!";
                }
            }
            catch(Exception ex)
            {
                Session["error"] = ex.Message;
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Global.asax");
        }
    }
}