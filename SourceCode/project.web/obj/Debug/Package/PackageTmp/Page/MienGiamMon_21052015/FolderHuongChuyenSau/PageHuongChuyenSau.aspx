<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-3
Last Modified:			2015-6-3
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageHuongChuyenSau.aspx.cs" Inherits="project.web.PageHuongChuyenSau" %>

<%@ Register Src="AddHuongChuyenSauControl.ascx" TagName="AddHuongChuyenSauControl"
    TagPrefix="uc1" %>
<%@ Register Src="ListHuongChuyenSauControl.ascx" TagName="ListHuongChuyenSauControl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Hướng chuyên sâu
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li><a href="<%=ResolveUrl("~/") %>Page/10042014_HDHTDoanhNghiep/FolderCauHinhCoBan/CauHinhCoBan.aspx">Cấu
        hình cơ bản</a></li>
    <li class="active">Cấu hình Hướng chuyên sâu</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc2:ListHuongChuyenSauControl ID="ListHuongChuyenSauControl1" runat="server" />
    <uc1:AddHuongChuyenSauControl ID="AddHuongChuyenSauControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
