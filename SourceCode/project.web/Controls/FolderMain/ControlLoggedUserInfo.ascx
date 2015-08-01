<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlLoggedUserInfo.ascx.cs"
    Inherits="project.web.Controls.ControlLoggedUserInfo" %>
<ul class="nav pull-right top-menu" id="userinfo">
    <li class="dropdown"><a data-toggle="dropdown" class="dropdown-toggle" href="#">
        <img src="<%=ResolveUrl("~/") %>Resources/img/avatar.png" alt="" class="img-user"/>
        <asp:Label ID="lblUser" runat="server" CssClass="username" />
        <asp:Label ID="lblID" runat="server" CssClass="username hidden-mobile f-s-13" />
        <b class="caret"></b></a>
        <ul class="dropdown-menu extended logout">
            <%--<li>
              
                <asp:HyperLink ID="HyperLinkUpdateUser" runat="server" Text="Cập nhật thông tin"><i class=" fa fa-suitcase"></i>Cập nhật thông tin</asp:HyperLink>
            </li>--%>
            <li>
                <%--<a href="#"><i class="fa fa-cog"></i>Đổi mật mã</a>--%>
                <asp:HyperLink ID="lnkAccount" runat="server"><i class="fa fa-cog"></i>Đổi mật mã</asp:HyperLink>
            </li>
<%--            <li><a href="LockScreen.htm"><i class="fa fa-lock"></i>Khóa màn hình</a></li>--%>
            <li>
                <%--<a href="<%=ResolveUrl("~/") %>Secure/Login.aspx"><i class="fa fa-user"></i>Đăng nhập</a>--%>
                <asp:HyperLink ID="lnkLogin" runat="server"><i class="fa fa-user"></i>Đăng nhập</asp:HyperLink>
            </li>
            <li>
                <%-- <a href="<%=ResolveUrl("~/") %>Secure/Login.aspx"><i class="fa fa-key"></i>Đăng xuất</a>--%>
                <asp:HyperLink ID="lnkLogoff" runat="server" OnClick="if (!confirm(&quot;Bạn có chắc muốn đăng xuất?&quot;)) return false;"
                    CssClass="btn-logout"><i class="fa fa-key"></i>Đăng xuất</asp:HyperLink>
            </li>
        </ul>
    </li>
</ul>
