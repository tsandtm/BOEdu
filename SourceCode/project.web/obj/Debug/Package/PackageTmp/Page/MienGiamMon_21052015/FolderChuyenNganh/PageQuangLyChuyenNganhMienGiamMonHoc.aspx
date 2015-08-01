<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageQuangLyChuyenNganhMienGiamMonHoc.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderChuyenNganh.PageQuangLyChuyenNganhMienGiamMonHoc" %>

<%@ Register Src="AddChuyenNganhControlMienGiamMonHoc.ascx" TagName="AddChuyenNganhControlMienGiamMonHoc"
    TagPrefix="uc1" %>
<%@ Register Src="ListChuyenNganhControlMienGiamMonHoc.ascx" TagName="ListChuyenNganhControlMienGiamMonHoc"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Chuyên ngành đào tạo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/CauHinhCoBan.aspx">Cấu
        hình cơ bản</a></li>
    <li class="active">Cấu hình chuyên ngành đào tạo</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc2:ListChuyenNganhControlMienGiamMonHoc ID="ListChuyenNganhControlMienGiamMonHoc1"
        runat="server" />
    <uc1:AddChuyenNganhControlMienGiamMonHoc ID="AddChuyenNganhControlMienGiamMonHoc1"
        runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
