<%--   
Author:					Nam Dep Trai
Created:				2015-5-22
Last Modified:			2015-5-22
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddTrinhDoDaoTaoControlMienGiamMonHoc.ascx.cs"
    Inherits="project.web.Controls.AddTrinhDoDaoTaoControlMienGiamMonHoc" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<div id="ts-popup-miengiammonhoc-quanlytrinhdodaotao" class="bigbox-350">
    <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Quản lý hướng chuyên sâu</h3>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddTrinhDoDaoTao_on">
            <ProgressTemplate>
                <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
                    <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                        height="80px" width="80px" /></span>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelPopupAddTrinhDoDaoTao_on" runat="server" UpdateMode="Conditional"
            ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="panel-body">
                    <asp:Literal ID="LiteralTrinhDoDTGuid" runat="server" Visible="false"></asp:Literal>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="">
                                ID:
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxTrinhDoDTID" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="">
                                Trình độ:
                            </div>
                        </div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxTrinhDoDTName" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer text-right">
                    <asp:LinkButton ID="ButtonSave" runat="server" ToolTip="Lưu trữ" CssClass="btn btn-add btn-sm"><i class="fa fa-floppy-o"></i>&nbsp;Lưu trữ</asp:LinkButton>
                    <asp:LinkButton ID="ButtonReset" runat="server" ToolTip="Reset" CssClass="btn btn-reset btn-sm"><i class="fa fa-rotate-left"></i>&nbsp;Nhập lại</asp:LinkButton>
                    &nbsp;hoặc&nbsp;
                    <asp:LinkButton ID="ButtonExit" runat="server" ToolTip="Thoát" class="btn btn-link btn-cancel btn-sm">
            Hủy thao tác</asp:LinkButton>
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
<script type="text/javascript">
    function parseDate(input) {
        var parts = input.split('/');
        return new Date(parts[2], parts[1] - 1, parts[0]);
    }
    function validateIsNumber(control) {
        var result = true;
        var testValue = control.value;
        testValue = testValue.toString().replace(/[ '.,]/g, "");
        if (testValue == "")
            return false;
        if (isNaN(testValue))
        { result = false; }
        return result;
    }

    function validation_miengiammonhoc_trinhdodaotao() {
        if (!String.prototype.trim) {
            String.prototype.trim = function () {
                return this.replace(/^\s+|\s+$/g, '');
            };
        }
        var TextBoxTrinhDoDTName = document.getElementById('<%= TextBoxTrinhDoDTName.ClientID %>');

        var meseges = "";
        var dateRegex = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
        var fag = true;

        if (TextBoxTrinhDoDTName.value.trim().length == 0) {

            meseges += 'Chưa có trình độ!\n';
            TextBoxTrinhDoDTName.style.background = "#FF0";
            fag = false;
        }
        if (meseges != "")
            alert(meseges);
        return fag;
    }
</script>
