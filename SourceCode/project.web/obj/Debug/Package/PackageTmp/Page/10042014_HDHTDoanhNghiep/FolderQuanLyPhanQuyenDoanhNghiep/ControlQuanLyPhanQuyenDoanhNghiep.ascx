<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlQuanLyPhanQuyenDoanhNghiep.ascx.cs"
    Inherits="project.web.Page._10042014_HDHTDoanhNghiep.FolderQuanLyPhanQuyenDoanhNghiep.ControlQuanLyPhanQuyenDoanhNghiep" %>
<asp:UpdatePanel ID="UpdatePanelLeft" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="row p-b-10">
            <div class="col-sm-4">
                <asp:DropDownList ID="DropDownListNguoiLeft" runat="server" CssClass="form-control w-full">
                </asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <asp:Panel ID="Panel1" DefaultButton="ButtonTimKiem" runat="server" CssClass="tooltip-demo">
                    <div class="input-group">
                        <asp:TextBox ID="TextBoxtenDoanhNghiep" runat="server" placeholder="Tên doanh nghiệp"
                            CssClass="form-control w-full" data-toggle="tooltip" data-placement="top"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:LinkButton ID="ButtonTimKiem" runat="server" ToolTip="Tìm kiếm" CssClass="btn btn-primary"><i class="fa fa-search"></i></asp:LinkButton>
                        </span>
                    </div>
                </asp:Panel>
            </div>
            <div class="col-sm-4">
                <div class="pull-right">
                    <asp:LinkButton runat="server" ID="LinkButtonOpenPopUp" CssClass="btn btn-add"><i class="fa fa-angle-double-right p-r-5"></i>Chuyển</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <table class="table table-striped">
                                <thead>
                                    <tr class="">
                                        <th style="width: 50px;">
                                            <input id="CheckBoxAll" onclick="javascript: SelectAllCheckboxes(this, 'RepeaterLeft');"
                                                runat="server" type="checkbox" />
                                        </th>
                                        <th>
                                            Doanh nghiệp
                                        </th>
                                        <th class="w-200">
                                            Quản lý
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater runat="server" ID="RepeaterLeft">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="CheckBoxDoanhNghiepLeft" runat="server" />
                                                    <asp:Literal ID="LiteralDoanhNghiepGuidLeft" runat="server" Text='<%# Eval("DoanhNghiepGuid")%>'
                                                        Visible="false"></asp:Literal>
                                                    <asp:Literal ID="LiteralNguoiDungGuidLeft" runat="server" Text='<%# Eval("NguoiDungGuid")%>'
                                                        Visible="false"></asp:Literal>
                                                </td>
                                                <td>
                                                    <a href="<%# ResolveUrl("~/") + "Page/10042014_HDHTDoanhNghiep/FolderThongTinHopTac/PageThongTinhopTac.aspx?index=" + Eval("DoanhNghiepGuid") %>">
                                                        <%# Eval("DoanhNghiepNameVN") == "" ? Eval("DoanhNghiepNameEN") : Eval("DoanhNghiepNameVN")%>
                                                    </a>
                                                </td>
                                                <td>
                                                    <%# Eval("NguoiDungName")%>
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
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="RepeaterLeft" EventName="ItemCommand" />
        <asp:AsyncPostBackTrigger ControlID="ButtonTimKiem" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="LinkButtonOpenPopUp" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
