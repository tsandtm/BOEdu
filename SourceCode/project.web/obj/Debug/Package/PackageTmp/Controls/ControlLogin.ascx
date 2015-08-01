<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlLogin.ascx.cs"
    Inherits="project.web.Controls.ControlLogin" %>
<MyC:SiteLogin ID="LoginCtrl" runat="server" CssClass="login">
    <LayoutTemplate>
        <asp:Panel ID="knvgfeishjvfiojeofi" runat="server" DefaultButton="Login">
           <%-- <div class="errorHandler alert alert-danger ">
                <i class="fa fa-remove-sign"></i>
                
            </div>--%>
            <fieldset>
                <div class="form-group">
                    <span class="input-icon">
                        <asp:TextBox ID="UserName" runat="server" class="form-control" placeholder="Mã nhân viên"></asp:TextBox>
                        <i class="fa fa-user"></i></span>
                </div>
                <div class="form-group form-actions">
                    <span class="input-icon">
                        <asp:TextBox ID="Password" runat="server" placeholder="Mật mã" CssClass="form-control password"
                            TextMode="Password"></asp:TextBox>
                        <i class="fa fa-lock"></i></span>
                </div>
                <asp:Label ID="FailureText" runat="server" CssClass="alert-danger"  Width="100%"/>
                <div class="form-actions"><asp:CheckBox ID="RememberMe" runat="server" CssClass="grey remember" Visible="true" />
                    <label for="remember" class="checkbox-inline">
                        
                        
                    </label>
                    <asp:LinkButton ID="Login" runat="server" CssClass="btn btn-green pull-right" CommandName="Login"
                        Text="Đăng nhập"> Đăng nhập <i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                    <asp:HyperLink ID="lnkPasswordRecovery" runat="server" />&nbsp;&nbsp;
                    <asp:HyperLink ID="lnkRegisterExtraLink" runat="server" />
                    
                </div>

            </fieldset>
        </asp:Panel>
    </LayoutTemplate>
</MyC:SiteLogin>
