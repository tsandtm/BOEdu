<%--   
Author:					Nguyen Thanh Dai
Created:				2015-5-22
Last Modified:			2015-5-22
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListKhoaControl.ascx.cs"
    Inherits="project.web.Controls.ListKhoaControl" %>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowKhoa_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                height="80px" width="80px" /></span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelShowKhoa_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="row">
            <div class="col-sm-12  p-b-5">
                <div class="pull-right">
                    <asp:LinkButton ID="ButtonAdd" runat="server" ToolTip="Đồng bộ" CssClass="btn btn-add"><i class="glyphicon glyphicon-file"></i>&nbsp;Đồng bộ</asp:LinkButton>
                    <asp:LinkButton ID="ButtonDelete" runat="server" Text="Xóa" class="btn btn-delete"
                        OnClientClick="return confirm('Hệ thống sẽ xóa tất cả dữ liệu được chọn. Bạn có chắc muôn xóa?');"><i class="fa fa-trash-o"></i>&nbsp;Xóa</asp:LinkButton>
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
                                        <th class="text-center" style="width: 50px">
                                            <input id="CheckBoxAll" onclick="javascript:SelectAllCheckboxes(this,'RepeaterKhoa');"
                                                runat="server" type="checkbox" />
                                        </th>
                                        <th class="text-center" style="width: 50px">
                                            #
                                        </th>
                                        <th style="width: 200px">
                                            Viết tắt
                                        </th>
                                        <th>
                                            Tên đơn vị
                                        </th>
                                       
                                    </tr>
                                </thead>
                                <asp:Repeater ID="RepeaterKhoa" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center ">
                                                <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                <asp:Literal ID="LiteralKhoaGuid" runat="server" Text='<%# Eval("KhoaGuid")%>' Visible="false"></asp:Literal>
                                            </td>
                                            <td class="text-center">
                                                <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("KhoaID")%>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("KhoaName")%>
                                            </td>
                                          
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tfoot>
                                    <tr>
                                        <td colspan="4">
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
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ButtonAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ButtonDelete" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
