<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-1
Last Modified:			2015-6-1
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListChuongTrinhDaoTaoControl.ascx.cs"
    Inherits="project.web.Controls.ListChuongTrinhDaoTaoControl" %>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowChuongTrinhDaoTao_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                height="80px" width="80px" /></span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelShowChuongTrinhDaoTao_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="row">
            <asp:Panel runat="server" DefaultButton="ButtonSearch" ID="pnlsearch">
                <div class="col-sm-8 p-b-5 p-w-5 text-right">
                    <div class="">
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <asp:DropDownList ID="DropDownListNienKhoa" CssClass="form-control w-full" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <asp:DropDownList ID="DropDownListKhoa" AutoPostBack="true" CssClass="form-control w-full"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <asp:DropDownList ID="DropDownListChuyenNganh" CssClass="form-control w-full" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="">
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <asp:DropDownList ID="DropDownListHinhThucDaoTao" CssClass="form-control w-full"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4 p-w-5 p-b-5">
                            <%--<div class="input-group">--%>
                            <asp:DropDownList ID="DropDownListTrinhDoDaoTao" CssClass="form-control w-full" runat="server">
                            </asp:DropDownList>
                            <%-- <span class="input-group-btn">
                           
                        </span>
                    </div>--%>
                        </div>
                        <div class="col-sm-4 p-w-5 p-b-5 ">
                            <asp:LinkButton ID="ButtonSearch" runat="server" Text="" CssClass="btn btn-primary "><i class="fa fa-search"></i>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="col-sm-4 p-b-5 text-right pull-right">
                <div class="">
                    <div class="btn-group">
                        <asp:LinkButton ID="ButtonMore" runat="server" ToolTip="Tác vụ khác" CssClass="btn btn-more dropdown-toggle"
                            data-toggle="dropdown" aria-expanded="false">Tác vụ khác <span class="caret"></span></asp:LinkButton>
                        <ul class="dropdown-menu">
                            <li id="mm_importchuongtrinhdaotao" runat="server"><a href="<%=ResolveUrl("~/") %>Page/MienGiamMon_21052015/FolderChuongTrinhDaoTao/ImportChuongTrinhDaoTao.aspx">
                                Import chương trình đào tạo</a></li>
                        </ul>
                    </div>
                    <asp:LinkButton ID="ButtonAdd" runat="server" ToolTip="Thêm mới" CssClass="btn btn-add"><i class="fa fa-file-o"></i>&nbsp;Thêm </asp:LinkButton>
                    <asp:LinkButton ID="ButtonDelete" runat="server" ToolTip="Xóa" CssClass="btn btn-delete"><i class="fa fa-trash-o"></i>&nbsp;Xóa</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <table class="table table-stripped">
                                <thead>
                                    <tr class="">
                                        <th class="text-center w-50">
                                            <input id="CheckBoxAll" onclick="javascript:SelectAllCheckboxes(this,'RepeaterChuongTrinhDaoTao');"
                                                runat="server" type="checkbox" />
                                        </th>
                                        <th class="w-100 text-center">
                                            #
                                        </th>
                                        <th>
                                            Mã CTDT
                                        </th>
                                        <th>
                                            Tên chương trình đào tạo
                                        </th>
                                        <th class="w-50 text-center">
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="RepeaterChuongTrinhDaoTao" runat="server">
                                    <ItemTemplate>
                                        <tr class="showhim">
                                            <td class="text-center ">
                                                <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                <asp:Literal ID="LiteralCTDaoTaoGuid" runat="server" Text='<%# Eval("CTDaoTaoGuid")%>'
                                                    Visible="false"></asp:Literal>
                                            </td>
                                            <td class="text-center">
                                                <div>
                                                    <div class="hideme">
                                                        <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                    </div>
                                                    <div class="showme">
                                                        <asp:LinkButton ID="LinkButtonItem" ToolTip="Sửa" CssClass="btn btn-primary btn-circle btn-outline"
                                                            runat="server" CommandName="EDIT" CommandArgument='<%# Eval("CTDaoTaoGuid")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("CTDaoTaoID")%>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("CTDaoTaoName")%>
                                            </td>
                                            <td class="text-center">
                                               
                                                    <asp:LinkButton ID="LinkButtonItem2" CssClass="btn btn-primary btn-circle btn-outline"
                                                        runat="server" ToolTip="Xem chương trình đào tạo" CommandName="LoadDuLieu" CommandArgument='<%# Eval("CTDaoTaoGuid")%>'><i class="fa fa-eye"></i></asp:LinkButton>
                                                
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tfoot>
                                    <tr>
                                        <th colspan="5">
                                            <div class="form-inline">
                                                <div class="pull-left" id="block_page">
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
        <asp:AsyncPostBackTrigger ControlID="DropDownListKhoa" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ButtonSearch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ButtonAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ButtonDelete" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
