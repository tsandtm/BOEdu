<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNavigationControl.ascx.cs"
    Inherits="project.web.Controls.FolderMain.TopNavigationControl" %>
<%@ Register Src="../FolderThongBao/NewsNotificationControl.ascx" TagName="NewsNotificationControl"
    TagPrefix="uc1" %>
<%@ Register Src="../FolderThongBao/EventsNotificationControl.ascx" TagName="EventsNotificationControl"
    TagPrefix="uc2" %>
<div class="row border-bottom">
    <div class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0">
        <div class="navbar-header">
            <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-outdent">
            </i></a>
            <div class="navbar-form-custom">
                <div class="form-group">
                    <%-- <asp:TextBox ID="txtSearch" runat="server" placeholder="Thông tin ..." class="form-control"></asp:TextBox>--%>
                </div>
            </div>
        </div>
        <ul class="nav navbar-top-links navbar-right">
            <%--<li><span class="m-r-sm text-muted welcome-message">Trang Quản trị TT.QHHTDN .</span>
            </li>
            <li class="dropdown"><a class="dropdown-toggle count-info" data-toggle="dropdown"
                href="#"><i class="fa fa-envelope"></i><span class="label label-warning">2</span>
            </a>
                <uc1:NewsNotificationControl ID="NewsNotificationControl1" runat="server" />
            </li>
            <li class="dropdown"><a class="dropdown-toggle count-info" data-toggle="dropdown"
                href="#"><i class="fa fa-bell"></i><span class="label label-primary">3</span> </a>
                <uc2:EventsNotificationControl ID="EventsNotificationControl1" runat="server" />
            </li>--%>
            <li>
                <asp:HyperLink ID="lnkAddError" runat="server" CssClass="btn-adderror"><i class="fa fa-exclamation-triangle"></i>&nbsp;Báo lỗi</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="lnkLogin" runat="server" CssClass="btn-login" Visible="false"><i class="fa fa-sign-in"></i>&nbsp;Đăng nhập</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="lnkLogoff" runat="server" OnClick="if (!confirm(&quot;Bạn có chắc muốn đăng xuất?&quot;)) return false;"
                    CssClass="btn-logout"><i class="fa fa-sign-out"></i>&nbsp;Đăng xuất</asp:HyperLink></li>
        </ul>
    </div>
</div>
