<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopNavigationControl.ascx.cs"
    Inherits="project.web.Controls.FolderMain.TopNavigationControl" %>

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
