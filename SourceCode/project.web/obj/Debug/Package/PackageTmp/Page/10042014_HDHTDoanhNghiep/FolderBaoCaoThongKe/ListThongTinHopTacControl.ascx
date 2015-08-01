<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListThongTinHopTacControl.ascx.cs"
    Inherits="project.web.Page.FolderBaoCaoThongKe.ListThongTinHopTacControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:UpdatePanel ID="UpdatePanelShowHopTac" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <asp:Panel ID="PanelFilter" runat="server" DefaultButton="ButtonSearch">
            <div class="row">
                <div class="col-sm-3 m-b-5 p-w-5">
                    <asp:DropDownList ID="DropDownListLoaiHopTac" runat="server" CssClass="form-control w-full"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <%--<div class="col-sm-2 m-b-5 p-w-5">
                    <asp:DropDownList ID="DropDownListNhanVien" runat="server" CssClass="form-control w-full">
                    </asp:DropDownList>
                </div>--%>
                <div class="col-sm-2 m-b-5 p-w-5" id="data_TuNgay_ThongTinHopTac">
                    <div class="input-group date w-full">
                        <span class="input-group-addon">Từ</span>
                        <asp:TextBox ID="txtFromDay" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-2 m-b-5 p-w-5" id="data_DenNgay_ThongTinHopTac">
                    <div class="input-group date w-full">
                        <span class="input-group-addon">Đến</span>
                        <asp:TextBox ID="txtToDay" runat="server" CssClass="form-control f-left  "></asp:TextBox>
                    </div>
                </div>
                <div class="col-sm-3 m-b-5 p-w-5">
                    <div class="input-group">
                        <asp:TextBox ID="TextBoxValueSearch" runat="server" CssClass="form-control w-full showtooltip"
                            placeholder="Thông tin tìm kiếm ..."></asp:TextBox>
                        <ul id="elementToHide">
                            <li><b><u>Quy định khóa</u></b></li>
                            <li>- <strong class="text-danger">EMAIL</strong>: địa chỉ email</li>
                            <li>- <strong class="text-danger">PHONE</strong>: số điện thoại</li>
                            <li>- <strong class="text-danger">ADD</strong>: địa chỉ</li>
                            <li><b><u>Sử dụng</u></b></li>
                            <li class="text-danger">[từ khóa]:[cụm từ cần tìm]</li>
                            <li><i><u>Ví dụ:</u> PHONE:093</i></li>
                            <li class="text-success">* Mặc định không sử dụng từ khóa thì tìm kiếm theo tên</li>
                        </ul>
                        <span class="input-group-btn">
                            <asp:LinkButton ID="ButtonSearch" runat="server" Text="" CssClass="btn btn-primary"><i class="fa fa-search"></i>
                            </asp:LinkButton>
                        </span>
                    </div>
                </div>
                <div class="col-sm-2 m-b-5 p-w-5">
                    <p class="pull-right">
                        <%--<asp:LinkButton ID="LinkButtonPrint" runat="server" Text="" CssClass="btn btn-info"><i class="fa fa-print"></i>
                        </asp:LinkButton>--%>
                        <%-- <asp:LinkButton ID="LinkButtonExcel" runat="server" Text="" CssClass="btn btn-primary btn-outline"><i class="fa fa-file-excel-o"></i>
                        </asp:LinkButton>--%>
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
                                        <th>
                                            Doanh nghiệp
                                        </th>
                                        <th class="">
                                            Mã số
                                        </th>
                                        <th>
                                            Hoạt động
                                        </th>
                                        <th class="text-center">
                                            Thời gian
                                        </th>
                                        <th class="text-right">
                                            Số lượng
                                        </th>
                                        <th class="text-right">
                                            Trị giá
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterHopTac" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="text-center">
                                                    <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                </td>
                                                <td>
                                                    <a href="<%# ResolveUrl("~/") + "Page/10042014_HDHTDoanhNghiep/FolderThongTinHopTac/PageThongTinhopTac.aspx?index=" + Eval("DoanhNghiepGuid") %>">
                                                        <%# Eval("DoanhNghiepNameVN") == "" ? Eval("DoanhNghiepNameEN") : Eval("DoanhNghiepNameVN")%>
                                                    </a>
                                                </td>
                                                <td class="hide-sm">
                                                    <%# Eval("MaSo")%>
                                                    <asp:Literal ID="LiteralThongTinLienHe" runat="server" Visible="false"></asp:Literal>
                                                    <%--<%# Eval("ThongTinLienHe")%>--%>
                                                </td>
                                                <td>
                                                    <%# Eval("CatologyName")%>
                                                </td>
                                                <td class="text-center">
                                                    <%# Eval("TuNgay") == null ? "" : Eval("TuNgay", "{0:dd/MM/yyyy}")%>
                                                    <%# Eval("DenNgay") == null ? "" : Eval("DenNgay", "- {0:dd/MM/yyyy}")%>
                                                    
                                                </td>
                                                <td class="text-right">
                                                    <%# Eval("SoLuong")%>
                                                </td>
                                                <td class="text-right">
                                                    <%# project.config.library.Utilities.ConstantVariable.FormatPrices(Eval("TriGia"))%>
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
