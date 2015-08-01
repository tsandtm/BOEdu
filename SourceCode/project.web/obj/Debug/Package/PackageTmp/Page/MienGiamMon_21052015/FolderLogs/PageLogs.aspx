<%--   
Author:					chuongtv
Created:				2015-7-13
Last Modified:			2015-7-13
 --%>


<%@ Page Title="" Language="C#" MasterPageFile="~/App_Masters/Website.Master" AutoEventWireup="true"
    CodeBehind="PageLog.aspx.cs" Inherits="project.web.PageLog" %>

<%@ Register src="AddLogsControl.ascx" tagname="AddLogControl" tagprefix="uc1" %>
<%@ Register src="ListLogsControl.ascx" tagname="ListLogControl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
Quản lý lưu vết
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderBreadcrumb" runat="server">
   <li class="active">Quản lý lưu vết</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderContent" runat="server">
    <uc2:ListLogControl ID="ListLogControl1"  runat="server" />
    <uc1:AddLogControl ID="AddLogControl1"  runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>


         
