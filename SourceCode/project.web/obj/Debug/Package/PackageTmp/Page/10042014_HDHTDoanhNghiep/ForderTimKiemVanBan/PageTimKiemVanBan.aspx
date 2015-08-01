<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageTimKiemVanBan.aspx.cs" Inherits="project.web.Page._10042014_HDHTDoanhNghiep.ForderTimKiemVanBan.PageTimKiemVanBan" %>

<%@ Register Src="ControlTimKiemVanBanHopTac.ascx" TagName="ControlTimKiemVanBanHopTac"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Tìm kiếm văn bản
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li class="active">Trang tìm kiếm</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ControlTimKiemVanBanHopTac ID="ControlTimKiemVanBanHopTac1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
