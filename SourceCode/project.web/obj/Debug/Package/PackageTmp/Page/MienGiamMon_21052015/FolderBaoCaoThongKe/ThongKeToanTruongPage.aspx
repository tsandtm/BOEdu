<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="ThongKeToanTruongPage.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderBaoCaoThongKe.ThongKeToanTruongPage" %>

<%@ Register Src="ThongKeToanTruongControl.ascx" TagName="ThongKeToanTruongControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Thống kê miễn môn Toàn trường
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="BaoCaoThongKePage.aspx">Báo cáo thống kê</a></li>
    <li class="active">Thống kê theo môn miễn của Toàn trường</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ThongKeToanTruongControl ID="ThongKeToanTruongControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
