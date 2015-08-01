<%--   
Author:					Nguyen Thanh Dai
Created:				2015-5-11
Last Modified:			2015-5-11
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListPhanQuyenNhanVienControl.ascx.cs"
    Inherits="project.web.Controls.ListPhanQuyenNhanVienControl" %>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowPhanQuyenNhanVien_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <div class="div-img-center">
                <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                    height="80px" width="80px" class="img-responsive" />
            </div>
        </span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelShowPhanQuyenNhanVien_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="row">
            <div class="col-sm-8 m-b-5 p-w-5">
                <asp:LinkButton ID="ButtonAdd" runat="server" ToolTip="Thêm mới" CssClass="btn btn-primary btn-sm"><i class="fa fa-file-o"></i>&nbsp;Thêm mới</asp:LinkButton>
                <asp:LinkButton ID="ButtonDelete" OnClientClick="return confirm('Hệ thống sẽ xóa tất cả các node con nếu node cha được chọn. Bạn có chắc muôn xóa?');"
                    runat="server" ToolTip="Xóa" CssClass="btn btn-danger width-size-110 btn-sm"><i class="fa fa-trash"></i>&nbsp;Xóa</asp:LinkButton>
            </div>
            <div class="col-sm-4 m-b-5 p-w-5">
                <asp:Panel ID="Panel1" DefaultButton="ButtonSearch" runat="server" CssClass="tooltip-demo">
                    <div class="input-group">
                        <asp:TextBox ID="TextBoxKeySearch" runat="server" placeholder="Mã hoặc tên nhân viên"
                            CssClass="form-control w-full" data-toggle="tooltip" data-placement="top"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:LinkButton ID="ButtonSearch" runat="server" ToolTip="Tìm kiếm" CssClass="btn btn-primary"><i class="fa fa-search"></i></asp:LinkButton>
                        </span>
                    </div>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <table class="table table-stripped ">
                                <thead>
                                    <tr>
                                        <th class="text-center w-50">
                                            <input id="CheckBoxAll" onclick="javascript:SelectAllCheckboxes(this,'RepeaterPhanQuyenNhanVien');"
                                                runat="server" type="checkbox" />
                                        </th>
                                        <th class="text-center w-50">
                                            #
                                        </th>
                                        <th>
                                            Tên gọi
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="RepeaterPhanQuyenNhanVien" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="text-center ">
                                                <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                <asp:Literal ID="LiteralNguoiDungGuid" runat="server" Text='<%# Eval("NguoiDungGuid")%>'
                                                    Visible="false"></asp:Literal>
                                            </td>
                                            <td class="text-center">
                                                <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="EDIT" CommandArgument='<%# Eval("NguoiDungGuid")%>'
                                                    Text='<%# Eval("NguoiDungName")%>'></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr>
                                    <td colspan="3">
                                        <div class="pull-left" id="block_page">
                                            <MyC:mojoCutePager ID="mojoCutePager1" runat="server" CssClass="" />
                                        </div>
                                        <div class="form-group pull-right">
                                            <asp:DropDownList ID="DropDownListPageNumber" runat="server" AutoPostBack="true"
                                                CssClass="form-control  width-size-100">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
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
