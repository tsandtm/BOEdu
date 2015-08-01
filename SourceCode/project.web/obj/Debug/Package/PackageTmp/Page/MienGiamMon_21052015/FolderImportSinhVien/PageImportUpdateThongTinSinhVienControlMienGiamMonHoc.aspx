<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageImportUpdateThongTinSinhVienControlMienGiamMonHoc.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderImportSinhVien.PageImportUpdateThongTinSinhVienControlMienGiamMonHoc" %>

<%@ Register Src="ImportUpdateThongTinSinhVienControlMienGiamMonHoc.ascx" TagName="ImportUpdateThongTinSinhVienControlMienGiamMonHoc"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Cập nhật thông tin sinh viên
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="../FolderSinhVienTimKiemMonHoc/PageQuanLyXemMonHocMienGiamTheoSinhVien.aspx">
        Quản lý sinh viên miễn môn</a></li>
    <li class="active">Cập nhật thông tin sinh viên</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ImportUpdateThongTinSinhVienControlMienGiamMonHoc ID="ImportUpdateThongTinSinhVienControlMienGiamMonHoc1"
        runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
