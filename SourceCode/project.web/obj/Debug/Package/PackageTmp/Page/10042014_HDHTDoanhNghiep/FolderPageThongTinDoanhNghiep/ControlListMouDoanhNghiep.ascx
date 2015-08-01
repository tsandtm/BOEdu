<%--   
Author:					namdt
Created:				2015-4-22
Last Modified:			2015-4-22
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlListMouDoanhNghiep.ascx.cs"
    Inherits="project.web.Controls.ControlListMouDoanhNghiep" %>
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
                                <th class="text-center w-50">
                                    #
                                </th>
                                <th class="text-left">
                                    Ngày ký kết
                                </th>
                                <th>
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
                                        <td class="text-center">
                                            <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                        </td>
                                        <td class="text-left">
                                            <%# Convert.ToDateTime(Eval("TuNgay")).ToString(project.config.library.Utilities.ConstantVariable.FORMAT_DATETIME)%>
                                            -
                                            <%# Convert.ToDateTime(Eval("DenNgay")).ToString(project.config.library.Utilities.ConstantVariable.FORMAT_DATETIME)%>
                                        </td>
                                        <td>
                                            <%# Eval("UserQuanLyName")%>
                                        </td>
                                        <td class="text-right">
                                            <asp:LinkButton ID="LinkButtonItem" runat="server" CommandName="EDIT" CommandArgument='<%# Eval("ThongTinHopTacGuid")%>'
                                                ToolTip='Chỉnh sửa' CssClass="btn btn-primary btn-circle btn-outline"><i class="fa fa-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="DEL" CommandArgument='<%# Eval("ThongTinHopTacGuid")%>'
                                                ToolTip='Xóa' CssClass="btn btn-danger btn-circle btn-outline" OnClientClick="return confirm('Xóa thông tin hoạt động sẽ dẫn đến xóa tất cả file liên quan, bạn có chắc?')"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="6">
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
