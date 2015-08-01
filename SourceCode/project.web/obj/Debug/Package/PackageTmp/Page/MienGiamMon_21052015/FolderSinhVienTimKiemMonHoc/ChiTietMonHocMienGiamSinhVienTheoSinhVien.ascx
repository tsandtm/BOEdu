<%--   
Author:					Nam Dep Trai
Created:				2015-5-23
Last Modified:			2015-5-23
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiTietMonHocMienGiamSinhVienTheoSinhVien.ascx.cs"
    Inherits="project.web.Controls.ChiTietMonHocMienGiamSinhVienTheoSinhVien" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<style>
    .setheight
    {
        max-height: 500px;
    }
    .autoscroll
    {
        overflow-y: auto;
    }
</style>
<div id="ts-popup-monmiengiamtheosinhvien" class="bigbox-800">
    <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Môn miễn giảm của sinh viên</h3>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddSinhVien_on">
            <ProgressTemplate>
                <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
                    <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                        height="80px" width="80px" /></span>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelPopupAddSinhVien_on" runat="server" UpdateMode="Conditional"
            ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="panel-body setheight autoscroll">
                    <asp:Literal ID="LiteralSinhVienGuid" runat="server" Visible="false"></asp:Literal>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Ngành
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:Label ID="LabelChuyenNganhName" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="">
                                Danh sách môn miễn giảm
                            </div>
                            <div class="form-group">
                                <div class="table-responsive">
                                    <table class="table table-stripped">
                                        <thead>
                                            <tr>
                                                <th>
                                                    Môn học
                                                </th>
                                                <th>
                                                    Mã môn
                                                </th>
                                                <th class="text-center">
                                                    Số tín chỉ
                                                </th>
                                                <th>
                                                    Môn đã học
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater runat="server" ID="RepeaterMonMienGiam">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <%# Eval("MonHocName")%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("MonHocID")%>
                                                        </td>
                                                        <td class="text-center">
                                                            <%# Eval("SoTinChi")%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("MonHocDaHoc")%>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                        <tfoot>
                                            <tr id="TRTongSoMon" runat="server">
                                                <td style="font-weight: bold;">
                                                    Tổng
                                                </td>
                                                <td class="" style="font-weight: bold;">
                                                    <asp:Label runat="server" ID="LabelTongSoMon"></asp:Label>
                                                </td>
                                                <td class="text-center" style="font-weight: bold;">
                                                    <asp:Label runat="server" ID="LabelTongSoTinChi"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </tfoot>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer text-right">
                    <asp:LinkButton ID="ButtonExit" runat="server" ToolTip="Thoát" class="btn btn-link btn-cancel btn-sm">
            Thoát</asp:LinkButton>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ButtonExit" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</div>
