using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment11
{
    public partial class Article2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection("server=DESKTOP-FG5F3C3; database= Assignment11Db; trusted_connection=true;");
                SqlCommand cmd = new SqlCommand("select * from Article", sqlConnection);
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                Gview.DataSource = ds;
                Gview.DataBind();
                LblMsg.Text = "Total Article Records:" + ds.Tables[0].Rows.Count;
            }
            catch (Exception ex)
            {
                LblMsg.Text += ex.Message;
            }


        }

      
    }
}