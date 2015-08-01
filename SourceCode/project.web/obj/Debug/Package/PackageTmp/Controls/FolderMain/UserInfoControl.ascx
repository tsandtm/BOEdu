<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserInfoControl.ascx.cs"
    Inherits="project.web.Controls.FolderMain.UserInfoControl" %>
<span>
    <img alt="image" class="img-circle avatar" src="<%=ResolveUrl("~/") %>Resources/img/no-avatar.png" />
</span><a data-toggle="dropdown" class="dropdown-toggle lnk-user" href="#"><span class="clear">
    <span class="block m-t-xs"><strong class="font-bold">
        <asp:Label ID="lblFullName" runat="server"></asp:Label></strong> </span><span class="text-muted text-xs block">
            <asp:Label ID="lblUserName" runat="server"></asp:Label><b class="caret"></b></span>
</span></a>
<ul class="dropdown-menu animated fadeInRight m-t-xs">
    <li>
        <asp:HyperLink ID="lnkAccount" runat="server"><i class="fa fa-cog"></i>&nbsp;Đổi mật mã</asp:HyperLink></li>
    <li class="divider"></li>
    <li>
        <asp:HyperLink ID="lnkLogin" runat="server" CssClass="btn-login"><i class="fa fa-sign-in"></i>&nbsp;Đăng nhập</asp:HyperLink>

    </li>
    <li>
        <asp:HyperLink ID="lnkLogoff" runat="server" OnClick="if (!confirm(&quot;Bạn có chắc muốn đăng xuất?&quot;)) return false;"
            CssClass="btn-logout"><i class="fa fa-sign-out"></i>&nbsp;Đăng xuất</asp:HyperLink>

    </li>
</ul>
