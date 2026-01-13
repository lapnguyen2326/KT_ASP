<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ThemSach.aspx.cs" Inherits="QLBanSach.ThemSach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="NoiDung" runat="server">
    <h2>THÊM SÁCH MỚI</h2>
    <hr />
    <div class="w-100">
        <asp:ValidationSummary ID="vsSummary" runat="server" CssClass="alert alert-danger" HeaderText="Vui lòng sửa các lỗi sau:" />

        <div class="form-group">
            <label class="font-weight-bold">Tên sách</label>
            <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTen" runat="server" ControlToValidate="txtTen" 
                ErrorMessage="Tên sách không được để trống" CssClass="text-danger" Display="Dynamic">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label class="font-weight-bold">Đơn giá</label>
            <asp:TextBox ID="txtDonGia" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDonGia" runat="server" ControlToValidate="txtDonGia" 
                ErrorMessage="Đơn giá không được để trống" CssClass="text-danger" Display="Dynamic">*</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rvDonGia" runat="server" ControlToValidate="txtDonGia" 
                MinimumValue="1" MaximumValue="999999999" Type="Double" 
                ErrorMessage="Đơn giá phải là số lớn hơn 0" CssClass="text-danger" Display="Dynamic">*</asp:RangeValidator>
        </div>
        <div class="form-group">
            <label class="font-weight-bold">Chủ đề</label>
            <asp:DropDownList ID="ddlChuDe" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label class="font-weight-bold">Ảnh bìa sách</label>
            <asp:FileUpload ID="FHinh" runat="server" CssClass="form-control-file" />
            <asp:RequiredFieldValidator ID="rfvHinh" runat="server" ControlToValidate="FHinh" 
                ErrorMessage="Ảnh bìa không được để trống" CssClass="text-danger" Display="Dynamic">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label class="font-weight-bold">Khuyến mãi</label>
            <asp:CheckBox ID="chkKhuyenMai" runat="server" Checked="true" CssClass="form-check" />
        </div>
        <asp:Button ID="btXuLy" runat="server" Text="Lưu" CssClass="btn btn-success" OnClick="btXuLy_Click" />
        
        <asp:Label ID="lblThongBao" runat="server" CssClass="alert alert-success mt-3 d-block" Visible="false"></asp:Label>

    </div>
    <br />
</asp:Content>
