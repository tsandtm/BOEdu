<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoggedUserInfo.ascx.cs"
    Inherits="project.web.Controls.LoggedUserInfo" %>
<style type="text/css">
    .colorwhite
    {
        color: White;
    }
</style>
<ul class="nav pull-right">
    <%--<li><a href="#" class="hidden-phone visible-tablet visible-desktop" role="button">Settings</a></li>--%>
    <li id="fat-menu" class="dropdown"><a href="#" role="button" class="dropdown-toggle"
        data-toggle="dropdown"><i class="icon-user colorwhite"></i>
        <asp:Label ID="lblUser" runat="server" CssClass="colorwhite" />
        <i class="icon-caret-down"></i></a>
        <ul class="dropdown-menu">
            <li>
                <asp:HyperLink ID="lnkAccount" runat="server" Text="Đổi mật mã" CssClass="hp" /></li>
            <li class="divider"></li>
            <li>
                <asp:HyperLink ID="lnkLogin" runat="server" Text="Đăng nhập" CssClass="hp" />
                <asp:HyperLink ID="lnkLogoff" runat="server" Text="Đăng xuất" Style="cursor: pointer;"
                    onclick="if (!confirm(&quot;Bạn có chắc muốn đăng xuất?&quot;)) return false;"
                    CssClass="hp" />
            </li>
        </ul>
    </li>
    
</ul>
<div class="LoggedUserInfo">
    <%--<asp:HyperLink ID="HyperLinkManager" runat="server" Text="Quản trị" CssClass="hp"/>
         <asp:HyperLink ID="HyperLinkUpdateUser" runat="server" Text="Cập nhật thông tin" CssClass="hp"/>--%>
    
</div>
