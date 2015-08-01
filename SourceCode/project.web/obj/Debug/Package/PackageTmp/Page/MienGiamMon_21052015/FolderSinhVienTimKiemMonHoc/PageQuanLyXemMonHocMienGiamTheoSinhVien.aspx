<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageQuanLyXemMonHocMienGiamTheoSinhVien.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderSinhVienTimKiemMonHoc.PageQuanLyXemMonHocMienGiamTheoSinhVien" %>

<%@ Register Src="ChiTietMonHocMienGiamSinhVienTheoSinhVien.ascx" TagName="ChiTietMonHocMienGiamSinhVienTheoSinhVien"
    TagPrefix="uc1" %>
<%@ Register Src="ListSinhVienXemThongTinMonHocMienGiam.ascx" TagName="ListSinhVienXemThongTinMonHocMienGiam"
    TagPrefix="uc2" %>
<%@ Register Src="KhoaDuLieuSinhVien.ascx" TagName="KhoaDuLieuSinhVien" TagPrefix="uc3" %>
<%@ Register Src="EditSinhVienMienGiamMonHoc.ascx" TagName="EditSinhVienMienGiamMonHoc"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Quản lý sinh viên miễn môn
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li class="active">Quản lý sinh viên miễn môn</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc2:ListSinhVienXemThongTinMonHocMienGiam ID="ListSinhVienXemThongTinMonHocMienGiam1"
        runat="server" />
    <uc1:ChiTietMonHocMienGiamSinhVienTheoSinhVien ID="ChiTietMonHocMienGiamSinhVienTheoSinhVien1"
        runat="server" />
    <uc3:KhoaDuLieuSinhVien ID="KhoaDuLieuSinhVien1" runat="server" />
    <uc4:EditSinhVienMienGiamMonHoc ID="EditSinhVienMienGiamMonHoc1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
