<%--   
Author:					Nguyen Thanh Dai
Created:				2015-6-9
Last Modified:			2015-6-9
 --%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListCTQuanLyDonViControl.ascx.cs"
    Inherits="project.web.ListCTQuanLyDonViControl" %>

<asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelShowCTQuanLyDonVi_on">
    <ProgressTemplate >
        <span style=" position:fixed; z-index:9999; top:48%;left:48%;  "><img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..." height="80px" width="80px" /></span>
    </ProgressTemplate>
</asp:UpdateProgress>
<asp:UpdatePanel ID="UpdatePanelShowCTQuanLyDonVi_on" runat="server" UpdateMode="Conditional"
    ChildrenAsTriggers="false">
    <ContentTemplate>

        <asp:Literal ID="LiteralUserGuid" Visible="false" runat="server"></asp:Literal>
        <div class="row">
                <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-content">
                        <div class="table-responsive">
                            <table class="table table-striped">
                                <thead>
                                    <tr >
                                        <%--<th class="text-center" style="width:50px">
                                            <input id="CheckBoxAll" onclick="javascript:SelectAllCheckboxes(this,'RepeaterCTQuanLyDonVi');"
                                                runat="server" type="checkbox" />
                                        </th>--%>
                                        <th class="text-center" style="width:50px">
                                            STT
                                        </th>
                                        <th>
                                            Tên đơn vị
                                        </th>
                                        <th class="text-center" style="width:80px">
                                            Tác vụ
                                        </th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="RepeaterCTQuanLyDonVi" runat="server">
                                    <ItemTemplate>
                                        <tr class="showhim" data="<%# Eval("DonViGuid")%>">
                                            <%--<td class="text-center " >
                                                <asp:CheckBox ID="CheckBoxSelect" runat="server" />
                                                <asp:Literal ID="LiteralUserGuid" runat="server" Text='<%# Eval("UserGuid")%>'
                                                    Visible="false"></asp:Literal>
                                            </td>--%>
                                            <td class="text-center">
                                                <%# Container.ItemIndex + 1 + (PageNumber - 1) * PageSize%>
                                            </td>
                                            <td class="text-left">
                                                <%# Eval("KhoaName")%>
                                            </td>
                                            <td class="text-center">
                                                <asp:LinkButton  ID="LinkButtonItem" CssClass="fg-cyan" runat="server" CommandName="DEL" CommandArgument='<%# Eval("DonViGuid")%>'><i class="glyphicon glyphicon-edit"></i>&nbsp;Xóa </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                               <tfoot>
                                <tr>
                                    <th colspan="4">
                                        <div class="form-inline">
                                                <div class="pull-left" >
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
         
