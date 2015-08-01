<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassControl.ascx.cs"
    Inherits="project.web.Controls.ChangePassControl" %>
<div class="container">
    <div class="col-md-6">
        <div class="panel panel-info nbm">
            <div class="panel-heading">
                Đổi mật khẩu</div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddApplication_on">
                <ProgressTemplate>
                    <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
                        <div class="div-img-center">
                            <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                                height="80px" width="80px" class="img-responsive" />
                        </div>
                    </span>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanelPopupAddApplication_on" runat="server" UpdateMode="Conditional"
                ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="">
                                    Họ và tên
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxUerName" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="">
                                    Tài khoản đăng nhập
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxUserID" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="">
                                    Mật khẩu mới
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxPassWord" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="">
                                    Nhắc lại mật khẩu
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxRePassWord" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <asp:Label ID="LabelThongbao" BackColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="text-right">
                            <asp:LinkButton ID="ButtonSave" runat="server" ToolTip="Lưu" CssClass="btn btn-success width-size-80"><i class="glyphicon glyphicon-floppy-saved"></i>&nbsp;Lưu</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="ButtonExit" runat="server" ToolTip="Hủy" CssClass="btn btn-warning width-size-80"><i class=" glyphicon glyphicon-remove-circle"></i>&nbsp;Hủy</asp:LinkButton>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ButtonSave" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ButtonExit" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
