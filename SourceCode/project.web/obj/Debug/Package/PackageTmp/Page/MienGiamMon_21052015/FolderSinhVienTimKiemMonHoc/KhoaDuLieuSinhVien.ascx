<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-9
Last Modified:			2015-6-9
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KhoaDuLieuSinhVien.ascx.cs"
    Inherits="project.web.KhoaDuLieuSinhVien" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<div id="ts-popup-khoadulieusinhvien" class="bigbox-350">
    <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Khóa dữ liệu sinh viên</h3>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddSinhVien_on">
            <ProgressTemplate>
                <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
                    <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui l?ng ??i..."
                        height="80px" width="80px" /></span>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelPopupAddSinhVien_on" runat="server" UpdateMode="Conditional"
            ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="panel-body">
                    <asp:Literal ID="LiteralSinhVienGuid" Visible="false" runat="server"></asp:Literal>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Chọn niên khóa
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListNienKhoa" CssClass="form-control w-full" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Chọn khoa
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:DropDownList ID="DropDownListKhoa" CssClass="form-control w-full" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="text-right">
                        <asp:LinkButton ID="ButtonKhoa" runat="server" ToolTip="Khóa" CssClass="btn btn-reset btn-sm"
                            OnClientClick="return confirm('Bạn có chắc chắn muốn khóa?')"><i class="fa fa-lock"></i>&nbsp;Khóa</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="ButtonMoKhoa" runat="server" ToolTip="Khóa" CssClass="btn btn-add btn-sm"><i class="fa fa-unlock"></i>&nbsp;Mở khóa</asp:LinkButton>&nbsp;hoặc&nbsp;
                        <asp:LinkButton ID="ButtonExit" runat="server" ToolTip="Hủy" CssClass="btn btn-link btn-cancel btn-sm">&nbsp;Trở về</asp:LinkButton>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ButtonMoKhoa" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonKhoa" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ButtonExit" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
