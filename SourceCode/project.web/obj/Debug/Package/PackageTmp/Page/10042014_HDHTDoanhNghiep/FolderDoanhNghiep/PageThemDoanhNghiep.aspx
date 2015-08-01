<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageThemDoanhNghiep.aspx.cs" Inherits="project.web.PageThemDoanhNghiep" %>

<%@ Register Src="AddDoanhNghiepControl.ascx" TagName="AddDoanhNghiepControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Thêm mới doanh nghiệp
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    Thêm mới doanh nghiệp
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="PageQuanLyThongTinDoanhNghiep.aspx">Quản lý doanh nghiệp</a></li>
    <li class="active">Thêm mới doanh nghiệp</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:AddDoanhNghiepControl ID="AddDoanhNghiepControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
