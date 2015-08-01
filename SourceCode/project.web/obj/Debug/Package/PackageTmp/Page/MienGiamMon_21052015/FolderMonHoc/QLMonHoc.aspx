<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="QLMonHoc.aspx.cs" Inherits="project.web.Admin.QLMonHoc" %>

<%@ Register Src="~/Page/MienGiamMon_21052015/FolderMonHoc/AddMonHocControl.ascx"
    TagName="AddMonHocControl" TagPrefix="uc1" %>
<%@ Register Src="~/Page/MienGiamMon_21052015/FolderMonHoc/ListMonHocControl.ascx"
    TagName="ListMonHocControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Quản lý môn học
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/CauHinhCoBan.aspx">
        Cấu hình cơ bản</a></li>
    <li class="active">Quản lý môn học</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:AddMonHocControl ID="AddCatologiesControl1" runat="server" />
    <uc2:ListMonHocControl ID="ListCatologiesControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
