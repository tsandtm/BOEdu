<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="ThongKeTheoLopPage.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderBaoCaoThongKe.ThongKeTheoLopPage" %>

<%@ Register Src="ThongKeTheoLopControl.ascx" TagName="ThongKeTheoLopControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Thống kê miễn môn theo Lớp
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="BaoCaoThongKePage.aspx">Báo cáo thống kê</a></li>
    <li class="active">Thống kê theo môn miễn theo Lớp</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ThongKeTheoLopControl ID="ThongKeTheoLopControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
