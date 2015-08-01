<%--   
Author:					chuongtv
Created:				2015-4-22
Last Modified:			2015-4-22
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlThongTinTuyenDung.ascx.cs"
    Inherits="project.web.Controls.ControlThongTinTuyenDung" %>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowThongTinHopTac_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 1%; left: 48%; background-color: White;">
            <div class="div-img-center">
                <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                    class="img-responsive" />
            </div>
        </span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelShowThongTinHopTac_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="box-action">
            <asp:LinkButton ID="ButtonAdd" runat="server" ToolTip="Thêm mới" CssClass="btn btn-add"><i class="fa fa-file-o p-r-5"></i>Thêm mới</asp:LinkButton>
            <asp:LinkButton ID="ButtonDelete" runat="server" ToolTip="Xóa" CssClass="btn btn-danger btn-sm"
                Visible="false"><i class="fa fa-trash p-r-5"></i>Xóa</asp:LinkButton>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="table-responsive">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <%--<th>
                                                <input id="CheckBoxAll" onclick="javascript:SelectAllCheckboxes(this,'RepeaterThongTinHopTac');"
                                                    runat="server" type="checkbox" />
                                            </th>--%>
                                <th class="text-center w-50">
                                    #
                                </th>
                                <th>
                                    Mã tuyển dụng
                                </th>
                                <th class="text-right">
                                    Số lượng
                                </th>
                                <th class="text-right">
                                    Lương
                                </th>
                                <th class="text-center">
                                    Thời gian làm việc
                                </th>
                                <th class="text-left">
                                    Thời hạn
                                </th>
                                <th class="text-left">
                                    Người tạo
                                </th>
                                <th>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterThongTinHopTac" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <%--<td class="text-center">
                                                        <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                        
                                                    </td>--%>
                                        <td class="text-center">
                                            <asp:Literal ID="LiteralThongTinHopTacGuid" runat="server" Text='<%# Eval("ThongTinHopTacGuid")%>'
                                                Visible="false"></asp:Literal>
                                            <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                        </td>
                                        <td>
                                            <%# Eval("MaSo")%>
                                        </td>
                                        <td class="text-right">
                                            <%# Eval("SoLuong")%>
                                        </td>
                                        <td class="text-right">
                                            <%# Eval("MucLuong")%>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("ThoiGianLamViec")%>
                                        </td>
                                        <td class="text-left">
                                            <%# Convert.ToDateTime(Eval("TuNgay")).ToString(project.config.library.Utilities.ConstantVariable.FORMAT_DATETIME)%>
                                            -
                                            <%# Convert.ToDateTime(Eval("DenNgay")).ToString(project.config.library.Utilities.ConstantVariable.FORMAT_DATETIME)%>
                                        </td>
                                        <td class="text-left">
                                             <%# Eval("NguoiTaoHoatDongName")%>
                                        </td>
                                        <td class="text-right">
                                            <asp:LinkButton ID="LinkButtonItem" runat="server" CommandName="EDIT" CommandArgument='<%# Eval("ThongTinHopTacGuid")%>'
                                                ToolTip='Chỉnh sửa' CssClass="btn btn-primary btn-circle btn-outline"><i class="fa fa-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="DEL" CommandArgument='<%# Eval("ThongTinHopTacGuid")%>'
                                                OnClientClick="return confirm('Lưu ý! có muốn xóa dòng dữ liệu này')" ToolTip='Xóa'
                                                CssClass="btn btn-danger btn-circle btn-outline"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="8">
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
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="ButtonAdd" />
        <asp:AsyncPostBackTrigger ControlID="ButtonDelete" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
