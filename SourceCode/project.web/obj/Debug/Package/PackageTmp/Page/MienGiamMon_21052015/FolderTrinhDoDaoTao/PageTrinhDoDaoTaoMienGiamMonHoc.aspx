<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageTrinhDoDaoTaoMienGiamMonHoc.aspx.cs" Inherits="project.web.Page.MienGiamMon_21052015.FolderTrinhDoDaoTao.PageTrinhDoDaoTaoMienGiamMonHoc" %>

<%@ Register src="AddTrinhDoDaoTaoControlMienGiamMonHoc.ascx" tagname="AddTrinhDoDaoTaoControlMienGiamMonHoc" tagprefix="uc1" %>
<%@ Register src="ListTrinhDoDaoTaoControlMienGiamMonHoc.ascx" tagname="ListTrinhDoDaoTaoControlMienGiamMonHoc" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
Cấu hình Trình độ đào tạo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
<li><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/CauHinhCoBan.aspx">Cấu
        hình cơ bản</a></li>
    <li class="active">Cấu hình Trình độ đào tạo</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc2:ListTrinhDoDaoTaoControlMienGiamMonHoc ID="ListTrinhDoDaoTaoControlMienGiamMonHoc1" 
        runat="server" />
    <uc1:AddTrinhDoDaoTaoControlMienGiamMonHoc ID="AddTrinhDoDaoTaoControlMienGiamMonHoc1" 
        runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
