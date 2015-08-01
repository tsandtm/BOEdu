<%--   
Author:					chuongtv
Created:				2015-7-13
Last Modified:			2015-7-13
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListLogsControl.ascx.cs"
    Inherits="project.web.ListLogsControl" %>
<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowLog_on">
    <ProgressTemplate>
        <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
            <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui l?ng ??i..."
                height="80px" width="80px" /></span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelShowLog_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="row">
            <asp:Panel ID="pnlSearch" DefaultButton="ButtonSearch" runat="server">
                <div class="col-sm-3 m-b-5 ">
                    <div class="input-group">
                        <asp:TextBox ID="TextBoxValueSearch" runat="server" CssClass="form-control w-full"
                            placeholder="Nhập mssv muốn tìm kiếm ..."></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:LinkButton ID="ButtonSearch" runat="server" Text="" CssClass="btn btn-primary"><i class="fa fa-search"></i>
                            </asp:LinkButton>
                        </span>
                    </div>
                </div>
            </asp:Panel>
            <div class="col-sm-9 p-b-5">
                <div class="pull-right">
                    <asp:LinkButton Visible="false" ID="ButtonAdd" runat="server" ToolTip="Thêm mới"
                        CssClass="btn btn-add"><i class="fa fa-file-o"></i>&nbsp; Thêm mới </asp:LinkButton>
                    <asp:LinkButton Visible="false" ID="ButtonDelete" OnClientClick="return confirm('Bạn muốn xóa?');"
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
                                        <th class="text-center" style="width: 50px">
                                            <input id="CheckBoxAll" onclick="javascript:SelectAllCheckboxes(this,'RepeaterLog');"
                                                runat="server" type="checkbox" />
                                        </th>
                                        <th class="text-center" style="width: 50px">
                                            #
                                        </th>
                                        <th>
                                            Nội dung lưu vết
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="RepeaterLog" runat="server">
                                    <ItemTemplate>
                                        <tr class="showhim" data="<%# Eval("SinhVienGuid")%>">
                                            <td class="text-center ">
                                                <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                <asp:Literal ID="LiteralSinhVienGuid" runat="server" Visible="false" Text='<%# Eval("SinhVienGuid")%>'></asp:Literal>
                                            </td>
                                            <td class="text-center">
                                                <div class="hideme">
                                                    <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                                </div>
                                                <div class="showme">
                                                    <asp:LinkButton ID="LinkButtonItem" CssClass="btn btn-primary btn-circle btn-outline"
                                                        Visible="false" ToolTip="Chỉnh sửa" runat="server" CommandName="EDIT" CommandArgument='<%# Eval("SinhVienGuid")%>'><i class="fa fa-pencil"></i></asp:LinkButton>
                                                </div>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("Contents")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tfoot>
                                    <tr>
                                        <th colspan="4">
                                            <div class="form-inline">
                                                <div class="pull-left">
                                                    <MyC:mojoCutePager ID="mojoCutePager1" runat="server" CssClass="" />
                                                </div>
                                            </div>
                                            <div class=" pull-right">
                                                <div class="form-group">
                                                    <asp:DropDownList ID="DropDownListPageNumber" runat="server" AutoPostBack="true"
                                                        CssClass="form-control  width-size-100">
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
