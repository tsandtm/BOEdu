<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftNavigationControl.ascx.cs"
    Inherits="project.web.Controls.FolderMain.LeftNavigationControl" %>
<%@ Register Src="LeftMenuControl.ascx" TagName="LeftMenuControl" TagPrefix="uc1" %>
<%@ Register Src="UserInfoControl.ascx" TagName="UserInfoControl" TagPrefix="uc2" %>
<%--<%@ Register src="LoggedUserControl.ascx" tagname="LoggedUserControl" tagprefix="uc3" %>--%>
<div class="navbar-default navbar-static-side" role="navigation">
    <div class="navbar-fixed-top sidebar-collapse hoadm-menu-fixed" id="navbar-menu">
        <ul class="nav" id="side-menu">
            <li class="nav-header dcjq-parent">
                <div class="dropdown profile-element">
                    <%--<uc3:LoggedUserControl ID="LoggedUserControl1" runat="server" />--%>
                    <uc2:UserInfoControl ID="UserInfoControl1" runat="server" />
                </div>
                <div class="logo-element">
                    <img src="<%=ResolveUrl("~/") %>Resources/img/logo-mini.png" class="logo-mini" />
                </div>
            </li>
        </ul>
        <uc1:LeftMenuControl ID="LeftMenuControl1" runat="server" />
    </div>
</div>
