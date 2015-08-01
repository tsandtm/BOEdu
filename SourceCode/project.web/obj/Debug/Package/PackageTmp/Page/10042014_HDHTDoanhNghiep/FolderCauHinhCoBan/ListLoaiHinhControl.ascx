<%--   
Author:					Nguyen Van Ngoc
Created:				2014-3-11
Last Modified:			2014-3-11
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListLoaiHinhControl.ascx.cs"
    Inherits="project.web.Controls.ListLoaiHinhControl" %>
<asp:UpdatePanel ID="UpdatePanelShowCatologie_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="row">
            <div class="col-sm-8 m-b-5 p-w-5">
                <asp:LinkButton ID="ButtonAdd" runat="server" Text="Thêm mới" class="btn btn-add"><i class="fa fa-floppy-o"></i>&nbsp;Thêm mới</asp:LinkButton>
                <asp:LinkButton ID="ButtonDelete" runat="server" Text="Xóa" class="btn btn-delete"
                    OnClientClick="return confirm('Hệ thống sẽ xóa tất cả các node con nếu node cha được chọn. Bạn có chắc muôn xóa?');"><i class="fa fa-trash-o"></i>&nbsp;Xóa</asp:LinkButton>
                <%--<asp:Button ID="ButtonMore" runat="server" Text="Mở rộng" class="btn btn-default btn-sm" />--%>
            </div>
            <div class="col-sm-4 m-b-5 p-w-5">
                <div class=" pull-right">
                    <asp:DropDownList ID="DropDownListIsActive" runat="server" AutoPostBack="true" CssClass="form-control ">
                        <asp:ListItem Text="Đã kích hoạt" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Chưa kích hoạt" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Tất cả" Value="-1"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th class="text-center w-50">
                                            <input id="CheckBoxAll" onclick="javascript: SelectAllCheckboxes(this, 'RepeaterCatologie');"
                                                runat="server" type="checkbox" />
                                        </th>
                                        <th class="text-center w-50">#
                                        </th>
                                        <th>Tên gọi
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterCatologie" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="text-center">
                                                    <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                    <asp:Literal ID="LiteralCatologyGuid" runat="server" Text='<%# Eval("CatologyGuid")%>'
                                                        Visible="false"></asp:Literal>
                                                </td>
                                                <td class="text-center">
                                                    <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                </td>
                                                <td>
                                                    <%# BuildSymbol(Eval("Levels")) %>
                                                    <asp:LinkButton ID="LinkButtonItem" runat="server" CommandName="EDIT" CommandArgument='<%# Eval("CatologyGuid")%>'
                                                        Text='<%# Eval("CatologyName")%>'></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="3">
                                            <div class="form-group pull-right">
                                                <asp:DropDownList ID="DropDownListPageNumber" runat="server" AutoPostBack="true"
                                                    CssClass="form-control">
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
        <asp:AsyncPostBackTrigger ControlID="ButtonAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ButtonDelete" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
