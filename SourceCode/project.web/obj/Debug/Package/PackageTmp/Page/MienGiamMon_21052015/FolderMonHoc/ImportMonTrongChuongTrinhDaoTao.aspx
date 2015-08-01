<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="ImportMonTrongChuongTrinhDaoTao.aspx.cs" Inherits="project.web.Page.FolderMonTuongDuong.ImportMonTrongChuongTrinhDaoTao" %>

<%@ Register Src="~/Page/MienGiamMon_21052015/FolderMonHoc/ImportMonHocControl.ascx"
    TagName="ImportMonHocControl" TagPrefix="uc1" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Import môn học
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="QLMonHoc.aspx">Quản lý môn học</a></li>
    <li class="active">Import môn học</li>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ImportMonHocControl ID="ImportMonHocControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
