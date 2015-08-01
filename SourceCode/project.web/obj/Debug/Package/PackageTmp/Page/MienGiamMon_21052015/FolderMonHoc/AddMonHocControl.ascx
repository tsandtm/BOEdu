<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-1
Last Modified:			2015-6-1
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddMonHocControl.ascx.cs"
    Inherits="project.web.Controls.AddMonHocControl" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<div id="ts-popup" class="bigbox-350">
    <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Quản lý môn học</h3>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddMonHoc_on">
            <ProgressTemplate>
                <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
                    <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                        height="80px" width="80px" /></span>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelPopupAddMonHoc_on" runat="server" UpdateMode="Conditional"
            ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="panel-body">
                    <asp:Literal ID="LiteralMonHocGuid" Visible="false" runat="server"></asp:Literal>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Mã môn học
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxMonHocID" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Tên môn học
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxMonHocName" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Số tín chỉ
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxSoTinChi" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Số TC LT
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxSoTCLT" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Số TC TH
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxSoTCTH" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Số TC đồ án
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxSoTCDA" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Số TC đồ án TN
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxSoTCDATN" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="text-center">
                        <asp:LinkButton ID="ButtonSave" runat="server" ToolTip="Lưu" CssClass="btn btn-add btn-sm"><i class="glyphicon glyphicon-floppy-saved"></i>&nbsp;Lưu trữ</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="ButtonReset" runat="server" ToolTip="Reset" CssClass="btn btn-reset btn-sm"><i class="glyphicon glyphicon-repeat"></i>&nbsp;Nhập lại</asp:LinkButton>  &nbsp;hoặc&nbsp;
                        <asp:LinkButton ID="ButtonExit" runat="server" ToolTip="Hủy" CssClass="btn btn-link btn-cancel btn-sm">&nbsp;Hủy thao tác</asp:LinkButton>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ButtonSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonExit" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonReset" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
