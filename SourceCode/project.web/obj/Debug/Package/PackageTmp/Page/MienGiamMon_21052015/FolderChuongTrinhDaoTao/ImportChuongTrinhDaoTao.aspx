<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true" CodeBehind="ImportChuongTrinhDaoTao.aspx.cs" Inherits="project.web.Page.FolderMonTuongDuong.ImportChuongTrinhDaoTao" %>
<%@ Register src="~/Page/MienGiamMon_21052015/FolderChuongTrinhDaoTao/ImportChuongTrinhDaoTaoControl.ascx" tagname="ImportChuongTrinhDaoTaoControl" tagprefix="uc1" %>


<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Import chương trình đào tạo
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
<li><a href="QLChuongTrinhDaoTao.aspx">Quản lý Chương trình đào tạo</a></li>
    <li class="active">Import chương trình đào tạo</li>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
 <uc1:ImportChuongTrinhDaoTaoControl ID="ImportMonHocControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>