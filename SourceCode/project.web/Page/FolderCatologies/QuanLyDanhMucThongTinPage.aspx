<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="QuanLyDanhMucThongTinPage.aspx.cs" Inherits="project.web.Admin.QuanLyDanhMucThongTinPage" %>

<%@ Register Src="~/Page/FolderCatologies/AddCatologiesControl.ascx" TagName="AddCatologiesControl"
    TagPrefix="uc1" %>
<%@ Register Src="~/Page/FolderCatologies/ListCatologiesControl.ascx" TagName="ListCatologiesControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Quản lý danh mục thông tin
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li class="active">Quản lý danh mục thông tin</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:AddCatologiesControl ID="AddCatologiesControl1" runat="server" />
    <uc2:ListCatologiesControl ID="ListCatologiesControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>

