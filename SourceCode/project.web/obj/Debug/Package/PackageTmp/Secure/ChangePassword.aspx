<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="project.web.Secure.ChangePassword" %>

<%@ Register Src="../Controls/FolderMain/ChangePassControl.ascx" TagName="ChangePassControl"
    TagPrefix="uc1" %>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    Đổi mật khẩu
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
    <li class="active">Đổi mật khẩu</li>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc1:ChangePassControl ID="ChangePassControl1" runat="server" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
