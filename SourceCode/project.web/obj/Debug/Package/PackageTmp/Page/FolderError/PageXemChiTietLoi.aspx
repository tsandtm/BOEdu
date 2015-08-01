<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageXemChiTietLoi.aspx.cs" Inherits="project.web.Page.FolderError.PageXemChiTietLoi" %>

<%@ Register Src="XemChiTietLoiControl.ascx" TagName="XemChiTietLoiControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Thông tin lỗi
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="PageListLoiCaNhan.aspx">Danh sách lỗi</a></li>
    <li class="active">Thông tin lỗi</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:XemChiTietLoiControl ID="XemChiTietLoiControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
