<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageXetMienTruHocPhan.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderXetMienGiamHocPhan.PageXetMienTruHocPhan" %>

<%@ Register Src="ControlXetMienTruHocPhan.ascx" TagName="ControlXetMienTruHocPhan"
    TagPrefix="uc1" %>
<%@ Register Src="~/Page/MienGiamMon_21052015/FolderSinhVienTimKiemMonHoc/ChiTietMonHocMienGiamSinhVienTheoSinhVien.ascx"
    TagName="ChiTietMonHocMienGiamSinhVienTheoSinhVien" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Xét miễn giảm môn học
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="../FolderSinhVienTimKiemMonHoc/PageQuanLyXemMonHocMienGiamTheoSinhVien.aspx">
        Quản lý sinh viên miễn môn</a></li>
    <li class="active">Xét miễn giảm môn học</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ControlXetMienTruHocPhan ID="ControlXetMienTruHocPhan1" runat="server" />
    <uc2:ChiTietMonHocMienGiamSinhVienTheoSinhVien ID="ChiTietMonHocMienGiamSinhVienTheoSinhVien1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
