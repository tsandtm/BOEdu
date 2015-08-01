<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="QuanLyDoiTuongThucTapPage.aspx.cs" Inherits="project.web.Admin.QuanLyDoiTuongThucTapPage" %>

<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/AddDoiTuongThucTapControl.ascx"
    TagName="AddDoiTuongThucTapControl" TagPrefix="uc1" %>
<%@ Register Src="~/Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/ListDoiTuongThucTapControl.ascx"
    TagName="ListDoiTuongThucTapControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Quản lý đối tượng thực tập
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="CauHinhCoBan.aspx">Cấu hình cơ bản</a></li>
    <li class="active">Quản lý đối tượng thực tập</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:AddDoiTuongThucTapControl ID="AddCatologiesControl1" runat="server" />
    <uc2:ListDoiTuongThucTapControl ID="ListCatologiesControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
