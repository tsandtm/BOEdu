<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="QLKhoa.aspx.cs" Inherits="project.web.Page.FolderKhoa.QLKhoa" %>

<%@ Register Src="ListKhoaControl.ascx" TagName="ListKhoaControl" TagPrefix="uc1" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Quản lý khoa
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/CauHinhCoBan.aspx">
        Cấu hình cơ bản</a></li>
    <li class="active">Quản lý khoa</li>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ListKhoaControl ID="ListKhoaControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
