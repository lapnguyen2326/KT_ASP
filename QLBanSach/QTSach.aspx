<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="QTSach.aspx.cs" Inherits="QLBanSach.QTSach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
     <h2>TRANG QUẢN TRỊ SÁCH</h2>
     <hr />   
     <div class="row mb-2">
         <div class="col-md-6">
              <div class="form-inline">
                   Tựa sách <asp:TextBox ID="txtTen" runat="server" placeholder="Nhập tựa sách cần tìm" CssClass="form-control ml-2" Width="300"></asp:TextBox>
                  <asp:Button ID="btTraCuu" runat="server" Text="Tra cứu" CssClass="btn btn-info ml-2" OnClick="btTraCuu_Click" />                 
              </div>
         </div>
        <div class="col-md-6 text-right">
             <a href="ThemSach.aspx" class="btn btn-success">Thêm sách mới</a>
        </div>
    </div>
    
    <asp:Label ID="lblThongBao" runat="server" CssClass="text-danger" ForeColor="Red"></asp:Label>
    
    <asp:GridView ID="gvSach" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" 
        AllowPaging="True" PageSize="4" OnPageIndexChanging="gvSach_PageIndexChanging" 
        OnRowEditing="gvSach_RowEditing" OnRowUpdating="gvSach_RowUpdating" 
        OnRowCancelingEdit="gvSach_RowCancelingEdit" OnRowDeleting="gvSach_RowDeleting" 
        OnRowDataBound="gvSach_RowDataBound" DataKeyNames="MaSach">
        <Columns>
            <asp:TemplateField HeaderText="Tựa sách">
                <EditItemTemplate>
                    <asp:TextBox ID="txtTenSach" runat="server" Text='<%# Bind("TenSach") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("TenSach") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ảnh bìa">
                <ItemTemplate>
                    <asp:Image ID="imgAnhBia" runat="server" ImageUrl='<%# "~/Bia_sach/" + Eval("Hinh") %>' Width="80px" Height="100px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Đơn giá">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDonGia" runat="server" Text='<%# Bind("DonGia") %>' CssClass="form-control"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("DonGia", "{0:#,##0} VNĐ") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Khuyến mãi">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkKhuyenMai" runat="server" Checked='<%# Bind("KhuyenMai") %>' />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblKhuyenMai" runat="server" Text='<%# Convert.ToBoolean(Eval("KhuyenMai")) ? "x" : "" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Chọn thao tác">
                <EditItemTemplate>
                    <asp:Button ID="btGhi" runat="server" Text="Ghi" CommandName="Update" CssClass="btn btn-sm btn-success" />
                    <asp:Button ID="btKhong" runat="server" Text="Không" CommandName="Cancel" CssClass="btn btn-sm btn-warning" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Button ID="btSua" runat="server" Text="Sửa" CommandName="Edit" CssClass="btn btn-sm btn-primary" />
                    <asp:Button ID="btXoa" runat="server" Text="Xoá" CommandName="Delete" CssClass="btn btn-sm btn-danger" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa sách này?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle CssClass="pagination" />
    </asp:GridView>

</asp:Content>
