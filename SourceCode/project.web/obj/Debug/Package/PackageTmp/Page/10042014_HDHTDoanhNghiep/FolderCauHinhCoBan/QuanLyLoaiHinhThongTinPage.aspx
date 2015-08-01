<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="QuanLyLoaiHinhThongTinPage.aspx.cs" Inherits="project.web.Admin.QuanLyLoaiHinhThongTinPage" %>

<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/AddLoaiHinhControl.ascx"
    TagName="AddQuyMoDoanhNghiepControl" TagPrefix="uc1" %>
<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/ListLoaiHinhControl.ascx"
    TagName="ListQuyMoDoanhNghiepControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Quản lý loại hình
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="CauHinhCoBan.aspx">Cấu hình cơ bản</a></li>
    <li class="active">Quản lý loại hình</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:AddQuyMoDoanhNghiepControl ID="AddCatologiesControl1" runat="server" />
    <uc2:ListQuyMoDoanhNghiepControl ID="ListCatologiesControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
