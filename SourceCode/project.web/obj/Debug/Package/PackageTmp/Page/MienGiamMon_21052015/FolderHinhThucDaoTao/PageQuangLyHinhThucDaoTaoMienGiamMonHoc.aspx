<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageQuangLyHinhThucDaoTaoMienGiamMonHoc.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderHinhThucDaoTao.PageQuangLyHinhThucDaoTaoMienGiamMonHoc" %>

<%@ Register Src="AddHinhThucDaoTaoControlMienGiamHocPhi.ascx" TagName="AddHinhThucDaoTaoControlMienGiamHocPhi"
    TagPrefix="uc1" %>
<%@ Register Src="ListHinhThucDaoTaoControlMienGiamHocPhi.ascx" TagName="ListHinhThucDaoTaoControlMienGiamHocPhi"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Hình thức đào tạo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/CauHinhCoBan.aspx">Cấu
        hình cơ bản</a></li>
    <li class="active">Cấu hình Hình thức đào tạo</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc2:ListHinhThucDaoTaoControlMienGiamHocPhi ID="ListHinhThucDaoTaoControlMienGiamHocPhi1"
        runat="server" />
    <uc1:AddHinhThucDaoTaoControlMienGiamHocPhi ID="AddHinhThucDaoTaoControlMienGiamHocPhi1"
        runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
