<%--   
Author:					Nam Dep Trai
Created:				2015-5-22
Last Modified:			2015-5-22
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListChuyenNganhControlMienGiamMonHoc.ascx.cs"
    Inherits="project.web.Controls.ListChuyenNganhControlMienGiamMonHoc" %>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowChuyenNganh_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                height="80px" width="80px" /></span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelShowChuyenNganh_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="row">
            <asp:Panel runat="server" DefaultButton="ButtonSearch" ID="pnlsearch">
                <div class="col-sm-3 p-b-5 p-r-5">
                    <asp:DropDownList ID="DropDownListKhoa" AutoPostBack="true" CssClass="form-control w-full"
                        runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2 p-b-5 p-w-5">
                    <asp:LinkButton ID="ButtonSearch" ToolTip="Tìm kiếm" runat="server" Text="" CssClass="btn btn-primary"><i class="fa fa-search"></i>
                    </asp:LinkButton>
                </div>
            </asp:Panel>
            <div class="col-sm-3  p-b-5 pull-right">
                <div class="pull-right">
                    <asp:LinkButton ID="ButtonAdd" runat="server" ToolTip="Thêm mới" CssClass="btn btn-add"><i class="fa fa-file-o"></i>&nbsp;
 Thêm mới </asp:LinkButton>
                    <asp:LinkButton ID="ButtonDelete" runat="server" ToolTip="Xóa" OnClientClick="return confirm('Bạn có thực sự muốn xóa?')"
                        CssClass="btn btn-delete"><i class="fa fa-trash-o"></i>&nbsp;Xóa</asp:LinkButton>
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
                                    <tr class="">
                                        <th class="text-center w-50">
                                            <input id="CheckBoxAll" onclick="javascript:SelectAllCheckboxes(this,'RepeaterChuyenNganh');"
                                                runat="server" type="checkbox" />
                                        </th>
                                        <th class="text-center w-50">
                                            #
                                        </th>
                                        <th>
                                            Khoa
                                        </th>
                                        <th>
                                            ID
                                        </th>
                                        <th>
                                            Chuyên ngành
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterChuyenNganh" runat="server">
                                        <ItemTemplate>
                                            <tr class="showhim">
                                                <td class="text-center ">
                                                    <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                    <asp:Literal ID="LiteralChuyenNganhGuid" runat="server" Text='<%# Eval("ChuyenNganhGuid")%>'
                                                        Visible="false"></asp:Literal>
                                                </td>
                                                <td class="text-center">
                                                    <div>
                                                        <div class="hideme">
                                                            <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                        </div>
                                                        <div class="showme">
                                                            <asp:LinkButton ID="LinkButtonItem" CssClass="btn btn-primary btn-circle btn-outline"
                                                                runat="server" CommandName="EDIT" CommandArgument='<%# Eval("ChuyenNganhGuid")%>' ToolTip="Chỉnh sửa"><i class="fa fa-pencil"></i></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="text-left">
                                                    <%# Eval("NganhName")%>
                                                </td>
                                                <td class="text-left">
                                                    <%# Eval("ChuyenNganhID")%>
                                                </td>
                                                <td class="text-left">
                                                    <%# Eval("ChuyenNganhName")%>
                                                </td>
                                              
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="6">
                                            <div class="pull-left">
                                                <MyC:mojoCutePager ID="mojoCutePager1" runat="server" CssClass="" />
                                            </div>
                                            <div class=" pull-right">
                                                <asp:DropDownList ID="DropDownListPageNumber" runat="server" AutoPostBack="true"
                                                    CssClass="form-control">
                                                </asp:DropDownList>
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
        <asp:AsyncPostBackTrigger ControlID="ButtonSearch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
