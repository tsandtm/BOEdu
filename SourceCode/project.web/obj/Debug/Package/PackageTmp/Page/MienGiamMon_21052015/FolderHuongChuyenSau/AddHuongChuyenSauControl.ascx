<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-3
Last Modified:			2015-6-3
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddHuongChuyenSauControl.ascx.cs"
    Inherits="project.web.AddHuongChuyenSauControl" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<div id="ts-popup" class="bigbox-350">
    <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Quản lý hướng chuyên sâu</h3>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddHuongChuyenSau_on">
            <ProgressTemplate>
                <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
                    <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                        height="80px" width="80px" /></span>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelPopupAddHuongChuyenSau_on" runat="server" UpdateMode="Conditional"
            ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="panel-body">
                    <asp:Literal ID="LiteralChuyenSauGuid" Visible="false" runat="server"></asp:Literal>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="form-group">
                                Khoa
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListKhoa" AutoPostBack="true" runat="server" CssClass="form-control w-full">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-sm-5">
                            <div class="form-group">
                                Chuyên ngành
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListChuyenNganh" runat="server" CssClass="form-control w-full">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="form-group">
                                Chuyên sâu ID
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxChuyenSauID" runat="server" CssClass="form-control w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5">
                            <div class="form-group">
                                Chuyên sâu
                            </div>
                        </div>
                        <div class="col-sm-7">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxhuongchuyensauname" runat="server" CssClass="form-control w-full"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer text-right">
                    <asp:LinkButton ID="ButtonSave" runat="server" ToolTip="Lưu trữ" CssClass="btn btn-add btn-sm"><i class="fa fa-floppy-o"></i>&nbsp;Lưu trữ</asp:LinkButton>
                    <asp:LinkButton ID="ButtonReset" runat="server" ToolTip="Reset" CssClass="btn btn-reset btn-sm"><i class="fa fa-rotate-left"></i>&nbsp;Nhập lại</asp:LinkButton>
                    &nbsp;hoặc&nbsp;
                    <asp:LinkButton ID="ButtonExit" runat="server" ToolTip="Thoát" class="btn btn-link btn-cancel btn-sm">
            Hủy thao tác</asp:LinkButton>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownListKhoa" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ButtonSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonExit" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonReset" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
