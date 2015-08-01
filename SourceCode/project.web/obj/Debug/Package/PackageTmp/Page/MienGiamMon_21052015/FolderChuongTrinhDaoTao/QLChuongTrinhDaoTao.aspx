<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="QLChuongTrinhDaoTao.aspx.cs" Inherits="project.web.Admin.QLChuongTrinhDaoTao" %>

<%@ Register Src="~/Page/MienGiamMon_21052015/FolderChuongTrinhDaoTao/AddChuongTrinhDaoTaoControl.ascx"
    TagName="AddChuongTrinhDaoTaoControl" TagPrefix="uc1" %>
<%@ Register Src="~/Page/MienGiamMon_21052015/FolderChuongTrinhDaoTao/ListChuongTrinhDaoTaoControl.ascx"
    TagName="ListChuongTrinhDaoTaoControl" TagPrefix="uc2" %>
<%@ Register Src="~/Page/MienGiamMon_21052015/FolderThongTinDaoTao/ListThongTinDaoTaoControl.ascx"
    TagName="ListThongTinDaoTaoControl" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Quản lý chương trình đào tạo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/CauHinhCoBan.aspx">
        Cấu hình cơ bản</a></li>
    <li class="active">Quản lý chương trình đào tạo</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:AddChuongTrinhDaoTaoControl ID="AddCatologiesControl1" runat="server" />
    <uc2:ListChuongTrinhDaoTaoControl ID="ListCatologiesControl1" runat="server" />
    <uc3:ListThongTinDaoTaoControl ID="ListThongTinDaoTaoControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
