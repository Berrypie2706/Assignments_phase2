using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment11
{
    public partial class AddArcticle_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LblMsg.Visible = false;
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            LblMsg.Visible = true;
            try
            {

                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Assignment11DbConnectionString"].ToString());
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection;
                cmd.CommandText = "insert into Article values(@id, @title, @content, @date)";
                cmd.Parameters.AddWithValue("id", int.Parse(TxtId.Text));
                cmd.Parameters.AddWithValue("title", TxtTitle.Text);
                cmd.Parameters.AddWithValue("content", TxtContent.Text);
                cmd.Parameters.AddWithValue("date", DateTime.Parse(TxtDate.Text));
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                LblMsg.Text = "Article was added successfully!!!";


            }
            catch (Exception ex)
            {
                LblMsg.Text = ex.Message;
            }
        }
    }
}