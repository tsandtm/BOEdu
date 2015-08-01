<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongKeTheoLopControl.ascx.cs"
    Inherits="project.web.Page.MienGiamMon_21052015.FolderBaoCaoThongKe.ThongKeTheoLopControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanelMienGiamTheoLop" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <asp:Panel ID="PanelFilter" runat="server" DefaultButton="ButtonSearch">
            <div class="row">
                <div class="col-sm-4 m-b-5 p-w-5">
                    <div class="input-group">
                        <asp:TextBox ID="TextBoxValueSearch" runat="server" CssClass="form-control w-full"
                            placeholder="Nhập mã lớp ..."></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:LinkButton ID="ButtonSearch" runat="server" Text="" CssClass="btn btn-primary"><i class="fa fa-search"></i>
                            </asp:LinkButton>
                        </span>
                    </div>
                </div>
                <div class="col-sm-6 m-b-5 p-w-5">
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
                                        <th class="text-center">
                                            Số tín chỉ
                                        </th>
                                        <th class="text-center">
                                            Số lượng
                                        </th>
                                        <th>
                                            Lớp
                                        </th>
                                        <th>
                                            Khoa
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterMienMonTheoLop" runat="server">
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
                                                <td class="text-center">
                                                    <%# Eval("SoTinChi")%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("SoLuong")%>
                                                </td>
                                                <td>
                                                    <%# Eval("Lop")%>
                                                </td>
                                                <td>
                                                    <%# Eval("KhoaName")%>
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
        <asp:AsyncPostBackTrigger ControlID="ButtonSearch" EventName="Click" />
        <asp:PostBackTrigger ControlID="LinkButtonExcel" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
