<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-1
Last Modified:			2015-6-1
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddChuongTrinhDaoTaoControl.ascx.cs"
    Inherits="project.web.Controls.AddChuongTrinhDaoTaoControl" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<div id="ts-popup" class="bigbox-400">
    <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Quản lý chương trình đào tạo</h3>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddChuongTrinhDaoTao_on">
            <ProgressTemplate>
                <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
                    <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                        height="80px" width="80px" /></span>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelPopupAddChuongTrinhDaoTao_on" runat="server" UpdateMode="Conditional"
            ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="panel-body">
                    <asp:Literal ID="LiteralCTDaoTaoGuid" Visible="false" runat="server"></asp:Literal>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                Khoa
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListKhoa" AutoPostBack="true" CssClass="form-control w-full"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                Chuyên ngành
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListChuyenNganh" CssClass="form-control w-full" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                Trình độ ĐT
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListTrinhDoDaoTao" CssClass="form-control w-full" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                Hình thức ĐT
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListHinhThucDaoTao" CssClass="form-control w-full"
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                Niên khóa
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListNienKhoa" CssClass="form-control w-full" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                Mã CTĐT
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxChuongTrinhDaoTaoID" CssClass="form-control w-full" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="form-group">
                                Tên CTĐT
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxChuongTrinhDaoTaoName" CssClass="form-control w-full" runat="server"></asp:TextBox>
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
                <asp:AsyncPostBackTrigger ControlID="DropDownListkhoa" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ButtonSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonExit" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonReset" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
