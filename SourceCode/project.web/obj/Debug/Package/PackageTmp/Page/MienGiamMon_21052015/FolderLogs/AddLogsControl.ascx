<%--   
Author:					chuongtv
Created:				2015-7-13
Last Modified:			2015-7-13
 --%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddLogsControl.ascx.cs"
    Inherits="project.web.AddLogsControl" %>

<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<div id="ts-popup" class="bigbox-350">
     <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Quản lý Log</h3>
        </div>
            <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddLog_on">
                <ProgressTemplate >
                    <span style=" position:fixed; z-index:9999; top:48%;left:48%;  "><img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui l?ng ??i..." height="80px" width="80px" /></span>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanelPopupAddLog_on" runat="server" UpdateMode="Conditional"
                    ChildrenAsTriggers="false">
                    <ContentTemplate>
            <div class="panel-body">
                        <asp:Literal ID="LiteralSinhVienGuid" Visible="false" runat="server"></asp:Literal>
                        
                        <div class="row">
                            <div class="col-md-4">
                                <div class="">
                                    Nội dung lưu vết
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <asp:TextBox ID="TextBoxContents" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    
             </div>
            <div class="panel-footer">
                <div class="text-center">
                        <asp:LinkButton ID="ButtonSave" runat="server" ToolTip="L?u" CssClass="btn btn-add btn-sm"><i class="glyphicon glyphicon-floppy-saved"></i>&nbsp;L?u tr?</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="ButtonReset" runat="server" ToolTip="Reset" CssClass="btn btn-reset btn-sm"><i class="glyphicon glyphicon-repeat"></i>&nbsp;Nh?p l?i</asp:LinkButton>
                        <asp:LinkButton ID="ButtonExit" runat="server" ToolTip="H?y" CssClass="btn btn-link btn-cancel btn-sm">&nbsp;H?y thao t?c</asp:LinkButton>
                </div>
            </div>
            </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ButtonSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ButtonExit" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="ButtonReset" EventName="Click" />
                    </Triggers>
             </asp:UpdatePanel>
     </div>
</div>
               
