<%--   
Author:					Nam Dep Trai
Created:				2015-5-21
Last Modified:			2015-5-21
--%>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddNienKhoaControlMienGiamMonHoc.ascx.cs"
    Inherits="project.web.Controls.AddNienKhoaControlMienGiamMonHoc" %>
<%--Luu y phai dat id popup o ngoai de khong bi an khi thao tac xong--%>
<div id="ts-popup-nienkhoa-miengiam" class="bigbox-350">
    <div class="panel panel-default panel-popup">
        <div class="panel-heading">
            <h3 class="panel-title">
                Quản lý niên khóa</h3>
        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="UpdatePanelPopupAddNienKhoa_on">
            <ProgressTemplate>
                <span style="position: fixed; z-index: 9999; top: 48%; left: 48%;">
                    <img src="<%=ResolveUrl("~/") %>Resources/img/waiting.gif" alt="Vui lòng đợi..."
                        height="80px" width="80px" /></span>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanelPopupAddNienKhoa_on" runat="server" UpdateMode="Conditional"
            ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="panel-body">
                    <asp:Literal ID="LiteralNienKhoaGuid" runat="server" Visible="false"></asp:Literal>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                ID
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxNienKhoaID" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                Niên khóa
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="form-group">
                                <asp:TextBox ID="TextBoxNienKhoaName" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="text-center">
                        <asp:LinkButton ID="ButtonSave" runat="server" ToolTip="Lưu" OnClientClick="return validation_miengiammonhoc_nienkhoa()" CssClass="btn btn-add btn-sm"><i class="glyphicon glyphicon-floppy-saved"></i>&nbsp;Lưu trữ</asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="ButtonReset" runat="server" ToolTip="Reset" CssClass="btn btn-reset btn-sm"><i class="glyphicon glyphicon-repeat"></i>&nbsp;Nhập lại</asp:LinkButton>  &nbsp;hoặc&nbsp;
                        <asp:LinkButton ID="ButtonExit" runat="server" ToolTip="Hủy" CssClass="btn btn-link btn-cancel btn-sm">&nbsp;Hủy thao tác</asp:LinkButton>
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

    function validation_miengiammonhoc_nienkhoa() {
        if (!String.prototype.trim) {
            String.prototype.trim = function () {
                return this.replace(/^\s+|\s+$/g, '');
            };
        }
        var TextBoxNienKhoaName = document.getElementById('<%= TextBoxNienKhoaName.ClientID %>');

        var meseges = "";
        var dateRegex = /^\d{1,2}\/\d{1,2}\/\d{4}$/;
        var fag = true;

        if (TextBoxNienKhoaName.value.trim().length == 0) {

            meseges += 'Chưa có niên khóa!\n';
            TextBoxNienKhoaName.style.background = "#FF0";
            fag = false;
        }
        if (meseges != "")
            alert(meseges);
        return fag;
    }
</script>
               
