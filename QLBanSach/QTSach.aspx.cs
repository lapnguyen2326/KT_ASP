using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QLBanSach
{
    public partial class QTSach : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadSach();
                }
                catch (Exception ex)
                {
                    lblThongBao.Text = "Lỗi kết nối database: " + ex.Message;
                    lblThongBao.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadSach(string searchKeyword = "")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaSach, TenSach, DonGia, KhuyenMai, Hinh FROM Sach";
                
                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    query += " WHERE TenSach LIKE @TenSach";
                }
                
                query += " ORDER BY NgayCapNhat DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(searchKeyword))
                    {
                        cmd.Parameters.AddWithValue("@TenSach", "%" + searchKeyword + "%");
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count == 0 && !string.IsNullOrEmpty(searchKeyword))
                        {
                            lblThongBao.Text = "Tìm kiếm không có kết quả nào";
                            gvSach.DataSource = null;
                            gvSach.DataBind();
                        }
                        else
                        {
                            lblThongBao.Text = "";
                            gvSach.DataSource = dt;
                            gvSach.DataBind();
                        }
                    }
                }
            }
        }

        protected void btTraCuu_Click(object sender, EventArgs e)
        {
            LoadSach(txtTen.Text.Trim());
        }

        protected void gvSach_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSach.PageIndex = e.NewPageIndex;
            LoadSach(txtTen.Text.Trim());
        }

        protected void gvSach_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSach.EditIndex = e.NewEditIndex;
            LoadSach(txtTen.Text.Trim());
        }

        protected void gvSach_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSach.EditIndex = -1;
            LoadSach(txtTen.Text.Trim());
        }

        protected void gvSach_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int maSach = Convert.ToInt32(gvSach.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvSach.Rows[e.RowIndex];

            TextBox txtTenSach = (TextBox)row.FindControl("txtTenSach");
            TextBox txtDonGia = (TextBox)row.FindControl("txtDonGia");
            CheckBox chkKhuyenMai = (CheckBox)row.FindControl("chkKhuyenMai");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Sach SET TenSach = @TenSach, DonGia = @DonGia, KhuyenMai = @KhuyenMai WHERE MaSach = @MaSach";
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSach", txtTenSach.Text);
                    cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(txtDonGia.Text));
                    cmd.Parameters.AddWithValue("@KhuyenMai", chkKhuyenMai.Checked);
                    cmd.Parameters.AddWithValue("@MaSach", maSach);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            gvSach.EditIndex = -1;
            LoadSach(txtTen.Text.Trim());
        }

        protected void gvSach_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int maSach = Convert.ToInt32(gvSach.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Sach WHERE MaSach = @MaSach";
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSach", maSach);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LoadSach(txtTen.Text.Trim());
        }

        protected void gvSach_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Set data keys for edit/delete operations
                if (e.Row.RowIndex != -1)
                {
                    DataKey dataKey = gvSach.DataKeys[e.Row.RowIndex];
                    if (dataKey != null)
                    {
                        // DataKey is automatically set by GridView
                    }
                }
            }
        }
    }
}