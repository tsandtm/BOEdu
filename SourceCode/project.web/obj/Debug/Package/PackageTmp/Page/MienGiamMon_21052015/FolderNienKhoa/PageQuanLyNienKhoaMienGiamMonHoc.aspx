<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageQuanLyNienKhoaMienGiamMonHoc.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderNienKhoa.PageQuanLyNienKhoaMienGiamMonHoc" %>

<%@ Register Src="AddNienKhoaControlMienGiamMonHoc.ascx" TagName="AddNienKhoaControlMienGiamMonHoc"
    TagPrefix="uc1" %>
<%@ Register Src="ListNienKhoaControlMienGiamMonHoc.ascx" TagName="ListNienKhoaControlMienGiamMonHoc"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Quản lý niên khóa
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/CauHinhCoBan.aspx">
        Cấu hình cơ bản</a></li>
    <li class="active">Quản lý niên khóa</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc2:ListNienKhoaControlMienGiamMonHoc ID="ListNienKhoaControlMienGiamMonHoc1" runat="server" />
    <uc1:AddNienKhoaControlMienGiamMonHoc ID="AddNienKhoaControlMienGiamMonHoc1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
