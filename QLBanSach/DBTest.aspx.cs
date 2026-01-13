using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace QLBanSach
{
    public partial class DBTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblCurrentConn.Text = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;
            }
        }

        protected void btnTest1_Click(object sender, EventArgs e)
        {
            TestConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=BanSachDB;Integrated Security=False;User Id=sa;Password=sa;");
        }

        protected void btnTest2_Click(object sender, EventArgs e)
        {
            TestConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=BanSachDB;Integrated Security=False;User Id=sa;Password=sa;");
        }

        protected void btnTest3_Click(object sender, EventArgs e)
        {
            TestConnection("Data Source=(local)\\SQLEXPRESS;Initial Catalog=BanSachDB;Integrated Security=False;User Id=sa;Password=sa;");
        }

        protected void btnTest4_Click(object sender, EventArgs e)
        {
            TestConnection("Data Source=localhost;Initial Catalog=BanSachDB;Integrated Security=False;User Id=sa;Password=sa;");
        }

        protected void btnTest5_Click(object sender, EventArgs e)
        {
            TestConnection("Data Source=LAPTOP-TNRJQCBE\\SQL;Initial Catalog=BanSachDB;Integrated Security=False;User Id=sa;Password=sa;");
        }

        private void TestConnection(string connectionString)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    lblResult.Text = "✅ SUCCESS: Connection successful!\n\nConnection string: " + connectionString;
                    lblResult.CssClass = "alert alert-success d-block";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "❌ FAILED: " + ex.Message + "\n\nConnection string: " + connectionString;
                lblResult.CssClass = "alert alert-danger d-block";
            }
        }
    }
}
