<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongKeToanTruongControl.ascx.cs"
    Inherits="project.web.Page.MienGiamMon_21052015.FolderBaoCaoThongKe.ThongKeToanTruongControl" %>
<asp:UpdatePanel ID="UpdatePanelMienGiamToanTruong" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <asp:Panel ID="PanelFilter" runat="server">
            <div class="row">
                <div class="col-sm-3 m-b-5 p-w-5">
                    <div class="input-group">
                        <asp:DropDownList ID="DropDownListNienKhoa" runat="server" CssClass="form-control w-full"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        </span>
                    </div>
                </div>
                <div class="col-sm-7 m-b-5 p-w-5">
                </div>
                <div class="col-sm-2 m-b-5 p-w-5">
                    <p class="pull-right">
                        <asp:LinkButton ID="LinkButtonExcel" runat="server" class="btn-excel"><i class="fa fa-file-excel-o"></i>&nbsp;Xuất excel
                        </asp:LinkButton>
                    </p>
                </div>
            </div>
        </asp:Panel>
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th class="text-center">
                                            #
                                        </th>
                                        <th class="text-center">
                                            Mã MH
                                        </th>
                                        <th>
                                            Tên MH
                                        </th>
                                        <%-- <th class="text-center">
                                            Số tín chỉ
                                        </th>--%>
                                        <th class="text-center">
                                            Số lượng
                                        </th>
                                        <th>
                                            Ghi chú
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterMienMonToanTruong" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="text-center">
                                                    <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("MonHocID")%>
                                                </td>
                                                <td class="">
                                                    <%# Eval("MonHocName")%>
                                                </td>
                                                <%-- <td>
                                                    <%# Eval("SoTinChi")%>
                                                </td>--%>
                                                <td class="text-center">
                                                    <%# Eval("SoLuong")%>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="LieteralNhomMonHoc" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="7">
                                            <div class="pull-right">
                                                <asp:DropDownList ID="DropDownListPageNumber" runat="server" AutoPostBack="true"
                                                    CssClass="form-control input-sm">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="pull-left">
                                                <MyC:mojoCutePager ID="mojoCutePager1" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DropDownListNienKhoa" EventName="SelectedIndexChanged" />
        <%--<asp:AsyncPostBackTrigger ControlID="ButtonSearch" EventName="Click" />--%>
        <asp:PostBackTrigger ControlID="LinkButtonExcel" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
