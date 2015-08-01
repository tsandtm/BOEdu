<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-9
Last Modified:			2015-6-9
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageCTQuanLyDonVi.aspx.cs" Inherits="project.web.PageCTQuanLyDonVi" %>

<%@ Register Src="~/Page/MienGiamMon_21052015/FolderCTQuanLyDonVi/AddPhanQuyenDonViControl.ascx"
    TagName="AddCTQuanLyDonViControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Phân quyền đơn vị miễn môn
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li class="active">Phân quyền đơn vị miễn môn</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <%----%>
    <uc1:AddCTQuanLyDonViControl ID="AddCTQuanLyDonViControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
