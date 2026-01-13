using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace QLBanSach
{
    public partial class ThemSach : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadChuDe();
                }
                catch (Exception ex)
                {
                    lblThongBao.Text = "Lỗi kết nối database: " + ex.Message;
                    lblThongBao.Visible = true;
                    lblThongBao.CssClass = "alert alert-danger mt-3 d-block";
                }
            }
        }

        private void LoadChuDe()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaCD, TenCD FROM ChuDe ORDER BY TenCD";
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        ddlChuDe.DataSource = dt;
                        ddlChuDe.DataTextField = "TenCD";
                        ddlChuDe.DataValueField = "MaCD";
                        ddlChuDe.DataBind();
                    }
                }
            }
        }

        protected void btXuLy_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Upload file
                    string fileName = Path.GetFileName(FHinh.PostedFile.FileName);
                    string filePath = Server.MapPath("~/Bia_sach/") + fileName;
                    
                    // Ensure directory exists
                    string directory = Server.MapPath("~/Bia_sach/");
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    
                    FHinh.SaveAs(filePath);

                    // Insert into database (let database handle MaSach auto-increment)
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Sach (TenSach, DonGia, MaCD, Hinh, KhuyenMai, NgayCapNhat) " +
                                     "VALUES (@TenSach, @DonGia, @MaCD, @Hinh, @KhuyenMai, @NgayCapNhat)";
                        
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TenSach", txtTen.Text.Trim());
                            cmd.Parameters.AddWithValue("@DonGia", Convert.ToDecimal(txtDonGia.Text));
                            cmd.Parameters.AddWithValue("@MaCD", ddlChuDe.SelectedValue);
                            cmd.Parameters.AddWithValue("@Hinh", fileName);
                            cmd.Parameters.AddWithValue("@KhuyenMai", chkKhuyenMai.Checked);
                            cmd.Parameters.AddWithValue("@NgayCapNhat", DateTime.Now);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    lblThongBao.Text = "Thêm sách thành công!";
                    lblThongBao.Visible = true;
                    lblThongBao.CssClass = "alert alert-success mt-3 d-block";

                    // Clear form
                    ClearForm();
                }
                catch (Exception ex)
                {
                    lblThongBao.Text = "Thêm sách thất bại: " + ex.Message;
                    lblThongBao.Visible = true;
                    lblThongBao.CssClass = "alert alert-danger mt-3 d-block";
                }
            }
        }

        private void ClearForm()
        {
            txtTen.Text = "";
            txtDonGia.Text = "";
            chkKhuyenMai.Checked = false;
            FHinh.Attributes.Clear();
        }
    }
}