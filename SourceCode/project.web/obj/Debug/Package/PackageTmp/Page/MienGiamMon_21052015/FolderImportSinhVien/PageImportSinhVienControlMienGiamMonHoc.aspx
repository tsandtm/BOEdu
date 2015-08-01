<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageImportSinhVienControlMienGiamMonHoc.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderImportSinhVien.PageImportSinhVienControlMienGiamMonHoc" %>

<%@ Register Src="ImportSinhVienControlMienGiamMonHoc.ascx" TagName="ImportSinhVienControlMienGiamMonHoc"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Import sinh viên
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="../FolderSinhVienTimKiemMonHoc/PageQuanLyXemMonHocMienGiamTheoSinhVien.aspx">
        Quản lý sinh viên miễn môn</a></li>
    <li class="active">Import sinh viên</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ImportSinhVienControlMienGiamMonHoc ID="ImportSinhVienControlMienGiamMonHoc1"
        runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
