<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlPhanQuyenDoanhNghiepRight.ascx.cs"
    Inherits="project.web.Page.ControlPhanQuyenDoanhNghiepRight" %>
<div id="ts-popup-pqdn" class="bigbox">
    <asp:UpdatePanel ID="UpdatePanelRight" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="panel panel-default panel-popup">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        Chọn nhân viên cần nhận doanh nghiệp</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:DropDownList ID="DropDownListNguoiRight" runat="server" AutoPostBack="true"
                                CssClass="form-control w-full">
                            </asp:DropDownList>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="text-right">
                        <asp:LinkButton ID="ButtonChuyen" runat="server" ToolTip="Lưu trữ" CssClass="btn btn-add"><i class="fa fa-floppy-o"></i>&nbsp;Xác nhận</asp:LinkButton>&nbsp;hoặc&nbsp;
                        <asp:LinkButton ID="LinkButtonExit" runat="server" ToolTip="Thoát" class="btn btn-link btn-cancel btn-sm">
            Hủy thao tác</asp:LinkButton>
                    </div>
                </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ButtonChuyen" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="LinkButtonExit" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="DropDownListNguoiRight" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</div>
