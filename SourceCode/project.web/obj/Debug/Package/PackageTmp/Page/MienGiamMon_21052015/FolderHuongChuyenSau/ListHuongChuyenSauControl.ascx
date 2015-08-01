<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-3
Last Modified:			2015-6-3
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListHuongChuyenSauControl.ascx.cs"
    Inherits="project.web.ListHuongChuyenSauControl" %>
<style type="text/css">
    .current
    {
        font-weight: bold;
    }
</style>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowHuongChuyenSau_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                height="80px" width="80px" /></span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelShowHuongChuyenSau_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="row">
            <asp:Panel runat="server" DefaultButton="ButtonSearch" ID="pnlsearch">
                <div class="col-sm-3 m-b-5 p-r-5">
                    <asp:DropDownList ID="DropDownListKhoa" AutoPostBack="true" CssClass="form-control w-full"
                        runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-3 m-b-5 p-w-5">
                    <asp:DropDownList ID="DropDownListChuyenNganh" CssClass="form-control w-full" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-2 m-b-5 p-w-5">
                    <asp:LinkButton ID="ButtonSearch" ToolTip="Tìm kiếm" runat="server" Text="" CssClass="btn btn-primary"><i class="fa fa-search"></i>
                    </asp:LinkButton>
                </div>
            </asp:Panel>
            <div class="col-sm-4  p-b-5">
                <div class="pull-right">
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
                                    <tr class="">
                                        <th class="text-center w-50">
                                            <input id="CheckBoxAll" onclick="javascript:SelectAllCheckboxes(this,'RepeaterHuongChuyenSau');"
                                                runat="server" type="checkbox" />
                                        </th>
                                        <th class="text-center w-50">
                                            #
                                        </th>
                                        <th>
                                            Mã hướng chuyên sâu
                                        </th>
                                        <th>
                                            Hướng chuyên sâu
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="RepeaterHuongChuyenSau" runat="server">
                                        <ItemTemplate>
                                            <tr class="showhim" data="<%# Eval("ChuyenSauGuid")%>">
                                                <td class="text-center ">
                                                    <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                    <asp:Literal ID="LiteralChuyenSauGuid" runat="server" Text='<%# Eval("ChuyenSauGuid")%>'
                                                        Visible="false"></asp:Literal>
                                                </td>
                                                <td class="text-center">
                                                    <div>
                                                        <div class="hideme">
                                                            <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                        </div>
                                                        <div class="showme">
                                                            <asp:LinkButton ID="LinkButtonItem" CssClass="btn btn-primary btn-circle btn-outline" ToolTip="Chỉnh sửa"
                                                                runat="server" CommandName="EDIT" CommandArgument='<%# Eval("ChuyenSauGuid")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="text-left">
                                                    <%# Eval("ChuyenSauID")%>
                                                </td>
                                                <td class="text-left">
                                                    <%# Eval("ChuyenSauName")%>
                                                </td>
                                               
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="4">
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
        <asp:AsyncPostBackTrigger ControlID="DropDownListKhoa" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="ButtonSearch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ButtonAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ButtonDelete" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="DropDownListPageNumber" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="mojoCutePager1" EventName="Command" />
    </Triggers>
</asp:UpdatePanel>
<script src="<%=ResolveUrl("~/") %>Resources/js/jquery-2.1.1.js" type="text/javascript"></script>
<script type="text/javascript">


    function loadSelect() {
        $('.showhim').click(function () {
            var bb = $(this).attr("data");
            $.cookie('aaa', bb);

            var a = $('tr');
            $(a).removeClass('current');

            if (bb) {
                var a = $('tr[data="' + bb + '"]');
                $(a).addClass('current');
            }
        });

        var thisLink = $.cookie('aaa');
        if (thisLink) {
            var a = $('tr[data="' + thisLink + '"]');
            $(a).addClass('current');
        }
    }
    $(document).ready(loadSelect);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(loadSelect);
</script>
