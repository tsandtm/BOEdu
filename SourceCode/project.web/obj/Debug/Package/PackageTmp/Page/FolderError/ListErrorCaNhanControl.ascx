<%--   
Author:					namdt
Created:				2015-5-13
Last Modified:			2015-5-13
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListErrorCaNhanControl.ascx.cs"
    Inherits="project.web.Controls.ListErrorCaNhanControl" %>
<asp:UpdatePanel ID="UpdatePanelShowerror_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>
                                            #
                                        </th>
                                        <th>
                                            Lỗi
                                        </th>
                                        <th>
                                            Ngày báo
                                        </th>
                                        <td>
                                            Người gửi
                                        </td>
                                        <th id="thAdmin" runat="server">
                                        </th>
                                        <%--<th>
                                            Người phản hồi
                                        </th>
                                        <th>
                                            Nội dung phản hồi
                                        </th>
                                        <th>
                                            Ngày phản hồi
                                        </th>--%>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="Repeatererror" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <asp:Literal ID="LiteralErrorGuid" runat="server" Text='<%# Eval("ErrorGuid")%>'
                                                    Visible="false"></asp:Literal>
                                                <td>
                                                    <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                </td>
                                                <td>
                                                    <%--  <asp:LinkButton ID="LinkButtonItem" runat="server" CommandName="EDIT" CommandArgument='<%# Eval("ErrorGuid")%>'
                                Text=''></asp:LinkButton>--%>
                                                    <a href="PageXemChiTietLoi.aspx?rorregol=<%# Eval("ErrorGuid")%>">
                                                        <%# ChuyenDoiNoiDungLoi(Eval("MoTaLoi").ToString()) %></a>
                                                </td>
                                                <td>
                                                    <%# Eval("NgayGui")%>
                                                </td>
                                                <td>
                                                    <%# Eval("NguoiGuiName")%>
                                                </td>
                                                <td>
                                                    <asp:Panel ID="PanelButtonXoa" runat="server">
                                                        <asp:LinkButton ID="LinkButtonItem" OnClientClick="return confirm('Bạn có thực sự muốn xóa?')"
                                                            runat="server" CommandName="DEL" CommandArgument='<%# Eval("ErrorGuid")%>' Text='Xóa'></asp:LinkButton>
                                                    </asp:Panel>
                                                </td>
                                                <%--<td>
                                                    <%# Eval("NguoiPhanHoiName")%>
                                                </td>
                                                <td>
                                                    <%# Eval("NoiDungPhanHoi")%>
                                                </td>
                                                <td>
                                                    <%# Eval("NgayPhanHoi")%>
                                                </td>--%>
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
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
        <asp:AsyncPostBackTrigger ControlID="Repeatererror" EventName="ItemCommand" />
    </Triggers>
</asp:UpdatePanel>
