<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageQuanLyPhanQuyenDoanhNghiep.aspx.cs" Inherits="project.web.Page._10042014_HDHTDoanhNghiep.FolderQuanLyPhanQuyenDoanhNghiep.PageQuanLyPhanQuyenDoanhNghiep" %>

<%@ Register Src="ControlQuanLyPhanQuyenDoanhNghiep.ascx" TagName="ControlQuanLyPhanQuyenDoanhNghiep"
    TagPrefix="uc1" %>
<%@ Register Src="ControlPhanQuyenDoanhNghiepRight.ascx" TagName="ControlPhanQuyenDoanhNghiepRight"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Phân quyền doanh nghiệp
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li class="active">Phân quyền doanh nghiệp</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ControlQuanLyPhanQuyenDoanhNghiep ID="ControlQuanLyPhanQuyenDoanhNghiep1" runat="server" />
    <uc2:ControlPhanQuyenDoanhNghiepRight ID="ControlPhanQuyenDoanhNghiepRight1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
