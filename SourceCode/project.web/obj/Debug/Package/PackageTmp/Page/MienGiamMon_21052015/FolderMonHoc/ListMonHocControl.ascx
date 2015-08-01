<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-1
Last Modified:			2015-6-1
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListMonHocControl.ascx.cs"
    Inherits="project.web.Controls.ListMonHocControl" %>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowMonHoc_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                height="80px" width="80px" /></span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelShowMonHoc_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="row">
            <asp:Panel ID="pnl" DefaultButton="ButtonSearch" runat="server">
                <div class="col-sm-3 m-b-5 ">
                    <div class="input-group">
                        <asp:TextBox ID="TextBoxValueSearch" runat="server" CssClass="form-control w-full"
                            placeholder="Mã môn, tên môn ..."></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:LinkButton ID="ButtonSearch" ToolTip="Tìm kiếm" runat="server" Text="" CssClass="btn btn-primary"><i class="fa fa-search"></i>
                            </asp:LinkButton>
                        </span>
                    </div>
                </div>
            </asp:Panel>
            <div class="col-sm-9 ">
                <div class="pull-right">
                    <div class="btn-group ">
                        <asp:LinkButton ID="ButtonMore" runat="server" ToolTip="Tác vụ khác" CssClass="btn btn-more dropdown-toggle"
                            data-toggle="dropdown" aria-expanded="false">Tác vụ khác <span class="caret"></span></asp:LinkButton>
                        <ul class="dropdown-menu">
                            <li id="mm_importmonhoc" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderMonHoc/ImportMonTrongChuongTrinhDaoTao.aspx">
                                Import môn học</a></li>
                        </ul>
                    </div>
                    <asp:LinkButton ID="ButtonAdd" runat="server" ToolTip="Thêm mới" CssClass="btn btn-add"><i class="fa fa-file-o"></i>&nbsp;
 Thêm mới </asp:LinkButton>
                    <asp:LinkButton ID="ButtonDelete" OnClientClick="return confirm('Hệ thống sẽ xóa tất cả dữ liệu được chọn. Bạn có chắc muôn xóa?');"
                        runat="server" ToolTip="Xóa" CssClass="btn btn-delete"><i class="fa fa-trash-o"></i>&nbsp;Xóa</asp:LinkButton>
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
                                            <input id="CheckBoxAll" onclick="javascript:SelectAllCheckboxes(this,'RepeaterMonHoc');"
                                                runat="server" type="checkbox" />
                                        </th>
                                        <th class="text-center w-50">
                                            #
                                        </th>
                                        <th>
                                            Mã môn học
                                        </th>
                                        <th>
                                            Tên môn học
                                        </th>
                                        <th>
                                            Số tín chỉ
                                        </th>
                                        <th>
                                            Số tín chỉ LT
                                        </th>
                                        <th>
                                            Số tín chỉ TH
                                        </th>
                                        <th>
                                            Số tín chỉ đồ án MH
                                        </th>
                                        <th>
                                            Số tín chỉ Đồ án TN
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="RepeaterMonHoc" runat="server">
                                    <ItemTemplate>
                                        <tr class="showhim">
                                            <td class="text-center ">
                                                <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                <asp:Literal ID="LiteralMonHocGuid" runat="server" Text='<%# Eval("MonHocGuid")%>'
                                                    Visible="false"></asp:Literal>
                                            </td>
                                            <td class="text-center">
                                                <div>
                                                    <div class="hideme">
                                                        <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                    </div>
                                                    <div class="showme">
                                                        <asp:LinkButton ID="LinkButtonItem" ToolTip="Chỉnh sửa" CssClass="btn btn-primary btn-circle btn-outline"
                                                            runat="server" CommandName="EDIT" CommandArgument='<%# Eval("MonHocGuid")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("MonHocID")%>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("MonHocName")%>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("SoTinChi")%>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("SoTCLyThuyet")%>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("SoTCThucHanh")%>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("SoTCDoAn")%>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("SoTCDoAnTN")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tfoot>
                                    <tr>
                                        <th colspan="9">
                                            <div class="form-inline">
                                                <div class="pull-left">
                                                    <MyC:mojoCutePager ID="mojoCutePager1" runat="server" CssClass="" />
                                                </div>
                                            </div>
                                            <div class=" pull-right">
                                                <div class="form-group">
                                                    <asp:DropDownList ID="DropDownListPageNumber" runat="server" AutoPostBack="true"
                                                        CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </th>
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
        <asp:AsyncPostBackTrigger ControlID="ButtonAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ButtonDelete" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
