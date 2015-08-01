<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="ThongKeDoanhNghiepAdvancePage.aspx.cs" Inherits="project.web.Page.FolderBaoCaoThongKe.ThongKeDoanhNghiepAdvancePage" %>

<%@ Register Src="ListDoanhNghiepAdvanceControl.ascx" TagName="ListDoanhNghiepAdvanceControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Thống kê doanh nghiệp
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="#">Báo cáo - Thống kê</a></li>
    <li class="active">Thống kê doanh nghiệp</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ListDoanhNghiepAdvanceControl ID="ListDoanhNghiepAdvanceControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
